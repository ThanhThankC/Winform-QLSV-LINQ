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
    Role NVARCHAR(20) -- 'Admin', 'Teacher', 'Staff'
);

CREATE TABLE Departments (
    DepartmentID NVARCHAR(10) PRIMARY KEY,
    DepartmentName NVARCHAR(100) NOT NULL
);

CREATE TABLE Classes (
    ClassID NVARCHAR(10) PRIMARY KEY,
    ClassName NVARCHAR(100) NOT NULL,
    DepartmentID NVARCHAR(10) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Teachers (
    TeacherID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    DepartmentID NVARCHAR(10) REFERENCES Departments(DepartmentID)
);

CREATE TABLE Students (
    StudentID NVARCHAR(10) PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    DateOfBirth DATE NOT NULL,
    Gender NVARCHAR(10),
    ClassID NVARCHAR(10) REFERENCES Classes(ClassID)
);

CREATE TABLE Subjects (
    SubjectID NVARCHAR(10) PRIMARY KEY,
    SubjectName NVARCHAR(100) NOT NULL,
    Credits INT NOT NULL,
    TeacherID NVARCHAR(10) REFERENCES Teachers(TeacherID)
);

CREATE TABLE Grades (
    StudentID NVARCHAR(10) REFERENCES Students(StudentID),
    SubjectID NVARCHAR(10) REFERENCES Subjects(SubjectID),
    MidtermScore DECIMAL(4,2),
    FinalScore DECIMAL(4,2),
    PRIMARY KEY (StudentID, SubjectID)
);

-- Users
INSERT INTO Users VALUES ('ad', '123', 'Admin');
INSERT INTO Users VALUES ('giaovu', '111111', 'Staff');
INSERT INTO Users VALUES ('gv01', '123456', 'Teacher');

-- Departments
INSERT INTO Departments VALUES ('CNTT', N'Công nghệ thông tin');
INSERT INTO Departments VALUES ('KTKT', N'Kế toán kiểm toán');
INSERT INTO Departments VALUES ('QTKD', N'Quản trị kinh doanh');
INSERT INTO Departments VALUES ('NNNA', N'Ngôn ngữ Anh');

-- Classes
INSERT INTO Classes VALUES ('67PM1', N'67 Phần mềm 1', 'CNTT');
INSERT INTO Classes VALUES ('67PM2', N'67 Phần mềm 2', 'CNTT');
INSERT INTO Classes VALUES ('67PM3', N'67 Phần mềm 3', 'CNTT');
INSERT INTO Classes VALUES ('68PM1', N'68 Phần mềm 1', 'CNTT');
INSERT INTO Classes VALUES ('68PM2', N'68 Phần mềm 2', 'CNTT');
INSERT INTO Classes VALUES ('67KT1', N'67 Kế toán 1', 'KTKT');
INSERT INTO Classes VALUES ('67KT2', N'67 Kế toán 2', 'KTKT');
INSERT INTO Classes VALUES ('67QT1', N'67 Quản trị 1', 'QTKD');
INSERT INTO Classes VALUES ('67AN1', N'67 Anh 1', 'NNNA');

-- Teachers
INSERT INTO Teachers VALUES ('GV001', N'Nguyễn Văn An', 'CNTT');
INSERT INTO Teachers VALUES ('GV002', N'Trần Thị Bình', 'CNTT');
INSERT INTO Teachers VALUES ('GV003', N'Lê Hoàng Cường', 'CNTT');
INSERT INTO Teachers VALUES ('GV004', N'Phạm Thị Dung', 'KTKT');
INSERT INTO Teachers VALUES ('GV005', N'Hoàng Văn Em', 'QTKD');
INSERT INTO Teachers VALUES ('GV006', N'Đỗ Minh Quân', 'NNNA');

-- Subjects
INSERT INTO Subjects VALUES ('LT001', N'Lập trình C#', 3, 'GV001');
INSERT INTO Subjects VALUES ('LT002', N'Lập trình Web', 3, 'GV002');
INSERT INTO Subjects VALUES ('LT003', N'Cơ sở dữ liệu', 3, 'GV003');
INSERT INTO Subjects VALUES ('LT004', N'Cấu trúc dữ liệu', 2, 'GV001');
INSERT INTO Subjects VALUES ('KT001', N'Kế toán đại cương', 3, 'GV004');
INSERT INTO Subjects VALUES ('QT001', N'Quản trị học', 3, 'GV005');
INSERT INTO Subjects VALUES ('AN001', N'Tiếng Anh cơ bản', 3, 'GV006');

-- Students (30 sinh viên)
INSERT INTO Students VALUES ('SV001', N'Nguyễn Văn An', '2004-01-15', N'Nam', '67PM1');
INSERT INTO Students VALUES ('SV002', N'Trần Thị Bình', '2004-03-22', N'Nữ', '67PM1');
INSERT INTO Students VALUES ('SV003', N'Lê Hoàng Cường', '2003-07-10', N'Nam', '67PM1');
INSERT INTO Students VALUES ('SV004', N'Phạm Thị Dung', '2004-05-18', N'Nữ', '67PM1');
INSERT INTO Students VALUES ('SV005', N'Hoàng Văn Em', '2003-11-25', N'Nam', '67PM1');
INSERT INTO Students VALUES ('SV006', N'Đỗ Minh Quân', '2004-02-14', N'Nam', '67PM2');
INSERT INTO Students VALUES ('SV007', N'Vũ Thị Bích', '2004-08-30', N'Nữ', '67PM2');
INSERT INTO Students VALUES ('SV008', N'Ngô Tấn Đạt', '2003-12-05', N'Nam', '67PM2');
INSERT INTO Students VALUES ('SV009', N'Bùi Anh Tuấn', '2004-04-20', N'Nam', '67PM2');
INSERT INTO Students VALUES ('SV010', N'Phan Thị Mai', '2004-06-11', N'Nữ', '67PM2');
INSERT INTO Students VALUES ('SV011', N'Trịnh Xuân Bách', '2003-09-17', N'Nam', '67PM3');
INSERT INTO Students VALUES ('SV012', N'Lý Thị Lan', '2004-01-28', N'Nữ', '67PM3');
INSERT INTO Students VALUES ('SV013', N'Quách Minh Tuấn', '2003-10-03', N'Nam', '67PM3');
INSERT INTO Students VALUES ('SV014', N'Hoàng Thị Nga', '2004-07-22', N'Nữ', '67PM3');
INSERT INTO Students VALUES ('SV015', N'Dương Văn Khoa', '2003-08-14', N'Nam', '67PM3');
INSERT INTO Students VALUES ('SV016', N'Nguyễn Hải Đăng', '2005-01-10', N'Nam', '68PM1');
INSERT INTO Students VALUES ('SV017', N'Lê Tấn Tài', '2005-03-25', N'Nam', '68PM1');
INSERT INTO Students VALUES ('SV018', N'Trần Hữu Phúc', '2005-06-18', N'Nam', '68PM1');
INSERT INTO Students VALUES ('SV019', N'Phạm Thị Thu', '2005-02-14', N'Nữ', '68PM1');
INSERT INTO Students VALUES ('SV020', N'Võ Minh Khang', '2005-09-30', N'Nam', '68PM1');
INSERT INTO Students VALUES ('SV021', N'Đinh Thị Yến', '2005-04-07', N'Nữ', '68PM2');
INSERT INTO Students VALUES ('SV022', N'Cao Văn Hùng', '2005-07-19', N'Nam', '68PM2');
INSERT INTO Students VALUES ('SV023', N'Lưu Thị Hoa', '2005-11-23', N'Nữ', '68PM2');
INSERT INTO Students VALUES ('SV024', N'Mai Văn Long', '2005-05-12', N'Nam', '68PM2');
INSERT INTO Students VALUES ('SV025', N'Hồ Thị Ngọc', '2005-08-28', N'Nữ', '68PM2');
INSERT INTO Students VALUES ('SV026', N'Châu Văn Bảo', '2004-03-15', N'Nam', '67KT1');
INSERT INTO Students VALUES ('SV027', N'Dư Thị Linh', '2004-06-20', N'Nữ', '67KT1');
INSERT INTO Students VALUES ('SV028', N'Tăng Minh Đức', '2004-09-11', N'Nam', '67KT2');
INSERT INTO Students VALUES ('SV029', N'Hứa Thị Phương', '2004-12-05', N'Nữ', '67QT1');
INSERT INTO Students VALUES ('SV030', N'Khổng Văn Nam', '2004-02-28', N'Nam', '67AN1');

-- Grades
INSERT INTO Grades VALUES ('SV001', 'LT001', 7.5, 8.0);
INSERT INTO Grades VALUES ('SV001', 'LT002', 6.5, 7.0);
INSERT INTO Grades VALUES ('SV001', 'LT003', 8.0, 8.5);
INSERT INTO Grades VALUES ('SV002', 'LT001', 9.0, 9.5);
INSERT INTO Grades VALUES ('SV002', 'LT002', 7.0, 7.5);
INSERT INTO Grades VALUES ('SV002', 'LT003', 6.0, 6.5);
INSERT INTO Grades VALUES ('SV003', 'LT001', 5.0, 5.5);
INSERT INTO Grades VALUES ('SV003', 'LT002', 8.5, 9.0);
INSERT INTO Grades VALUES ('SV003', 'LT003', 7.0, 7.5);
INSERT INTO Grades VALUES ('SV004', 'LT001', 4.0, 4.5);
INSERT INTO Grades VALUES ('SV004', 'LT002', 6.0, 6.5);
INSERT INTO Grades VALUES ('SV004', 'LT003', 5.5, 6.0);
INSERT INTO Grades VALUES ('SV005', 'LT001', 8.0, 8.5);
INSERT INTO Grades VALUES ('SV005', 'LT002', 7.5, 8.0);
INSERT INTO Grades VALUES ('SV005', 'LT003', 9.0, 9.5);
INSERT INTO Grades VALUES ('SV006', 'LT001', 6.0, 6.5);
INSERT INTO Grades VALUES ('SV006', 'LT003', 7.0, 7.5);
INSERT INTO Grades VALUES ('SV007', 'LT002', 8.0, 8.5);
INSERT INTO Grades VALUES ('SV007', 'LT003', 6.5, 7.0);
INSERT INTO Grades VALUES ('SV008', 'LT001', 7.0, 7.5);
INSERT INTO Grades VALUES ('SV008', 'LT004', 8.0, 8.5);
INSERT INTO Grades VALUES ('SV009', 'LT001', 5.5, 6.0);
INSERT INTO Grades VALUES ('SV009', 'LT004', 6.0, 6.5);
INSERT INTO Grades VALUES ('SV010', 'LT002', 9.0, 9.5);
INSERT INTO Grades VALUES ('SV010', 'LT003', 8.0, 8.5);