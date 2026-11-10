-- BÀI 6.4: Hệ thống quản lý garage và bảo dưỡng xe ô tô
IF DB_ID(N'GarageDB') IS NULL
    CREATE DATABASE GarageDB;
GO

USE GarageDB;
GO

IF OBJECT_ID(N'dbo.ChiTietSuaChua', N'U') IS NOT NULL DROP TABLE dbo.ChiTietSuaChua;
IF OBJECT_ID(N'dbo.PhieuSuaChua', N'U') IS NOT NULL DROP TABLE dbo.PhieuSuaChua;
IF OBJECT_ID(N'dbo.PhuTung', N'U') IS NOT NULL DROP TABLE dbo.PhuTung;
IF OBJECT_ID(N'dbo.Xe', N'U') IS NOT NULL DROP TABLE dbo.Xe;
IF OBJECT_ID(N'dbo.KhachHang', N'U') IS NOT NULL DROP TABLE dbo.KhachHang;
GO

-- 1. Khách hàng (chủ xe)
CREATE TABLE dbo.KhachHang
(
    MaKH      INT IDENTITY(1,1) PRIMARY KEY,
    TenKH     NVARCHAR(100) NOT NULL,
    DienThoai VARCHAR(15) NULL UNIQUE,
    DiaChi    NVARCHAR(200) NULL
);

-- 2. Thông tin ô tô
CREATE TABLE dbo.Xe
(
    BienSo     VARCHAR(20) PRIMARY KEY,
    MaKH       INT NOT NULL REFERENCES dbo.KhachHang(MaKH),
    HieuXe     NVARCHAR(50) NULL,   
    NamSanXuat INT NULL
);

-- 3. Phụ tùng / vật tư
CREATE TABLE dbo.PhuTung
(
    MaPhuTung  INT IDENTITY(1,1) PRIMARY KEY,
    TenPhuTung NVARCHAR(150) NOT NULL,
    DonGia     DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    SoLuongTon INT NOT NULL DEFAULT 0 CHECK (SoLuongTon >= 0)
);

-- 4. Phiếu sửa chữa
CREATE TABLE dbo.PhieuSuaChua
(
    MaPhieu    INT IDENTITY(1,1) PRIMARY KEY,
    BienSo     VARCHAR(20) NOT NULL REFERENCES dbo.Xe(BienSo),
    NgayNhan   DATETIME NOT NULL DEFAULT GETDATE(),
    NoiDungSua NVARCHAR(MAX) NULL,
    TongTien   DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai  NVARCHAR(30) NOT NULL DEFAULT N'Đang sửa'      -- Đang sửa / Đã hoàn thành / Đã thanh toán
);

-- 5. Chi tiết phụ tùng & tiền công
CREATE TABLE dbo.ChiTietSuaChua
(
    MaPhieu   INT NOT NULL REFERENCES dbo.PhieuSuaChua(MaPhieu),
    MaPhuTung INT NOT NULL REFERENCES dbo.PhuTung(MaPhuTung),
    SoLuong   INT NOT NULL CHECK (SoLuong > 0),
    TienCong  DECIMAL(18,2) NOT NULL DEFAULT 0 CHECK (TienCong >= 0),
    PRIMARY KEY (MaPhieu, MaPhuTung)
);
GO

-- Dữ liệu mẫu
INSERT INTO dbo.KhachHang (TenKH, DienThoai, DiaChi) VALUES
(N'Nguyễn Văn Hùng', '0912345678', N'Cầu Giấy, Hà Nội'),
(N'Trần Thị Mai', '0987654321', N'Đống Đa, Hà Nội'),
(N'Lê Quang Vinh', '0905111222', N'Hai Bà Trưng, Hà Nội');

INSERT INTO dbo.Xe (BienSo, MaKH, HieuXe, NamSanXuat) VALUES
('30A-123.45', 1, N'Toyota', 2019),
('29C-567.89', 2, N'Honda', 2021),
('30G-246.80', 3, N'VinFast', 2023),
('30H-135.79', 1, N'Mazda', 2018);

INSERT INTO dbo.PhuTung (TenPhuTung, DonGia, SoLuongTon) VALUES
(N'Dầu động cơ 4L', 850000, 30),
(N'Lọc dầu', 150000, 25),
(N'Lọc gió điều hòa', 220000, 15),
(N'Má phanh trước', 950000, 8),
(N'Bugi', 120000, 40),
(N'Ắc quy 12V 60Ah', 1850000, 2),
(N'Gạt mưa', 180000, 12);

-- Một phiếu đã thanh toán và một phiếu đã sửa xong chờ thanh toán
INSERT INTO dbo.PhieuSuaChua (BienSo, NgayNhan, NoiDungSua, TrangThai) VALUES
('30A-123.45', DATEADD(DAY, -7, GETDATE()), N'Bảo dưỡng định kỳ 20.000 km', N'Đã thanh toán'),
('29C-567.89', DATEADD(DAY, -1, GETDATE()), N'Thay má phanh trước, kiểm tra hệ thống phanh', N'Đã hoàn thành');

INSERT INTO dbo.ChiTietSuaChua (MaPhieu, MaPhuTung, SoLuong, TienCong) VALUES
(1, 1, 1, 100000), (1, 2, 1, 50000),
(2, 4, 1, 300000);

UPDATE p SET TongTien = (SELECT SUM(c.SoLuong * t.DonGia + c.TienCong)
                         FROM dbo.ChiTietSuaChua c JOIN dbo.PhuTung t ON c.MaPhuTung = t.MaPhuTung
                         WHERE c.MaPhieu = p.MaPhieu)
FROM dbo.PhieuSuaChua p;
GO

SELECT * FROM dbo.KhachHang;
SELECT * FROM dbo.Xe;
SELECT * FROM dbo.PhuTung;
SELECT * FROM dbo.PhieuSuaChua;
