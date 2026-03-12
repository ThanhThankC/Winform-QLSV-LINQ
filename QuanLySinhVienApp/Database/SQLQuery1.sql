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
    ClassID NVARCHAR(10) PRIMARY KEY,
    ClassName NVARCHAR(100) NOT NULL
);

CREATE TABLE Students (
    StudentID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Age INT,
    ClassID NVARCHAR(10) FOREIGN KEY REFERENCES Classes(ClassID)
);

INSERT INTO Users (Username, Password, Role) VALUES 
('ad', '123', 'Admin'),
('admin', '123456', 'Admin'),
('giangvien', '111111', 'User');

INSERT INTO Classes (ClassID, ClassName) VALUES 
('67PM1', '67PM1'),
('67PM2', '67PM2'),
('67PM3', '67PM3'),
('68PM1', '68PM1'),
('68PM2', '68PM2'),
('68PM3', '68PM3'),
('69PM1', '69PM1'),
('69PM2', '69PM2'),
('69PM3', '69PM3');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0112367', N'Nguyễn Văn An', 20, '67PM1'),
('0198467', N'Trần Thị Bình', 20, '67PM1'),
('0234567', N'Lê Hoàng Cường', 21, '67PM1'),
('0187367', N'Phạm Thị Dung', 20, '67PM1'),
('0345267', N'Hoàng Văn Em', 22, '67PM1'),
('0276167', N'Đỗ Minh Quân', 20, '67PM1'),
('0163867', N'Vũ Thị Bích', 21, '67PM1'),
('0219467', N'Ngô Tấn Đạt', 20, '67PM1'),
('0154967', N'Bùi Anh Tuấn', 20, '67PM1'),
('0298667', N'Phan Thị Mai', 21, '67PM1');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0143267', N'Trịnh Xuân Bách', 20, '67PM2'),
('0287567', N'Lý Thị Lan', 21, '67PM2'),
('0321867', N'Quách Minh Tuấn', 22, '67PM2'),
('0176467', N'Hoàng Thị Nga', 20, '67PM2'),
('0234167', N'Dương Văn Khoa', 21, '67PM2'),
('0198967', N'Tiểu Thị Hoa', 20, '67PM2'),
('0312467', N'Châu Minh Đức', 23, '67PM2'),
('0267867', N'Hồng Văn Tài', 22, '67PM2'),
('0154367', N'Âu Thị Phương', 21, '67PM2');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0289167', N'Đinh Khắc Hiếu', 20, '67PM3'),
('0143667', N'Nguyễn Hải Đăng', 20, '67PM3'),
('0312567', N'Lê Tấn Tài', 21, '67PM3'),
('0176867', N'Trần Hữu Vô', 20, '67PM3'),
('0234967', N'Phạm Nhật Vượng', 22, '67PM3'),
('0198267', N'Trương Đình Anh', 20, '67PM3'),
('0321367', N'Nguyễn Thanh Tùng', 21, '67PM3'),
('0267467', N'Vương Đình Huệ', 20, '67PM3'),
('0154167', N'Bùi Minh Trí', 20, '67PM3'),
('0289867', N'Đào Ngọc Bảo', 21, '67PM3');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0112368', N'Nguyễn Văn An', 20, '68PM1'),
('0198468', N'Trần Thị Bình', 20, '68PM1'),
('0234568', N'Lê Hoàng Cường', 21, '68PM1'),
('0187368', N'Phạm Thị Dung', 20, '68PM1'),
('0345268', N'Hoàng Văn Em', 22, '68PM1'),
('0276168', N'Đỗ Minh Quân', 20, '68PM1'),
('0163868', N'Vũ Thị Bích', 21, '68PM1'),
('0219468', N'Ngô Tấn Đạt', 20, '68PM1'),
('0154968', N'Bùi Anh Tuấn', 20, '68PM1'),
('0298668', N'Phan Thị Mai', 21, '68PM1');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0143268', N'Trịnh Xuân Bách', 20, '68PM2'),
('0287568', N'Lý Mạc Sầu', 21, '68PM2'),
('0321868', N'Quách Tĩnh', 22, '68PM2'),
('0176468', N'Hoàng Dung', 20, '68PM2'),
('0234168', N'Dương Quá', 21, '68PM2'),
('0198968', N'Tiểu Long Nữ', 20, '68PM2'),
('0312468', N'Châu Bá Thông', 23, '68PM2'),
('0267868', N'Hồng Thất Công', 22, '68PM2'),
('0154368', N'Âu Dương Phong', 21, '68PM2');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0289168', N'Đinh Khắc Hiếu', 20, '68PM3'),
('0143668', N'Nguyễn Hải Đăng', 20, '68PM3'),
('0312568', N'Lê Tấn Tài', 21, '68PM3'),
('0176868', N'Trần Hữu Vô', 20, '68PM3'),
('0234968', N'Phạm Nhật Vượng', 22, '68PM3'),
('0198268', N'Trương Đình Anh', 20, '68PM3'),
('0321368', N'Nguyễn Thanh Tùng', 21, '68PM3'),
('0267468', N'Vương Đình Huệ', 20, '68PM3'),
('0154168', N'Bùi Minh Trí', 20, '68PM3'),
('0289868', N'Đào Ngọc Bảo', 21, '68PM3');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0145269', N'Cao Thái Sơn', 20, '69PM1'),
('0213469', N'Ngô Kiến Huy', 21, '69PM1'),
('0378569', N'Sơn Tùng MTP', 22, '69PM1'),
('0167869', N'Hồ Ngọc Hà', 20, '69PM1'),
('0234269', N'Mỹ Tâm', 21, '69PM1'),
('0189169', N'Đàm Vĩnh Hưng', 20, '69PM1'),
('0312769', N'Phan Đình Tùng', 23, '69PM1'),
('0256369', N'Lệ Quyên', 22, '69PM1');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0178469', N'Trần Minh Khoa', 20, '69PM2'),
('0234769', N'Nguyễn Thị Lan', 21, '69PM2'),
('0312169', N'Lê Văn Bình', 20, '69PM2'),
('0189569', N'Phạm Thị Thu', 22, '69PM2'),
('0267269', N'Hoàng Minh Đức', 21, '69PM2'),
('0145869', N'Đỗ Thị Hương', 20, '69PM2'),
('0356169', N'Vũ Văn Long', 21, '69PM2'),
('0213869', N'Bùi Thị Ngọc', 20, '69PM2');

INSERT INTO Students (StudentID, FullName, Age, ClassID) VALUES 
('0189369', N'Ngô Văn Hùng', 20, '69PM3'),
('0267569', N'Lý Thị Thanh', 21, '69PM3'),
('0312969', N'Trịnh Văn Dũng', 22, '69PM3'),
('0145469', N'Châu Thị Linh', 20, '69PM3'),
('0234669', N'Dương Minh Tú', 21, '69PM3'),
('0178269', N'Hồng Văn Phúc', 20, '69PM3'),
('0356469', N'Đinh Thị Yến', 23, '69PM3'),
('0213269', N'Quách Văn Nam', 22, '69PM3');

GO