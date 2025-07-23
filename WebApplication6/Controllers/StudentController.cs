using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    [ApiController]
    [Route("api/Student")]
    public class StudentController : ControllerBase
    {
        private readonly string path = "/Users/macbook/Desktop/course/students.txt";

        public StudentController()
        {
            if (!System.IO.File.Exists(path))
            {
                System.IO.File.WriteAllText(path, "[]");
            }
        }

        private async Task<List<Student>> ReadStudentsFromFileAsync()
        {
            string content = await System.IO.File.ReadAllTextAsync(path);

            if (string.IsNullOrWhiteSpace(content))
                return new List<Student>();

            return JsonSerializer.Deserialize<List<Student>>(content) ?? new List<Student>();
        }

        private async Task SaveStudentsToFileAsync(List<Student> students)
        {
            string content = JsonSerializer.Serialize(students, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            await System.IO.File.WriteAllTextAsync(path, content);
        }

        [HttpPost("Post")]
        public async Task<ActionResult<Student>> PostStudentAsync(Student student)
        {
            if (student == null)
                return BadRequest("Student null bo'lishi mumkin emas.");

            var students = await ReadStudentsFromFileAsync();
            students.Add(student);
            await SaveStudentsToFileAsync(students);

            return Ok(student);
        }

        [HttpGet("Get")]
        public async Task<ActionResult<List<Student>>> GetAllStudentsAsync()
        {
            var students = await ReadStudentsFromFileAsync();
            return Ok(students);
        }

        [HttpGet("GetById")]
        public async Task<ActionResult<List<Student>>> GetStudentsByCourseAsync([FromQuery] int Id)
        {
            var students = await ReadStudentsFromFileAsync();
            Student maybeStudent=students.FirstOrDefault(x => x.Id == Id);
            if (maybeStudent == null)
            {
                return BadRequest("Student not found");
            }
            return Ok(maybeStudent);
        }

        [HttpPut("Put")]
        public async Task<ActionResult<Student>> PutStudentAsync([FromBody]Student student)
        {
            if (student == null)
                return BadRequest("Student null bo'lishi mumkin emas.");
            var students = await ReadStudentsFromFileAsync();
            Student maybeStudent = students.FirstOrDefault(x => x.Id == student.Id);
            if (maybeStudent == null)
            {
                return BadRequest("Student not found");
            }
            else
            {
               students.Add(student);
               await SaveStudentsToFileAsync(students);
               return Created();
            }
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Student>> DeleteStudentAsync([FromQuery] int Id)
        {
            var students = await ReadStudentsFromFileAsync();
            Student maybeStudent = students.FirstOrDefault(x => x.Id == Id);
            if (maybeStudent == null)
            {
                return BadRequest("Student not found");
            }
            else
            {
                students.Remove(maybeStudent);
                await SaveStudentsToFileAsync(students);
                return Ok(students);
            }
        }


    }
}