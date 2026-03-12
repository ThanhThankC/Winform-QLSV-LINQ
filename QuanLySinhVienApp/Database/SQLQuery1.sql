USE master; 
IF DB_ID('QLSinhVienDB') IS NOT NULL 
BEGIN ALTER DATABASE QLSinhVienDB SET SINGLE_USER WITH ROLLBACK IMMEDIATE; 
DROP DATABASE QLSinhVienDB; END


CREATE DATABASE QLSinhVienDB;
GO
USE QLSinhVienDB;
GO

CREATE TABLE Users (
    Username NVARCHAR(50) PRIMARY KEY,
    Password NVARCHAR(100) NOT NULL,
    Role NVARCHAR(20)
);

CREATE TABLE Classes (
    ClassID INT IDENTITY(1,1) PRIMARY KEY,
    ClassName NVARCHAR(100) NOT NULL
);

CREATE TABLE Students (
    StudentID INT IDENTITY(1,1) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Age INT,
    ClassID INT FOREIGN KEY REFERENCES Classes(ClassID)
);

INSERT INTO Users (Username, Password, Role) VALUES 
('ad', '123', 'Admin'),
('admin', '123456', 'Admin'),
('giangvien', '111111', 'User');

INSERT INTO Classes (ClassName) VALUES 
('68PM1'),
('68PM2'),
('68PM3'),
('68PM4');

INSERT INTO Students (FullName, Age, ClassID) VALUES 
(N'Nguyễn Văn An', 20, 1),
(N'Trần Thị Bình', 20, 1),
(N'Lê Hoàng Cường', 21, 1),
(N'Phạm Thị Dung', 20, 1),
(N'Hoàng Văn Em', 22, 1),
(N'Đỗ Minh Quân', 20, 1),
(N'Vũ Thị Bích', 21, 1),
(N'Ngô Tấn Đạt', 20, 1),
(N'Bùi Anh Tuấn', 20, 1),
(N'Phan Thị Mai', 21, 1);

INSERT INTO Students (FullName, Age, ClassID) VALUES 
(N'Trịnh Xuân Bách', 20, 2),
(N'Lý Mạc Sầu', 21, 2),
(N'Quách Tĩnh', 22, 2),
(N'Hoàng Dung', 20, 2),
(N'Dương Quá', 21, 2),
(N'Tiểu Long Nữ', 20, 2),
(N'Châu Bá Thông', 23, 2),
(N'Hồng Thất Công', 22, 2),
(N'Âu Dương Phong', 21, 2);

INSERT INTO Students (FullName, Age, ClassID) VALUES 
(N'Đinh Khắc Hiếu', 20, 3),
(N'Nguyễn Hải Đăng', 20, 3),
(N'Lê Tấn Tài', 21, 3),
(N'Trần Hữu Vô', 20, 3),
(N'Phạm Nhật Vượng', 22, 3),
(N'Trương Đình Anh', 20, 3),
(N'Nguyễn Thanh Tùng', 21, 3),
(N'Vương Đình Huệ', 20, 3),
(N'Bùi Minh Trí', 20, 3),
(N'Đào Ngọc Bảo', 21, 3);

INSERT INTO Students (FullName, Age, ClassID) VALUES 
(N'Cao Thái Sơn', 20, 4),
(N'Ngô Kiến Huy', 21, 4),
(N'Sơn Tùng MTP', 22, 4),
(N'Hồ Ngọc Hà', 20, 4),
(N'Mỹ Tâm', 21, 4),
(N'Đàm Vĩnh Hưng', 20, 4),
(N'Phan Đình Tùng', 23, 4),
(N'Lệ Quyên', 22, 4);

GO