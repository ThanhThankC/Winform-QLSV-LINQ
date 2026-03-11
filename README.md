# 📚 QL Sinh Viên - WinForms + LINQ to SQL

Dự án quản lý sinh viên đơn giản với 3 form chính.

## 🛠️ Công nghệ
- C# WinForms (.NET Framework)
- LINQ to SQL
- SQL Server

## 🗄️ Cài đặt Database
1. Mở SQL Server Management Studio
2. Chạy file `SQLQuery1.sql` để tạo database
3. Cập nhật connection string trong `QLSinhVienDB.dbml`

## 🚀 Cách chạy
1. Clone repo: `git clone <url>`
2. Mở `QLSinhVien.sln` bằng Visual Studio
3. Build & Run (F5)
4. Đăng nhập: **admin / 123456**

## 👥 Thành viên
| Thành viên | Vai trò | Phần đảm nhận |
|---|---|---|
| ThanhThanhC | Admin | Setup, Login, Quản lý Sinh viên |
| DinhThanhK | Collaborator | Quản lý Lớp học |

## 📂 Cấu trúc Nhánh
- `main` - Nhánh chính
- `feature/login` - Form đăng nhập  
- `feature/student-management` - CRUD sinh viên
- `feature/class-management` - CRUD lớp học 