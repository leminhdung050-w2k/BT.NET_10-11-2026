-- BÀI 6.5: Hệ thống quản lý đặt phòng & dịch vụ karaoke
IF DB_ID(N'KaraokeDB') IS NULL
    CREATE DATABASE KaraokeDB;
GO

USE KaraokeDB;
GO

IF OBJECT_ID(N'dbo.ChiTietDichVu', N'U') IS NOT NULL DROP TABLE dbo.ChiTietDichVu;
IF OBJECT_ID(N'dbo.HoaDon', N'U') IS NOT NULL DROP TABLE dbo.HoaDon;
IF OBJECT_ID(N'dbo.DichVu', N'U') IS NOT NULL DROP TABLE dbo.DichVu;
IF OBJECT_ID(N'dbo.PhongHat', N'U') IS NOT NULL DROP TABLE dbo.PhongHat;
GO

-- 1. Phòng hát
CREATE TABLE dbo.PhongHat
(
    MaPhong    INT IDENTITY(1,1) PRIMARY KEY,
    TenPhong   NVARCHAR(50) NOT NULL,
    LoaiPhong  NVARCHAR(30) NOT NULL,                       -- VIP / Thường
    GiaTheoGio DECIMAL(18,2) NOT NULL CHECK (GiaTheoGio >= 0),
    TrangThai  NVARCHAR(20) NOT NULL DEFAULT N'Trống'      -- Trống / Đang hát
);

-- 2. Dịch vụ / đồ uống
CREATE TABLE dbo.DichVu
(
    MaDV   INT IDENTITY(1,1) PRIMARY KEY,
    TenDV  NVARCHAR(100) NOT NULL,
    DonGia DECIMAL(18,2) NOT NULL CHECK (DonGia >= 0),
    TonKho INT NOT NULL DEFAULT 0 CHECK (TonKho >= 0)
);

-- 3. Hóa đơn sử dụng
CREATE TABLE dbo.HoaDon
(
    MaHD            INT IDENTITY(1,1) PRIMARY KEY,
    MaPhong         INT NOT NULL REFERENCES dbo.PhongHat(MaPhong),
    GioVao          DATETIME NOT NULL,
    GioRa           DATETIME NULL,
    TongTienPhong   DECIMAL(18,2) NOT NULL DEFAULT 0,
    TongTienDichVu  DECIMAL(18,2) NOT NULL DEFAULT 0,
    TrangThai       BIT NOT NULL DEFAULT 0                  -- 0: chưa thanh toán, 1: đã thanh toán
);

-- 4. Chi tiết dịch vụ gọi
CREATE TABLE dbo.ChiTietDichVu
(
    MaHD    INT NOT NULL REFERENCES dbo.HoaDon(MaHD),
    MaDV    INT NOT NULL REFERENCES dbo.DichVu(MaDV),
    SoLuong INT NOT NULL CHECK (SoLuong > 0),
    DonGia  DECIMAL(18,2) NOT NULL,
    PRIMARY KEY (MaHD, MaDV)
);
GO

-- Dữ liệu mẫu
INSERT INTO dbo.PhongHat (TenPhong, LoaiPhong, GiaTheoGio) VALUES
(N'Phòng VIP 01', N'VIP', 300000), (N'Phòng VIP 02', N'VIP', 300000), (N'Phòng VIP 03', N'VIP', 350000),
(N'Phòng Thường 01', N'Thường', 150000), (N'Phòng Thường 02', N'Thường', 150000), (N'Phòng Thường 03', N'Thường', 150000),
(N'Phòng Thường 04', N'Thường', 150000), (N'Phòng Thường 05', N'Thường', 180000), (N'Phòng Thường 06', N'Thường', 180000);

INSERT INTO dbo.DichVu (TenDV, DonGia, TonKho) VALUES
(N'Bia Heineken', 35000, 120),
(N'Bia Tiger', 30000, 100),
(N'Nước suối', 15000, 200),
(N'Coca-Cola', 20000, 150),
(N'Trái cây dĩa', 150000, 20),
(N'Đậu phộng rang', 40000, 50),
(N'Khăn lạnh', 5000, 3);

-- Phòng VIP 02 và Phòng Thường 03 đang có khách hát
INSERT INTO dbo.HoaDon (MaPhong, GioVao) VALUES
(2, DATEADD(MINUTE, -95, GETDATE())),
(6, DATEADD(MINUTE, -40, GETDATE()));
INSERT INTO dbo.ChiTietDichVu (MaHD, MaDV, SoLuong, DonGia) VALUES
(1, 1, 6, 35000), (1, 5, 1, 150000),
(2, 3, 4, 15000);
UPDATE dbo.PhongHat SET TrangThai = N'Đang hát' WHERE MaPhong IN (2, 6);
GO

SELECT * FROM dbo.PhongHat;
SELECT * FROM dbo.DichVu;
SELECT * FROM dbo.HoaDon;
