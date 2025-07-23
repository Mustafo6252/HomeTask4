# Student API (.NET 9)

Ushbu RESTful API talabalarni boshqarish uchun ishlab chiqilgan. Talabalar ro'yxati JSON formatda lokal faylga saqlanadi. API quyidagi CRUD operatsiyalarni taqdim etadi:

---

## 📁 Loyiha Tuzilmasi

- **Controllers/StudentController.cs** – Barcha API endpointlar shu yerda
- **Models/Student.cs** – Talaba modeli
- **students.txt** – Ma'lumotlar saqlanuvchi fayl (`/Users/macbook/Desktop/course/students.txt`)

📷 **Rasm joyi 1**: Loyiha papkalari tuzilmasi

---

## 🚀 API Buyruqlari (Endpointlar)

---

### 🟢 1. `POST /api/Student/Post`  
Yangi student qo‘shadi.

- So‘rov JSON formatda bo‘ladi.
- Null tekshiruvi mavjud.
- Faylga yangi student yoziladi.

📷 **Rasm joyi 2**: Postman yoki Swagger’da POST so‘rovi namunasi

---<img width="600" height="900" alt="Screenshot 2025-07-23 at 13 02 12" src="https://github.com/user-attachments/assets/585eb09c-25ed-4f9b-bee6-b23deeeb3a03" />


### 🔵 2. `GET /api/Student/Get`  
Barcha studentlarni olish.

- `students.txt` faylidan ro'yxat o'qiladi.
- Bo‘sh bo‘lsa, bo‘sh ro'yxat qaytariladi.

📷 **Rasm joyi 3**: GET so‘rov natijasi (Postman yoki Swagger)

<img width="600" height="900" alt="Screenshot 2025-07-23 at 13 02 04" src="https://github.com/user-attachments/assets/29ddef9f-2b5b-4340-b1e1-42b5199cced8" />

---

### 🟡 3. `GET /api/Student/GetById?Id=1`  
ID bo‘yicha bitta studentni qaytaradi.

- `Id` query parametr orqali olinadi.
- Agar topilmasa: 400 xato.
- Aks holda: 200 OK.

📷 **Rasm joyi 4**: GET by ID uchun rasm

<img width="600" height="900" alt="Screenshot 2025-07-23 at 13 01 57" src="https://github.com/user-attachments/assets/d76fdb54-6954-4aab-a35d-7312c9bb07fb" />

---

### 🟠 4. `PUT /api/Student/Put`  
Studentni yangilash (hozircha qo‘shib yuboradi).

- So‘rov JSON orqali.
- Hozirgi holatda mavjud studentni yangilamaydi, yangisini qo‘shadi.
- Bu xatoni tuzatish tavsiya etiladi.

📷 **Rasm joyi 5**: PUT natijasida student dubl bo‘lib qolgan holat

<img width="600" height="900" alt="Screenshot 2025-07-23 at 13 02 17" src="https://github.com/user-attachments/assets/190b08c0-81b7-45c2-a4ca-d79852384edc" />

---

### 🔴 5. `DELETE /api/Student/Delete?Id=1`  
Studentni ID orqali o‘chiradi.

- `Id` query parametr orqali olinadi.
- Topilmasa: 400.
- Topilsa: listdan o‘chib, faylga qaytadan yoziladi.

📷 **Rasm joyi 6**: DELETE so‘rovi natijasi

<img width="600" height="900" alt="Screenshot 2025-07-23 at 13 02 27" src="https://github.com/user-attachments/assets/892aac31-283c-4902-a11a-7ae5e9c34c1a" />

---

## ⚠️ Muhim Eslatmalar

- Fayl avtomatik yaratiladi, agar mavjud bo‘lmasa.
- JSON faylga yozish uchun yozish huquqi bo‘lishi kerak.
- `PUT` endpointni yangilash kerak: mavjud studentni topib, xossalarini o‘zgartirishi lozim.

---

## 🧪 Ishga Tushirish

1. Terminalda quyidagini ishga tushiring:
   ```bash
   dotnet run
