CREATE DATABASE QuanLyQuanAn;
GO
USE QuanLyQuanAn;
GO
CREATE TABLE Categories (
    Id INT IDENTITY PRIMARY KEY,
    TenDanhMuc NVARCHAR(100) NOT NULL
);
CREATE TABLE Foods (
    Id INT IDENTITY PRIMARY KEY,
    TenMon NVARCHAR(150) NOT NULL,
    Gia DECIMAL(18,2) NOT NULL,
    DanhMucId INT,
    HinhAnh NVARCHAR(255),
    TrangThai BIT DEFAULT 1,
    FOREIGN KEY (DanhMucId) REFERENCES Categories(Id)
);
CREATE TABLE Tables (
    Id INT IDENTITY PRIMARY KEY,
    TenBan NVARCHAR(100),
    TrangThai NVARCHAR(50) DEFAULT N'Trống'
);
CREATE TABLE Staff (
    Id INT IDENTITY PRIMARY KEY,
    TenDangNhap NVARCHAR(50) UNIQUE,
    MatKhau NVARCHAR(100),
    TenHienThi NVARCHAR(100),
    VaiTro NVARCHAR(50) DEFAULT N'Nhân viên'
);
CREATE TABLE Bills (
    Id INT IDENTITY PRIMARY KEY,
    TableId INT,
    ThoiGianMo DATETIME DEFAULT GETDATE(),
    ThoiGianDong DATETIME NULL,
    TongTien DECIMAL(18,2) DEFAULT 0,
    TrangThai BIT DEFAULT 0, -- 0: chưa thanh toán, 1: đã thanh toán
    FOREIGN KEY (TableId) REFERENCES Tables(Id)
);
CREATE TABLE BillDetails (
    Id INT IDENTITY PRIMARY KEY,
    BillId INT,
    FoodId INT,
    SoLuong INT,
    DonGia DECIMAL(18,2),
    FOREIGN KEY (BillId) REFERENCES Bills(Id),
    FOREIGN KEY (FoodId) REFERENCES Foods(Id)
);
CREATE TABLE Discounts (
    Id INT IDENTITY PRIMARY KEY,
    TenChuongTrinh NVARCHAR(100),
    PhanTramGiam DECIMAL(5,2)
);