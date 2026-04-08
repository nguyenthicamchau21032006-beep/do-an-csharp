USE master; 
GO
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'QuanLyVangBac')
BEGIN
    ALTER DATABASE QuanLyVangBac SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
    DROP DATABASE QuanLyVangBac;
END
GO
CREATE DATABASE QuanLyVangBac;
GO
USE QuanLyVangBac;
GO
IF OBJECT_ID('NguoiDung', 'U') IS NOT NULL DROP TABLE NguoiDung;
CREATE TABLE NguoiDung (
    ID INT PRIMARY KEY IDENTITY(1,1),
    MaNV AS ('NV' + RIGHT('000' + CAST(ID AS VARCHAR(3)), 3)) PERSISTED, 
    TenDangNhap VARCHAR(50) UNIQUE NOT NULL, 
    MatKhau VARCHAR(50) NOT NULL,
    HoTen NVARCHAR(100) NOT NULL, 
    Quyen NVARCHAR(20) NOT NULL,
    TrangThai NVARCHAR(20) DEFAULT N'Đang làm việc '
);
GO
ALTER TABLE NguoiDung ADD 
    SDT VARCHAR(15),
    CCCD VARCHAR(20),
    QueQuan NVARCHAR(100),
    NgaySinh DATE;
GO

-- TAO BANG LUONG
IF OBJECT_ID('BangLuong', 'U') IS NOT NULL DROP TABLE BangLuong;
GO
CREATE TABLE BangLuong (
    MaLuong VARCHAR(20) PRIMARY KEY, 
    MaNV VARCHAR(10),
    ChucVu NVARCHAR(50),           
    ChucDanh NVARCHAR(50),          
    LuongCoBan DECIMAL(18, 0),       
    PCChucVu DECIMAL(18, 0),         
    NgayNhap DATE,                   
    LuongCBMoi DECIMAL(18, 0),       
    NgaySua DATE,                    
    LyDo NVARCHAR(255),              
    PCCVuMoi DECIMAL(18, 0),         
    NgaySuaPC DATE,                  
    GhiChu NVARCHAR(255)           
);
GO
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen) 
VALUES ('admin', '123', N'Nguyễn Hoàng Gia Bảo ', 'Admin');
-- 2. Danh sách 50 NHÂN VIÊN
INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen) VALUES 
('nv1', '123', N'Trần Minh Tâm', 'NhanVien'),
('nv2', '123', N'Lê Thanh Trúc', 'NhanVien'),
('nv3', '123', N'Phạm Hồng Phương', 'NhanVien'),
('nv4', '123', N'Nguyễn Bích Thùy', 'NhanVien'),
('nv5', '123', N'Vĩnh Bình Phong', 'NhanVien'),
('nv6', '123', N'Hoàng Thúy Vy', 'NhanVien'),
('nv7', '123', N'Ngô Anh Tuấn', 'NhanVien'),
('nv8', '123', N'Ngô Thanh Vân', 'NhanVien'),
('nv9', '123', N'Bùi Tiến Dũng', 'NhanVien'),
('nv10', '123', N'Lý Nhã Kỳ', 'NhanVien'),
('nv11', '123', N'Phong Vân Lâm', 'NhanVien'),
('nv12', '123', N'Trịnh Kim Chi', 'NhanVien'),
('nv13', '123', N'Mai Phương Thúy', 'NhanVien'),
('nv14', '123', N'Toàn Văn Hữu', 'NhanVien'),
('nv15', '123', N'Võ Hoàng Yến', 'NhanVien'),
('nv16', '123', N'Phan Mạnh Quỳnh', 'NhanVien'),
('nv17', '123', N'Hà Anh Tuấn', 'NhanVien'),
('nv18', '123', N'Trương Mỹ Lan', 'NhanVien'),
('nv19', '123', N'Nguyễn Quang Hải', 'NhanVien'),
('nv20', '123', N'Tô Hữu Bằng', 'NhanVien'),
('nv21', '123', N'Lâm Tâm Như', 'NhanVien'),
('nv22', '123', N'Quách Ngọc Ngoan', 'NhanVien'),
('nv23', '123', N'Dương Mịch', 'NhanVien'),
('nv24', '123', N'Triệu Lệ Dĩnh', 'NhanVien'),
('nv25', '123', N'Lưu Diệc Phi', 'NhanVien'),
('nv26', '123', N'Thái Y Lâm', 'NhanVien'),
('nv27', '123', N'Hà Văn Mẫn', 'NhanVien'),
('nv28', '123', N'Bành Vu Yến', 'NhanVien'),
('nv29', '123', N'Chu Thiên Lạc', 'NhanVien'),
('nv30', '123', N'Thanh Bình Phong', 'NhanVien'),
('nv31', '123', N'Nguyễn Công Phượng', 'NhanVien'),
('nv32', '123', N'Phan Văn Trị', 'NhanVien'),
('nv33', '123', N'Lương Xuân Trường', 'NhanVien'),
('nv34', '123', N'Nguyễn Hùng Dũng', 'NhanVien'),
('nv35', '123', N'Nguyễn Văn Toàn', 'NhanVien'),
('nv36', '123', N'Trịnh Đình Trọng', 'NhanVien'),
('nv37', '123', N'Bùi Tiến Dụng', 'NhanVien'),
('nv38', '123', N'Nguyễn Phong Hồng Duy', 'NhanVien'),
('nv39', '123', N'Hà Ngọc Trinh', 'NhanVien'),
('nv40', '123', N'Nguyễn Thành Chung', 'NhanVien'),
('nv41', '123', N'Phạm Ngọc Huy', 'NhanVien'),
('nv42', '123', N'Nguyễn Trường Hoàng', 'NhanVien'),
('nv43', '123', N'Quách Ngọc Hiển', 'NhanVien'),
('nv44', '123', N'Nguyễn Tuấn Anh', 'NhanVien'),
('nv45', '123', N'Lê Nguyễn Thanh Thảo', 'NhanVien'),
('nv46', '123', N'Lê Minh Tuấn', 'NhanVien'),
('nv47', '123', N'Nguyễn Hữu Thắng', 'NhanVien'),
('nv48', '123', N'Võ Nguyên Giáp', 'NhanVien'),
('nv49', '123', N'Phan Thiên Long', 'NhanVien'),
('nv50', '123', N'Lê Ngọc Thùy Vy', 'NhanVien');
GO
CREATE OR ALTER PROCEDURE sp_kiemtralogin
    @User VARCHAR(50),
    @Pass VARCHAR(50)
AS
BEGIN
    -- Kiem tra xem Ten nguoi nhap có ten toi khong
    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @User)
    BEGIN
        SELECT 0 AS Code, N'Tên đăng nhập không tồn tại!' AS ThongBao;
    END
    ELSE IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @User AND MatKhau = @Pass)
    BEGIN
        SELECT 1 AS Code, N'Mật khẩu không chính xác!' AS ThongBao;
    END
    ELSE
    BEGIN
        SELECT 2 AS Code, N'Đăng nhập thành công' AS ThongBao, MaNV, HoTen, Quyen 
        FROM NguoiDung 
        WHERE TenDangNhap = @User AND MatKhau = @Pass;
    END
END
GO

-- 2. CONG KY
CREATE OR ALTER PROCEDURE sp_DangKyNhanVien
    @User VARCHAR(50),
    @Pass VARCHAR(50),
    @Name NVARCHAR(100),
    @Role NVARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @User)
    BEGIN
        SELECT 0 AS Code, N'Tên đăng nhập này đã có người dùng!' AS ThongBao;
    END
    ELSE
    BEGIN
        INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen)
        VALUES (@User, @Pass, @Name, @Role);
        SELECT 1 AS Code, N'Đăng ký thành công!' AS ThongBao;
    END
END
GO
-- 3. CONG XOA
CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaXoa VARCHAR(10)
AS
BEGIN
    DELETE FROM NguoiDung 
    WHERE MaNV = @MaXoa AND Quyen <> 'Admin';
END
GO
-- 4. CONG DOI MAT KHAU
CREATE OR ALTER PROCEDURE sp_DoiMatKhau
    @User VARCHAR(50),
    @PassCu VARCHAR(50),
    @PassMoi VARCHAR(50)
AS
BEGIN
    -- 1. Kiem tra mat khau co khop khong
    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @User AND MatKhau = @PassCu)
    BEGIN
        SELECT 0 AS Code, N'Mat khau khong chinh xac!' AS ThongBao;
    END
    ELSE
    BEGIN
        -- 2. Neu khong hop thì tien hanh cap nhat mat khau moi
        UPDATE NguoiDung 
        SET MatKhau = @PassMoi 
        WHERE TenDangNhap = @User;

        SELECT 1 AS Code, N'Doi mat khau thanh cong !' AS ThongBao;
    END
END
GO
-- 5. CONG LAY DANH SaCH 
CREATE OR ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SELECT MaNV, HoTen, TenDangNhap, Quyen, TrangThai 
    FROM NguoiDung
    ORDER BY ID DESC; 
END
GO
-- 6. CONG SUA THONG TIN 
CREATE OR ALTER PROCEDURE sp_SuaNhanVien
    @MaNV VARCHAR(10),        
    @HoTen NVARCHAR(100),
    @Quyen NVARCHAR(20),
    @TrangThai NVARCHAR(20)
AS
BEGIN

    -- Kiem tra xem ma nhan viên có ton tai khong
    IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE MaNV = @MaNV)
    BEGIN
        SELECT 0 AS Code, N'Không tìm thấy nhân viên này!' AS ThongBao;
    END
    ELSE
    BEGIN
        -- cap nhat thong tin moi
        UPDATE NguoiDung
        SET HoTen = @HoTen,
            Quyen = @Quyen,
            TrangThai = @TrangThai
        WHERE MaNV = @MaNV;

        SELECT 1 AS Code, N'Cập nhật thông tin thành công!' AS ThongBao;
    END
END
GO
IF OBJECT_ID('LoaiVang', 'U') IS NOT NULL DROP TABLE LoaiVang;
GO
CREATE TABLE LoaiVang (
    MaLoai INT PRIMARY KEY IDENTITY(1,1),
    TenLoai NVARCHAR(50) NOT NULL,
    GiaMuaVao DECIMAL(18, 0),
    GiaBanRa DECIMAL(18, 0)
);
GO
CREATE TABLE SanPham (
    ID INT IDENTITY(1,1) PRIMARY KEY,
    MaSP AS ('SP' + RIGHT('000' + CAST(ID AS VARCHAR(3)), 3)) PERSISTED,
    TenSP NVARCHAR(100) NOT NULL,
    MaLoai INT FOREIGN KEY REFERENCES LoaiVang(MaLoai),
    TrongLuong FLOAT,
    TienCong DECIMAL(18, 0),
    SoLuongTon INT DEFAULT 0
);
GO
INSERT INTO LoaiVang (TenLoai, GiaMuaVao, GiaBanRa) VALUES 
(N'Vàng SJC', 7500000, 8200000),  
(N'Vàng 24K', 7300000, 7600000),   
(N'Vàng 18K', 5200000, 5600000), 
(N'Vàng Trắng Ý', 5300000, 5700000),
(N'Bạc 925', 100000, 150000),     
(N'Vàng 10K', 2500000, 3000000);
--- NHÓM VÀNG MIẾNG & VÀNG NHẪN (MaLoai 1, 2)
INSERT INTO SanPham (TenSP, MaLoai, TrongLuong, TienCong, SoLuongTon) VALUES 
(N'Vàng Miếng SJC 1 Lượng', 1, 10.0, 0, 10),
(N'Vàng Miếng SJC 5 Chỉ', 1, 5.0, 0, 15),
(N'Vàng Miếng SJC 2 Chỉ', 1, 2.0, 0, 20),
(N'Vàng Miếng SJC 1 Chỉ', 1, 1.0, 0, 30),
(N'Nhẫn Trơn 24K 1 Chỉ', 2, 1.0, 150000, 50),
(N'Nhẫn Trơn 24K 2 Chỉ', 2, 2.0, 200000, 40),
(N'Nhẫn Trơn 24K 5 Phân', 2, 0.5, 100000, 60),
(N'Nhẫn Kim Tiền 24K', 2, 1.0, 450000, 25),

-- NHÓM VÀNG TÂY 18K (MaLoai 3)
(N'Nhẫn Nam Rồng Phượng 18K', 3, 3.5, 1200000, 12),
(N'Dây Chuyền Nữ Mắt Xích 18K', 3, 2.2, 850000, 18),
(N'Lắc Tay Nữ Cỏ 4 Lá 18K', 3, 1.8, 700000, 22),
(N'Bông Tai Nữ Đá Ruby 18K', 3, 0.5, 550000, 15),
(N'Mặt Dây Chuyền Tỳ Hưu 18K', 3, 1.2, 900000, 10),
(N'Nhẫn Cưới Kim Cương 18K', 3, 1.5, 3500000, 8),
(N'Vòng Tay Bản Lớn 18K', 3, 5.0, 2500000, 5),
(N'Kiềng Cổ Kết Hoa 18K', 3, 8.0, 4000000, 3),

-- NHÓM VÀNG TRẮNG 750 (MaLoai 4)
(N'Nhẫn Kim Cương Moissanite', 4, 0.8, 5000000, 7),
(N'Dây Chuyền Ý 750', 4, 2.0, 1100000, 20),
(N'Lắc Tay Đính Đá Sapphire', 4, 3.2, 6500000, 4),
(N'Bông Tai Dài White Gold', 4, 0.6, 1200000, 12),
(N'Nhẫn Nam Blue Topaz', 4, 4.0, 2800000, 6),
(N'Mặt Dây Chuyền Ngọc Trai', 4, 0.4, 1500000, 9),
(N'Vòng Tay Khảm Đá Quý', 4, 4.5, 7000000, 3),
(N'Nhẫn Đính Hôn Solitaire', 4, 1.0, 4500000, 10),

-- NHÓM BẠC 925 (MaLoai 5)
(N'Dây Chuyền Bạc Trái Tim', 5, 1.5, 150000, 45),
(N'Nhẫn Bạc Đính Đá CZ', 5, 0.5, 120000, 100),
(N'Lắc Chân Bạc Chuông Nhỏ', 5, 0.8, 100000, 55),
(N'Bông Tai Bạc Tròn', 5, 0.3, 80000, 80),
(N'Vòng Tay Bạc Charm', 5, 2.5, 350000, 35),
(N'Nhẫn Bạc Đôi Tình Nhân', 5, 1.2, 250000, 40),
(N'Mặt Dây Chuyền Cung Hoàng Đạo', 5, 0.4, 100000, 65),
(N'Lắc Tay Bạc Trẻ Em', 5, 0.7, 90000, 70),

-- NHÓM VÀNG NON 10K (MaLoai 6)
(N'Nhẫn Nam Khắc Chữ 10K', 6, 2.0, 600000, 20),
(N'Dây Chuyền Mảnh 10K', 6, 1.5, 450000, 25),
(N'Lắc Tay Xích 10K', 6, 3.0, 800000, 15),
(N'Bông Tai Nữ Đá Trắng 10K', 6, 0.4, 300000, 30),
(N'Nhẫn Nữ Đính Đá Màu 10K', 6, 0.8, 550000, 28),
(N'Mặt Dây Chuyền Thánh Giá 10K', 6, 1.0, 400000, 18),
(N'Vòng Tay Bi 10K', 6, 2.5, 900000, 12),
(N'Nhẫn Đồng Tiền May Mắn 10K', 6, 1.2, 500000, 22),

-- CÁC MẪU CAO CẤP KHÁC
(N'Bộ Trang Sức Cưới Rồng Phượng', 3, 15.0, 8000000, 2),
(N'Nhẫn Kim Cương GIA 5ly', 4, 1.2, 15000000, 2),
(N'Dây Chuyền Vàng Ý 18K Kép', 3, 4.5, 1800000, 10),
(N'Lắc Tay Vàng Trắng Full Đá', 4, 5.5, 12000000, 3),
(N'Mặt Phật Bản Mệnh Bọc Vàng', 2, 2.5, 2500000, 6),
(N'Nhẫn Nam Mặt Hổ Vàng 24K', 2, 5.0, 1500000, 4),
(N'Bông Tai Kim Cương Tấm', 4, 0.5, 6000000, 5),
(N'Dây Chuyền Nam Cuban 10K', 6, 8.0, 2000000, 7),
(N'Nhẫn Nữ Ngọc Lục Bảo 18K', 3, 1.5, 9500000, 3),
(N'Kiềng Bạc Chạm Trổ', 5, 3.0, 450000, 15);
GO

CREATE PROCEDURE sp_LayDanhSachKho
AS
BEGIN
    SELECT 
        S.MaSP, 
        S.TenSP, 
        L.TenLoai, 
        S.TrongLuong,
        S.SoLuongTon,
        FORMAT((S.TrongLuong * (L.GiaBanRa / 10)) + S.TienCong, 'N0') AS GiaBanHienTai
    FROM SanPham S
    JOIN LoaiVang L ON S.MaLoai = L.MaLoai;
END
GO
-- 1. BANG HOA DON
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV VARCHAR(10),
    TongTien DECIMAL(18, 0),
    GhiChu NVARCHAR(200)
);
GO

-- 2. BANGCHITIETHOADON
CREATE TABLE ChiTietHoaDon (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP VARCHAR(10),
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien AS (SoLuong * DonGia)
);
GO

CREATE PROCEDURE sp_TaoHoaDon
    @MaNV VARCHAR(10),
    @TongTien DECIMAL(18, 0),
    @GhiChu NVARCHAR(200)
AS
BEGIN
    INSERT INTO HoaDon (MaNV, TongTien, GhiChu)
    VALUES (@MaNV, @TongTien, @GhiChu);
   
    SELECT SCOPE_IDENTITY() AS NewMaHD;
END
GO

-- 4. THU TUC THEM MON HANG VAO DON & TU TRU KHO
CREATE PROCEDURE sp_ThemChiTietHD
    @MaHD INT,
    @MaSP VARCHAR(10),
    @SoLuong INT,
    @DonGia DECIMAL(18, 0)
AS
BEGIN
    -- luu chi tiet
    INSERT INTO ChiTietHoaDon (MaHD, MaSP, SoLuong, DonGia)
    VALUES (@MaHD, @MaSP, @SoLuong, @DonGia);
    
    -- tu dong tru so luong san pham trong kho
    UPDATE SanPham 
    SET SoLuongTon = SoLuongTon - @SoLuong 
    WHERE MaSP = @MaSP;
END
GO

-- 5. THU TUC XEM LAI LICH SU BAN HANG
CREATE PROCEDURE sp_LayLichSuBanHang
AS
BEGIN
    SELECT 
        H.MaHD, 
        H.NgayLap, 
        N.HoTen AS NhanVienBan, 
        FORMAT(H.TongTien, 'N0') AS TongTien, 
        H.GhiChu
    FROM HoaDon H
    JOIN NguoiDung N ON H.MaNV = N.MaNV
    ORDER BY H.NgayLap DESC;
END
GO
-- 1. BANG PHIEU THU MUA (Tiệm mua vàng của khách)
CREATE TABLE PhieuThuMua (
    MaPTM INT PRIMARY KEY IDENTITY(1,1),
    NgayThu DATETIME DEFAULT GETDATE(),
    MaNV VARCHAR(10),
    TenKhachHang NVARCHAR(100), -- Để biết ai bán cho mình
    SDTKhachHang VARCHAR(15),
    TongTienTra DECIMAL(18, 0), -- Tiền tiệm phải trả cho khách
    GhiChu NVARCHAR(200)
);

-- 2. CHI TIET THU MUA (Khách bán món gì)
CREATE TABLE ChiTietThuMua (
    MaPTM INT FOREIGN KEY REFERENCES PhieuThuMua(MaPTM),
    TenMonHang NVARCHAR(100), -- Có thể là vàng miếng, nhẫn cũ, gãy...
    LoaiVang INT FOREIGN KEY REFERENCES LoaiVang(MaLoai),
    TrongLuong FLOAT,
    DonGiaMua DECIMAL(18, 0), -- Giá mua vào tại thời điểm đó
    ThanhTien AS (TrongLuong * DonGiaMua)
);
GO
CREATE OR ALTER PROCEDURE sp_BaoCaoTaiChinhNgay
    @Ngay DATE
AS
BEGIN
    DECLARE @TongBan DECIMAL(18,0), @TongMua DECIMAL(18,0);

    -- Tính tổng tiền bán ra trong ngày
    SELECT @TongBan = ISNULL(SUM(TongTien), 0) FROM HoaDon WHERE CAST(NgayLap AS DATE) = @Ngay;

    -- Tính tổng tiền thu mua vào trong ngày
    SELECT @TongMua = ISNULL(SUM(TongTienTra), 0) FROM PhieuThuMua WHERE CAST(NgayThu AS DATE) = @Ngay;

    -- Xuất kết quả
    SELECT 
        @TongBan AS DoanhThuBan,
        @TongMua AS ChiPhiThuMua,
        (@TongBan - @TongMua) AS LoiNhuanRong;
END
GO
-- 1. Tạo bảng Khách Hàng
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
GO
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) UNIQUE, 
    DiaChi NVARCHAR(200),
    GioiTinh NVARCHAR(10),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- 2. Nạp dữ liệu giả để test Form C#
INSERT INTO KhachHang (TenKH, SDT, DiaChi, GioiTinh) VALUES 
(N'Nguyễn Hoàng Gia Bảo', '0901234567', N'Quận 1, TP.HCM', N'Nam'),
(N'Lê Thị Thanh Trúc', '0911222333', N'Bình Thạnh, TP.HCM', N'Nữ'),
(N'Trần Minh Tâm', '0988777666', N'Thủ Đức, TP.HCM', N'Nam'),
(N'Phạm Thu Thảo', '0344555666', N'Quận 7, TP.HCM', N'Nữ'),
(N'Hoàng Văn Nam', '0900111222', N'Quận 3, TP.HCM', N'Nam'),
(N'Đặng Minh Hằng', '0933445566', N'Phú Nhuận, TP.HCM', N'Nữ'),
(N'Bùi Anh Tuấn', '0888999000', N'Tân Bình, TP.HCM', N'Nam'),
(N'Võ Hoàng Yến', '0944555666', N'Quận 10, TP.HCM', N'Nữ'),
(N'Trịnh Kim Chi', '0922111000', N'Quận 5, TP.HCM', N'Nữ'),
(N'Mai Văn Phấn', '0900999888', N'Hóc Môn, TP.HCM', N'Nam');

GO
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
GO
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) UNIQUE, 
    DiaChi NVARCHAR(200),
    GioiTinh NVARCHAR(10),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
GO
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV VARCHAR(10),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH), -- Them vao day
    TongTien DECIMAL(18, 0),
    GhiChu NVARCHAR(200)
);
GO

CREATE TABLE ChiTietHoaDon (
    MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP VARCHAR(10),
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien AS (SoLuong * DonGia)
);
GO
-- Lay danh sach
CREATE OR ALTER PROCEDURE sp_LayDanhSachKhachHang
AS
BEGIN
    SELECT * FROM KhachHang ORDER BY MaKH DESC;
END
GO

-- Luu (Them/Sua)
CREATE OR ALTER PROCEDURE sp_LuuKhachHang
    @MaKH INT = 0,
    @Ten NVARCHAR(100),
    @Sdt VARCHAR(15),
    @DiaChi NVARCHAR(200),
    @GioiTinh NVARCHAR(10)
AS
BEGIN
    IF @MaKH = 0
        INSERT INTO KhachHang (TenKH, SDT, DiaChi, GioiTinh) VALUES (@Ten, @Sdt, @DiaChi, @GioiTinh);
    ELSE
        UPDATE KhachHang SET TenKH = @Ten, SDT = @Sdt, DiaChi = @DiaChi, GioiTinh = @GioiTinh WHERE MaKH = @MaKH;
END
GO

-- Xoa (Bay gio het loi vi da co cot MaKH trong HoaDon)
CREATE OR ALTER PROCEDURE sp_XoaKhachHang
    @MaKH INT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM HoaDon WHERE MaKH = @MaKH)
        SELECT 0 AS Code, N'Khách đã có hóa đơn, không thể xóa!' AS ThongBao;
    ELSE
    BEGIN
        DELETE FROM KhachHang WHERE MaKH = @MaKH;
        SELECT 1 AS Code, N'Xóa thành công!' AS ThongBao;
    END
END
GO

-- Tim kiem
CREATE OR ALTER PROCEDURE sp_TimKiemKhachHang
    @Search NVARCHAR(100)
AS
BEGIN
    SELECT * FROM KhachHang 
    WHERE TenKH LIKE '%' + @Search + '%' OR SDT LIKE '%' + @Search + '%'
END
GO
-- 1. BẢO ĐẢM ĐỦ 10 CỘT TRƯỚC KHI CHẠY STORE

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'SDT') ALTER TABLE NguoiDung ADD SDT VARCHAR(15);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'CCCD') ALTER TABLE NguoiDung ADD CCCD VARCHAR(20);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'QueQuan') ALTER TABLE NguoiDung ADD QueQuan NVARCHAR(100);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'Email') ALTER TABLE NguoiDung ADD Email VARCHAR(100);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'GioiTinh') ALTER TABLE NguoiDung ADD GioiTinh NVARCHAR(10);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'CaLam') ALTER TABLE NguoiDung ADD CaLam NVARCHAR(50);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'NgaySinh') ALTER TABLE NguoiDung ADD NgaySinh DATE;
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'NgayVaoLam') ALTER TABLE NguoiDung ADD NgayVaoLam DATE DEFAULT GETDATE();
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'Quyen') ALTER TABLE NguoiDung ADD Quyen NVARCHAR(20);
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('NguoiDung') AND name = 'TrangThai') ALTER TABLE NguoiDung ADD TrangThai NVARCHAR(20) DEFAULT N'Đang làm việc';
GO

-- 2. STORE THÊM NHÂN VIÊN 

CREATE OR ALTER PROCEDURE sp_ThemNhanVien
    @TenDangNhap VARCHAR(50), @MatKhau VARCHAR(50), @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10), @NgaySinh DATE, @SDT VARCHAR(15),
    @CCCD VARCHAR(20), @Email VARCHAR(100), @QueQuan NVARCHAR(100),
    @CaLam NVARCHAR(50), @NgayVaoLam DATE, @Quyen NVARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @TenDangNhap)
        SELECT 0 AS Code, N'Tên đăng nhập đã tồn tại!' AS ThongBao;
    ELSE
    BEGIN
        INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, SDT, CCCD, Email, QueQuan, CaLam, NgayVaoLam, Quyen, TrangThai)
        VALUES (@TenDangNhap, @MatKhau, @HoTen, @GioiTinh, @NgaySinh, @SDT, @CCCD, @Email, @QueQuan, @CaLam, @NgayVaoLam, @Quyen, N'Đang làm việc');
        SELECT 1 AS Code, N'Thêm thành công!' AS ThongBao;
    END
END
GO

-- 3. STORE SỬA NHÂN VIÊN (DÙNG CHO C#)

CREATE OR ALTER PROCEDURE sp_SuaNhanVien
    @MaNV VARCHAR(10), @HoTen NVARCHAR(100), @GioiTinh NVARCHAR(10),
    @NgaySinh DATE, @SDT VARCHAR(15), @CCCD VARCHAR(20),
    @Email VARCHAR(100), @QueQuan NVARCHAR(100), @CaLam NVARCHAR(50),
    @NgayVaoLam DATE, @Quyen NVARCHAR(20), @TrangThai NVARCHAR(20)
AS
BEGIN
    -- BƯỚC 1: KIỂM TRA LOGIC NGÀY THÁNG
    IF (@NgaySinh >= @NgayVaoLam)
    BEGIN
        SELECT 0 AS Code, N'Lỗi: Ngày sinh phải trước ngày vào làm!' AS ThongBao;
        RETURN; -- Dừng luôn không cho Update
    END

    -- BƯỚC 2: TIẾN HÀNH CẬP NHẬT
    UPDATE NguoiDung
    SET HoTen = @HoTen, 
        GioiTinh = @GioiTinh, 
        NgaySinh = @NgaySinh, 
        SDT = @SDT, 
        CCCD = @CCCD, 
        Email = @Email, 
        QueQuan = @QueQuan, 
        CaLam = @CaLam, 
        NgayVaoLam = @NgayVaoLam, 
        Quyen = @Quyen, 
        TrangThai = @TrangThai
    WHERE MaNV = @MaNV;

    IF @@ROWCOUNT > 0 
        SELECT 1 AS Code, N'Cập nhật thành công!' AS ThongBao;
    ELSE 
        SELECT 0 AS Code, N'Lỗi: Không tìm thấy Mã NV để cập nhật!' AS ThongBao;
END
GO


CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaXoa VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NguoiDung WHERE MaNV = @MaXoa AND Quyen = 'Admin')
        SELECT 0 AS Code, N'Không thể xóa tài khoản Admin!' AS ThongBao;
    ELSE
    BEGIN
        DELETE FROM NguoiDung WHERE MaNV = @MaXoa;
        SELECT 1 AS Code, N'Đã xóa thành công!' AS ThongBao;
    END
END
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachNhanVien
AS
BEGIN
    SELECT MaNV, HoTen, GioiTinh, NgaySinh, SDT, CCCD, Email, QueQuan, CaLam, NgayVaoLam, Quyen, TrangThai, TenDangNhap
    FROM NguoiDung ORDER BY ID DESC;
END
GO

UPDATE NguoiDung
SET 
    NgaySinh = DATEADD(MONTH, (ID * 4), '1990-01-01'),
    NgayVaoLam = DATEADD(DAY, (ID * 20), '2021-01-01'),
    SDT = '09' + RIGHT('00000000' + CAST(ID * 888 AS VARCHAR(8)), 8),
    CCCD = '079' + RIGHT('000000000' + CAST(ID * 999 AS VARCHAR(9)), 9),
    Email = 'nv' + CAST(ID AS VARCHAR) + '@tiemvang.com',
    QueQuan = CASE WHEN ID % 2 = 0 THEN N'TP. Hồ Chí Minh' ELSE N'Hà Nội' END,
    GioiTinh = CASE WHEN ID % 2 = 0 THEN N'Nam' ELSE N'Nữ' END,
    CaLam = CASE WHEN ID % 3 = 0 THEN N'Ca Sáng' WHEN ID % 3 = 1 THEN N'Ca Chiều' ELSE N'Ca Tối' END,
    TrangThai = N'Đang làm việc'; 
GO

EXEC sp_LayDanhSachNhanVien;
GO

UPDATE NguoiDung
SET 
    NgaySinh = DATEADD(MONTH, -(ID * 4), '2004-01-01'), 
    NgayVaoLam = DATEADD(DAY, (ID * 15), '2022-01-01'), 
    Email = 'nv' + CAST(ID AS VARCHAR) + '@tiemvang.com',
    QueQuan = CASE WHEN ID % 2 = 0 THEN N'TP. Hồ Chí Minh' ELSE N'Hà Nội' END,
    GioiTinh = CASE WHEN ID % 2 = 0 THEN N'Nam' ELSE N'Nữ' END,
    CaLam = CASE WHEN ID % 3 = 0 THEN N'Ca Sáng' WHEN ID % 3 = 1 THEN N'Ca Chiều' ELSE N'Ca Tối' END
WHERE MaNV IS NOT NULL;
GO
IF NOT EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = 'admin')
BEGIN
    INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, Quyen, TrangThai)
    VALUES ('admin', 'admin2806', N'Nguyễn Hoàng Gia Bảo', 'Admin', N'Đang làm việc');
END
GO

-- Cập nhật thông tin chi tiết cho Admin
UPDATE NguoiDung
SET 
    SDT = '0900000888',          -- Để khớp với số em nhập trên Form
    Email = 'nv1@tiemvang.com',  -- Để khớp với email em nhập trên Form
    QueQuan = N'Hà Nội',
    GioiTinh = N'Nam',
    NgaySinh = '1990-05-01',
    TenDangNhap = 'admin',       -- Ghi đè lại để mất dấu cách thừa
    MatKhau = '2806'             -- Đặt lại mật khẩu theo ý em
WHERE MaNV = 'NV001';            -- Dùng mã nhân viên là chính xác nhất
GO

-- Xóa khoảng trắng thừa cho toàn bộ bảng để sau này không bị lỗi khôi phục nữa
UPDATE NguoiDung
SET 
    TenDangNhap = RTRIM(LTRIM(TenDangNhap)),
    Email = RTRIM(LTRIM(Email)),
    SDT = RTRIM(LTRIM(SDT));
GO
-- Thêm cột vào ChiTietHoaDon để lưu thông tin lúc bán
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTietHoaDon') AND name = 'TrongLuong')
    ALTER TABLE ChiTietHoaDon ADD TrongLuong FLOAT, DonGiaVang DECIMAL(18,0), TienCongBan DECIMAL(18,0);

-- Thêm MaKH vào HoaDon để biết ai mua
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDon') AND name = 'MaKH')
    ALTER TABLE HoaDon ADD MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH);
GO

-- 2. STORE: LƯU KHÁCH HÀNG (MỚI THÌ THÊM, CŨ THÌ CẬP NHẬT)

CREATE OR ALTER PROCEDURE sp_LuuKhachHangTuDong
    @TenKH NVARCHAR(100),
    @SDT VARCHAR(15),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KhachHang WHERE SDT = @SDT)
    BEGIN
        UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi WHERE SDT = @SDT;
        SELECT MaKH FROM KhachHang WHERE SDT = @SDT;
    END
    ELSE
    BEGIN
        INSERT INTO KhachHang (TenKH, SDT, DiaChi) VALUES (@TenKH, @SDT, @DiaChi);
        SELECT SCOPE_IDENTITY() AS MaKH;
    END
END
GO

CREATE OR ALTER PROCEDURE sp_GetBaoCaoChiTiet
AS
BEGIN
    SELECT 
        H.MaHD AS [Mã HĐ],
        H.NgayLap AS [Ngày Giờ],
        K.TenKH AS [Khách Hàng],
        S.TenSP AS [Tên Vàng],
        C.TrongLuong AS [Lượng],
        FORMAT(C.DonGiaVang, 'N0') AS [Đơn Giá Vàng],
        FORMAT(C.TienCongBan, 'N0') AS [Tiền Công],
        FORMAT(H.TongTien, 'N0') AS [Thành Tiền]
    FROM HoaDon H
    JOIN ChiTietHoaDon C ON H.MaHD = C.MaHD
    JOIN KhachHang K ON H.MaKH = K.MaKH
    JOIN SanPham S ON C.MaSP = S.MaSP
    ORDER BY H.NgayLap DESC;
END
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTietHoaDon') AND name = 'DonGiaVang')
    ALTER TABLE ChiTietHoaDon ADD 
        TrongLuong FLOAT,       
        DonGiaVang DECIMAL(18,0), 
        TienCongBan DECIMAL(18,0); 
GO

-- 2. Store Procedure: Lưu khách hàng 
CREATE OR ALTER PROCEDURE sp_LuuKhachHangTuDong
    @TenKH NVARCHAR(100),
    @SDT VARCHAR(15),
    @DiaChi NVARCHAR(200)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM KhachHang WHERE SDT = @SDT)
    BEGIN
        UPDATE KhachHang SET TenKH = @TenKH, DiaChi = @DiaChi WHERE SDT = @SDT;
        SELECT MaKH FROM KhachHang WHERE SDT = @SDT;
    END
    ELSE
    BEGIN
        INSERT INTO KhachHang (TenKH, SDT, DiaChi) VALUES (@TenKH, @SDT, @DiaChi);
        SELECT SCOPE_IDENTITY() AS MaKH;
    END
END
GO

CREATE OR ALTER PROCEDURE sp_ThongKeLoiNhuan
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    DECLARE @TongBan DECIMAL(18,0), @TongMua DECIMAL(18,0);

    -- 1. Tính tổng tiền từ các hóa đơn bán ra
    SELECT @TongBan = ISNULL(SUM(TongTien), 0) 
    FROM HoaDon 
    WHERE CAST(NgayLap AS DATE) BETWEEN @TuNgay AND @DenNgay;

    -- 2. Tính tổng tiền đã chi để thu mua vàng của khách
    SELECT @TongMua = ISNULL(SUM(TongTienTra), 0) 
    FROM PhieuThuMua 
    WHERE CAST(NgayThu AS DATE) BETWEEN @TuNgay AND @DenNgay;

    -- 3. Xuất kết quả chi tiết
    SELECT 
        @TongBan AS [Tổng Tiền Bán], 
        @TongMua AS [Tổng Tiền Mua], 
        (@TongBan - @TongMua) AS [Lợi Nhuận],
        CASE 
            WHEN (@TongBan - @TongMua) > 0 THEN N'LỜI'
            WHEN (@TongBan - @TongMua) < 0 THEN N'LỖ'
            ELSE N'HÒA VỐN'
        END AS [Trạng Thái];
END
GO

IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('SanPham', 'U') IS NOT NULL DROP TABLE SanPham;
GO

CREATE TABLE SanPham (
    MaSP NVARCHAR(50) PRIMARY KEY,   
    TenSP NVARCHAR(200) NOT NULL,    
    MaLoai NVARCHAR(100),           
    LoaiVang AS MaLoai,             
    TrongLuong FLOAT,                
    TienCong DECIMAL(18, 0),         
    SoLuongTon INT DEFAULT 0,        
    GiaNiemYet DECIMAL(18, 0),       
    ThanhTien DECIMAL(18, 0)         
);
GO

CREATE TABLE ChiTietHoaDon (
MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
    MaSP NVARCHAR(50) FOREIGN KEY REFERENCES SanPham(MaSP),
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien AS (SoLuong * DonGia)
);
GO
CREATE OR ALTER PROCEDURE sp_LayDanhSachKho
AS
BEGIN
    SELECT 
        MaSP AS [Mã SP], 
        TenSP AS [Tên Sản Phẩm], 
        MaLoai AS [Loại Vàng], 
        TrongLuong AS [Trọng Lượng], 
        TienCong AS [Tiền Công], 
        SoLuongTon AS [Tồn Kho], 
        GiaNiemYet AS [Giá Niêm Yết], 
        ThanhTien AS [Thành Tiền]
    FROM SanPham;
END
GO

DELETE FROM SanPham;
GO

DELETE FROM SanPham;
GO

DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    INSERT INTO SanPham (MaSP, TenSP, MaLoai, TrongLuong, TienCong, SoLuongTon, GiaNiemYet, ThanhTien)
    VALUES (
        'SP' + RIGHT('000' + CAST(@i AS VARCHAR), 3), 
        
        -- BẮT ĐẦU SỬA: Hàm CHOOSE sẽ tự động xoay vòng 5 tên thật ghép với loại vàng
        CHOOSE((@i % 5) + 1, N'Dây chuyền', N'Nhẫn kim tiền', N'Lắc tay nam', N'Bông tai nụ', N'Kiềng cổ') 
        + N' ' + 
        CASE 
            WHEN @i % 3 = 0 THEN N'Vàng 18K' 
            WHEN @i % 3 = 1 THEN N'Vàng SJC' 
            ELSE N'Vàng 24K' 
        END,
       
        CASE 
            WHEN @i % 3 = 0 THEN N'Vàng 18K' 
            WHEN @i % 3 = 1 THEN N'Vàng SJC' 
            ELSE N'Vàng 24K' 
        END,
        
        ROUND(RAND() * 5 + 0.5, 2), 
        500000, 
        10 + @i, 
        5000000 + (@i * 10000), 
        0 
    );
    SET @i = @i + 1;
END;
GO

UPDATE SanPham 
SET ThanhTien = (TrongLuong * GiaNiemYet) + TienCong;
GO

-- Kiểm tra lại
SELECT COUNT(*) AS TongSoSanPham FROM SanPham;
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SanPham') AND name = 'GiaNiemYet')
    ALTER TABLE SanPham ADD GiaNiemYet DECIMAL(18, 0);

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('SanPham') AND name = 'ThanhTien')
    ALTER TABLE SanPham ADD ThanhTien DECIMAL(18, 0);
GO

UPDATE SanPham
SET 
    GiaNiemYet = CASE 
        WHEN MaLoai LIKE N'%SJC%' THEN 8200000
        WHEN MaLoai LIKE N'%24K%' THEN 7600000
        WHEN MaLoai LIKE N'%18K%' THEN 5600000
        ELSE 3000000 
    END,
    TienCong = ISNULL(TienCong, 500000),
    SoLuongTon = ISNULL(SoLuongTon, 20)
WHERE MaSP IS NOT NULL;
GO

-- 3. Tính toán lại cột Thành Tiền cho toàn bộ kho
UPDATE SanPham
SET ThanhTien = (TrongLuong * (GiaNiemYet / 10)) + TienCong
WHERE TrongLuong > 0 AND GiaNiemYet > 0;
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachKho
AS
BEGIN
    SELECT 
        S.MaSP AS [Mã SP], 
        S.TenSP AS [Tên Sản Phẩm], 
        L.TenLoai AS [Loại Vàng], 
        S.TrongLuong AS [Trọng Lượng],
        S.SoLuongTon AS [Tồn Kho],
        -- Tính toán giá bán và định dạng số
        FORMAT((S.TrongLuong * (L.GiaBanRa / 10)) + S.TienCong, 'N0') AS [Giá Niêm Yết]
    FROM SanPham S
    JOIN LoaiVang L ON S.MaLoai = L.MaLoai; 
END
GO
-- Cấp lại quyền trượng cho Admin Bảo
UPDATE NguoiDung 
SET MatKhau = 'admin2806', 
    TenDangNhap = 'admin',
    Quyen = 'Admin' 
WHERE MaNV = 'NV001';
UPDATE NguoiDung
SET GioiTinh = N'Nam' 
WHERE TenDangNhap = 'admin';
GO

IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
GO

-- 1. Xóa bảng cũ (nếu có) theo đúng thứ tự để không bị kẹt
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NOT NULL DROP TABLE ChiTietHoaDon;
IF OBJECT_ID('HoaDon', 'U') IS NOT NULL DROP TABLE HoaDon;
IF OBJECT_ID('KhachHang', 'U') IS NOT NULL DROP TABLE KhachHang;
GO

-- 2. Tạo bảng Khách Hàng trước (Bảng cha)
CREATE TABLE KhachHang (
    MaKH INT IDENTITY(1,1) PRIMARY KEY,
    TenKH NVARCHAR(100) NOT NULL,
    SDT VARCHAR(15) UNIQUE, 
    CCCD VARCHAR(20) UNIQUE, 
    DiaChi NVARCHAR(200),
    GioiTinh NVARCHAR(10),
    NgayTao DATETIME DEFAULT GETDATE()
);
GO

-- 3. Tạo bảng Hóa Đơn sau (Bảng con - Tham chiếu đến Khách Hàng)
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayLap DATETIME DEFAULT GETDATE(),
    MaNV VARCHAR(10),
    MaKH INT FOREIGN KEY REFERENCES KhachHang(MaKH), -- Hết lỗi vì KhachHang đã tạo ở trên
    TongTien DECIMAL(18, 0),
    LoaiHoaDon NVARCHAR(20),
    GhiChu NVARCHAR(200)
);
GO
-- 4. Nạp dữ liệu 25 khách hàng
INSERT INTO KhachHang (TenKH, SDT, CCCD, DiaChi, GioiTinh)
VALUES 
(N'Trần Thị Mai', '0812000001', '052000001001', N'Quận 1, TP.HCM', N'Nữ'),
(N'Lê Minh Triết', '0812000002', '052000001002', N'Bình Thạnh, TP.HCM', N'Nam'),
(N'Nguyễn Thu Thủy', '0812000003', '052000001003', N'Thủ Đức, TP.HCM', N'Nữ'),
(N'Vũ Đức Đam', '0812000004', '052000001004', N'Quận 7, TP.HCM', N'Nam'),
(N'Hoàng Thanh Trúc', '0812000005', '052000001005', N'Quận 3, TP.HCM', N'Nữ'),
(N'Đặng Quốc Bảo', '0812000006', '052000001006', N'Phú Nhuận, TP.HCM', N'Nam'),
(N'Bùi Kim Yến', '0812000007', '052000001007', N'Tân Bình, TP.HCM', N'Nữ'),
(N'Võ Thành Ý', '0812000008', '052000001008', N'Quận 10, TP.HCM', N'Nam'),
(N'Trịnh Thăng Bình', '0812000009', '052000001009', N'Quận 5, TP.HCM', N'Nam'),
(N'Mai Phương Thúy', '0812000010', '052000001010', N'Hóc Môn, TP.HCM', N'Nữ'),
(N'Nguyễn Phi Hùng', '0812000011', '052000001011', N'Quận 4, TP.HCM', N'Nam'),
(N'Lý Hải', '0812000012', '052000001012', N'Quận 1, TP.HCM', N'Nam'),
(N'Hà Phương', '0812000013', '052000001013', N'Quận 3, TP.HCM', N'Nữ'),
(N'Phan Thanh Hậu', '0812000014', '052000001014', N'Nghệ An', N'Nam'),
(N'Nguyễn Hồng Nhung', '0812000015', '052000001015', N'Hà Nội', N'Nữ'),
(N'Dương Triệu Vũ', '0812000016', '052000001016', N'Bình Tân, TP.HCM', N'Nam'),
(N'Lưu Thiên Hương', '0812000017', '052000001017', N'Quận 2, TP.HCM', N'Nữ'),
(N'Chu Hùng', '0812000018', '052000001018', N'Quận 11, TP.HCM', N'Nam'),
(N'Nguyễn Trọng Hoàng', '0812000019', '052000001019', N'Gia Lai', N'Nam'),
(N'Lê Khánh', '0812000020', '052000001020', N'Quận 6, TP.HCM', N'Nữ'),
(N'Phạm Quỳnh Anh', '0812000021', '052000001021', N'Quận 8, TP.HCM', N'Nữ'),
(N'Nguyễn Văn Toàn', '0812000022', '052000001022', N'Hải Dương', N'Nam'),
(N'Lê Thị Hồng Gấm', '0812000023', '052000001023', N'Quận 12, TP.HCM', N'Nữ'),
(N'Trương Vĩnh Ký', '0812000024', '052000001024', N'Hà Nội', N'Nam'),
(N'Hà Kiều Anh', '0812000025', '052000001025', N'Trà Vinh', N'Nữ');
GO

CREATE OR ALTER PROCEDURE sp_LayDanhSachKhachHang
AS
BEGIN
    SELECT 
        MaKH AS [Mã KH], 
        TenKH AS [Họ và tên],
        SDT AS [Số điện thoại],
        -- Kiểm tra xem bảng có cột CCCD chưa, nếu chưa có thì để trống để C# không bị lỗi
        (CASE WHEN COL_LENGTH('KhachHang', 'CCCD') IS NOT NULL THEN CCCD ELSE '' END) AS [Cccd],
        DiaChi AS [Địa chỉ],
        -- Tạm thời lấy Max NgayLap nếu chưa có cột LoaiHoaDon để tránh lỗi
        ISNULL(FORMAT((SELECT MAX(NgayLap) FROM HoaDon WHERE MaKH = K.MaKH), 'dd/MM/yyyy'), N'Chưa có') AS [Ngày bán vàng],
        GioiTinh AS [Giới tính]
    FROM KhachHang K
    ORDER BY MaKH DESC;
END
GO
SELECT 
    TenKH AS [Họ và tên],
    SDT AS [Số điện thoại],
    CCCD AS [Cccd],
    DiaChi AS [Địa chỉ],
    FORMAT((SELECT MAX(NgayLap) FROM HoaDon WHERE MaKH = K.MaKH AND LoaiHoaDon = N'Bán'), 'dd/MM/yyyy') AS [Ngày bán vàng],
    GioiTinh AS [Giới tính]
FROM KhachHang K
ORDER BY MaKH DESC;
GO 

-- 2. Tạo Procedure để C# gọi lưu khách hàng
CREATE OR ALTER PROCEDURE sp_LuuKhachHangVaoData
    @TenKH NVARCHAR(100),
    @SDT VARCHAR(15),
    @CCCD VARCHAR(20),
    @DiaChi NVARCHAR(200),
    @GioiTinh NVARCHAR(10)
AS
BEGIN
    
    IF EXISTS (SELECT 1 FROM KhachHang WHERE SDT = @SDT OR CCCD = @CCCD)
    BEGIN
        RAISERROR(N'Số điện thoại hoặc CCCD đã tồn tại!', 16, 1);
        RETURN;
    END

    -- Thêm mới
    INSERT INTO KhachHang (TenKH, SDT, CCCD, DiaChi, GioiTinh)
    VALUES (@TenKH, @SDT, @CCCD, @DiaChi, @GioiTinh);
END
GO
-- 1. SỬA STORE THÊM NHÂN VIÊN (Đảm bảo nhận đủ 12 thông tin từ Form)
CREATE OR ALTER PROCEDURE sp_ThemNhanVien
    @TenDangNhap VARCHAR(50), @MatKhau VARCHAR(50), @HoTen NVARCHAR(100),
    @GioiTinh NVARCHAR(10), @NgaySinh DATE, @SDT VARCHAR(15),
    @CCCD VARCHAR(20), @Email VARCHAR(100), @QueQuan NVARCHAR(100),
    @CaLam NVARCHAR(50), @NgayVaoLam DATE, @Quyen NVARCHAR(20)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NguoiDung WHERE TenDangNhap = @TenDangNhap)
        SELECT 0 AS Code, N'Tên đăng nhập đã tồn tại!' AS ThongBao;
    ELSE
    BEGIN
        INSERT INTO NguoiDung (TenDangNhap, MatKhau, HoTen, GioiTinh, NgaySinh, SDT, CCCD, Email, QueQuan, CaLam, NgayVaoLam, Quyen, TrangThai)
        VALUES (@TenDangNhap, @MatKhau, @HoTen, @GioiTinh, @NgaySinh, @SDT, @CCCD, @Email, @QueQuan, @CaLam, @NgayVaoLam, @Quyen, N'Đang làm việc');
        SELECT 1 AS Code, N'Thêm thành công!' AS ThongBao;
    END
END
GO

-- 2. STORE LƯU
CREATE OR ALTER PROCEDURE sp_SuaNhanVien
    @MaNV VARCHAR(10), @HoTen NVARCHAR(100), @GioiTinh NVARCHAR(10),
    @NgaySinh DATE, @SDT VARCHAR(15), @CCCD VARCHAR(20),
    @Email VARCHAR(100), @QueQuan NVARCHAR(100), @CaLam NVARCHAR(50),
    @NgayVaoLam DATE, @Quyen NVARCHAR(20), @TrangThai NVARCHAR(20)
AS
BEGIN
  
    UPDATE NguoiDung
    SET HoTen = @HoTen, GioiTinh = @GioiTinh, NgaySinh = @NgaySinh, SDT = @SDT, 
        CCCD = @CCCD, Email = @Email, QueQuan = @QueQuan, CaLam = @CaLam, 
        NgayVaoLam = @NgayVaoLam, Quyen = @Quyen, TrangThai = @TrangThai
    WHERE MaNV = @MaNV;

    IF @@ROWCOUNT > 0 
        SELECT 1 AS Code, N'Cập nhật thành công!' AS ThongBao;
    ELSE 
        SELECT 0 AS Code, N'Lỗi: Không tìm thấy nhân viên!' AS ThongBao;
END
GO


CREATE OR ALTER PROCEDURE sp_XoaNhanVien
    @MaXoa VARCHAR(10)
AS
BEGIN
    IF EXISTS (SELECT 1 FROM NguoiDung WHERE MaNV = @MaXoa AND Quyen = 'Admin')
        SELECT 0 AS Code, N'Không thể xóa tài khoản Admin!' AS ThongBao;
    ELSE
    BEGIN
        DELETE FROM NguoiDung WHERE MaNV = @MaXoa;
        SELECT 1 AS Code, N'Đã xóa thành công!' AS ThongBao;
    END
END
GO
-- 1. TẠO LẠI BẢNG ChiTietHoaDon
IF OBJECT_ID('ChiTietHoaDon', 'U') IS NULL 
BEGIN
    CREATE TABLE ChiTietHoaDon (
        MaHD INT FOREIGN KEY REFERENCES HoaDon(MaHD),
        MaSP NVARCHAR(50) FOREIGN KEY REFERENCES SanPham(MaSP),
        SoLuong INT,
        DonGia DECIMAL(18, 0),
        TrongLuong FLOAT,       
        DonGiaVang DECIMAL(18,0), 
        TienCongBan DECIMAL(18,0),
        ThanhTien AS (SoLuong * DonGia)
    );
END
GO

-- 2. STORE PROCEDURE
-- 1. Xóa cột cũ để làm mới hoàn toàn hệ thống tự động
IF EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTietHoaDon') AND name = 'ThanhTien')
    ALTER TABLE ChiTietHoaDon DROP COLUMN ThanhTien;
GO


ALTER TABLE ChiTietHoaDon ADD ThanhTien DECIMAL(18,0);
GO

ALTER TABLE ChiTietHoaDon DROP COLUMN ThanhTien;
GO

IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDon') AND name = 'TenNhanVienLap')
    ALTER TABLE HoaDon ADD TenNhanVienLap NVARCHAR(100);
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('HoaDon') AND name = 'TenKhachHangMua')
    ALTER TABLE HoaDon ADD TenKhachHangMua NVARCHAR(100);
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTietHoaDon') AND name = 'TienCong')
    ALTER TABLE ChiTietHoaDon ADD TienCong DECIMAL(18, 0);
GO
IF NOT EXISTS (SELECT * FROM sys.columns WHERE object_id = OBJECT_ID('ChiTietHoaDon') AND name = 'ThanhTien')
    ALTER TABLE ChiTietHoaDon ADD ThanhTien DECIMAL(18, 0);
GO

-- 2. TẠO PROCEDURE THỐNG KÊ (Xây nhà trên móng đã có cột)
CREATE OR ALTER PROCEDURE sp_ThongKeDoanhThuTheoNgay
    @TuNgay DATE,
    @DenNgay DATE
AS
BEGIN
    SET NOCOUNT ON;
    SELECT 
        CONVERT(VARCHAR, NgayLap, 103) AS [Ngày Bán],
        FORMAT(SUM(TongTien), 'N0') AS [Tổng Tiền Bán Được]
    FROM HoaDon
    WHERE CAST(NgayLap AS DATE) BETWEEN @TuNgay AND @DenNgay
    GROUP BY CAST(NgayLap AS DATE), CONVERT(VARCHAR, NgayLap, 103)
    ORDER BY CAST(NgayLap AS DATE) DESC;
END
GO
-- 3. CẬP NHẬT PROCEDURE TẠO HÓA ĐƠN (Để lưu được tên từ C#)
CREATE OR ALTER PROCEDURE sp_TaoHoaDon
    @MaNV VARCHAR(10),
    @MaKH INT,
    @TongTien DECIMAL(18, 0),
    @GhiChu NVARCHAR(200),
    @TenNV NVARCHAR(100), 
    @TenKH NVARCHAR(100)
AS
BEGIN
    INSERT INTO HoaDon (MaNV, MaKH, TongTien, GhiChu, TenNhanVienLap, TenKhachHangMua, NgayLap, LoaiHoaDon)
    VALUES (@MaNV, @MaKH, @TongTien, @GhiChu, @TenNV, @TenKH, GETDATE(), N'Bán');
    
    SELECT SCOPE_IDENTITY() AS NewMaHD;
END
GO
SELECT MaHD, NgayLap, TongTien FROM HoaDon;

DELETE FROM ChiTietHoaDon;
DELETE FROM HoaDon;
SELECT MaHD, NgayLap, TenKhachHangMua, TongTien 
FROM HoaDon 
WHERE CAST(NgayLap AS DATE) = '2026-03-31'
DELETE FROM ChiTietHoaDon;
DELETE FROM HoaDon;