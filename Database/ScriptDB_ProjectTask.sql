-- BÀI 6.3: Hệ thống quản lý công việc & tiến độ dự án
IF DB_ID(N'ProjectTaskDB') IS NULL
    CREATE DATABASE ProjectTaskDB;
GO

USE ProjectTaskDB;
GO

IF OBJECT_ID(N'dbo.PhanCong', N'U') IS NOT NULL DROP TABLE dbo.PhanCong;
IF OBJECT_ID(N'dbo.CongViec', N'U') IS NOT NULL DROP TABLE dbo.CongViec;
IF OBJECT_ID(N'dbo.ThanhVien', N'U') IS NOT NULL DROP TABLE dbo.ThanhVien;
IF OBJECT_ID(N'dbo.DuAn', N'U') IS NOT NULL DROP TABLE dbo.DuAn;
GO

-- 1. Dự án
CREATE TABLE dbo.DuAn
(
    MaDuAn      INT IDENTITY(1,1) PRIMARY KEY,
    TenDuAn     NVARCHAR(150) NOT NULL,
    NgayBatDau  DATETIME NULL,
    NgayKetThuc DATETIME NULL,
    TrangThai   NVARCHAR(50) NOT NULL DEFAULT N'Đang chạy'     -- Đang chạy / Hoàn thành / Tạm dừng
);

-- 2. Thành viên nhóm
CREATE TABLE dbo.ThanhVien
(
    MaThanhVien INT IDENTITY(1,1) PRIMARY KEY,
    HoTen       NVARCHAR(100) NOT NULL,
    Email       VARCHAR(100) NULL UNIQUE,
    ChuyenMon   NVARCHAR(100) NULL
);

-- 3. Công việc / Task
CREATE TABLE dbo.CongViec
(
    MaTask    INT IDENTITY(1,1) PRIMARY KEY,
    MaDuAn    INT NOT NULL REFERENCES dbo.DuAn(MaDuAn),
    TenTask   NVARCHAR(200) NOT NULL,
    MoTa      NVARCHAR(MAX) NULL,
    HanNop    DATETIME NULL,
    DoUuTien  NVARCHAR(20) NOT NULL DEFAULT N'Trung bình',     -- Cao / Trung bình / Thấp
    TrangThai NVARCHAR(50) NOT NULL DEFAULT 'To Do'            -- To Do / In Progress / Review / Done
);

-- 4. Phân công công việc
CREATE TABLE dbo.PhanCong
(
    MaTask      INT NOT NULL REFERENCES dbo.CongViec(MaTask),
    MaThanhVien INT NOT NULL REFERENCES dbo.ThanhVien(MaThanhVien),
    NgayGiao    DATETIME NOT NULL DEFAULT GETDATE(),
    PRIMARY KEY (MaTask, MaThanhVien)
);
GO

-- Dữ liệu mẫu
INSERT INTO dbo.DuAn (TenDuAn, NgayBatDau, NgayKetThuc, TrangThai) VALUES
(N'Website bán hàng online', DATEADD(DAY, -30, GETDATE()), DATEADD(DAY, 30, GETDATE()), N'Đang chạy'),
(N'App quản lý thư viện', DATEADD(DAY, -15, GETDATE()), DATEADD(DAY, 45, GETDATE()), N'Đang chạy'),
(N'Hệ thống chấm công', DATEADD(DAY, -90, GETDATE()), DATEADD(DAY, -10, GETDATE()), N'Hoàn thành');

INSERT INTO dbo.ThanhVien (HoTen, Email, ChuyenMon) VALUES
(N'Lê Minh Dũng', 'dung.le@team.vn', N'Backend'),
(N'Trần Thị Bình', 'binh.tran@team.vn', N'Frontend'),
(N'Lê Hoàng Cường', 'cuong.le@team.vn', N'Database'),
(N'Phạm Thu Dung', 'dung.pham@team.vn', N'Tester'),
(N'Hoàng Minh Đức', 'duc.hoang@team.vn', N'UI/UX');

INSERT INTO dbo.CongViec (MaDuAn, TenTask, MoTa, HanNop, DoUuTien, TrangThai) VALUES
(1, N'Phân tích yêu cầu', N'Thu thập yêu cầu khách hàng', DATEADD(DAY, -20, GETDATE()), N'Cao', 'Done'),
(1, N'Thiết kế CSDL', N'Thiết kế bảng sản phẩm, đơn hàng', DATEADD(DAY, -12, GETDATE()), N'Cao', 'Done'),
(1, N'Thiết kế giao diện trang chủ', N'Mockup trang chủ và trang sản phẩm', DATEADD(DAY, -3, GETDATE()), N'Trung bình', 'In Progress'),
(1, N'Xây dựng API giỏ hàng', N'Thêm, sửa, xóa sản phẩm trong giỏ', DATEADD(DAY, -1, GETDATE()), N'Cao', 'In Progress'),
(1, N'Tích hợp thanh toán', N'Kết nối cổng thanh toán', DATEADD(DAY, 10, GETDATE()), N'Cao', 'To Do'),
(1, N'Kiểm thử chức năng đặt hàng', N'Viết test case đặt hàng', DATEADD(DAY, 15, GETDATE()), N'Trung bình', 'To Do'),
(1, N'Review code module sản phẩm', N'Review và góp ý code', DATEADD(DAY, 2, GETDATE()), N'Thấp', 'Review'),
(2, N'Khảo sát nghiệp vụ thư viện', NULL, DATEADD(DAY, -5, GETDATE()), N'Trung bình', 'Done'),
(2, N'Thiết kế màn hình mượn trả', NULL, DATEADD(DAY, -2, GETDATE()), N'Cao', 'To Do'),
(2, N'Xây dựng chức năng tìm sách', NULL, DATEADD(DAY, 7, GETDATE()), N'Trung bình', 'In Progress'),
(3, N'Triển khai hệ thống', NULL, DATEADD(DAY, -15, GETDATE()), N'Cao', 'Done'),
(3, N'Đào tạo người dùng', NULL, DATEADD(DAY, -11, GETDATE()), N'Thấp', 'Done');

INSERT INTO dbo.PhanCong (MaTask, MaThanhVien) VALUES
(1, 1), (1, 3), (2, 3), (3, 2), (3, 5), (4, 1), (5, 1), (6, 4), (7, 3), (7, 4),
(8, 2), (9, 5), (10, 1), (10, 2), (11, 3), (12, 4);
GO

SELECT * FROM dbo.DuAn;
SELECT * FROM dbo.ThanhVien;
SELECT * FROM dbo.CongViec;
