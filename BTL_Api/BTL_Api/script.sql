USE [test]
GO
/****** Object:  Table [dbo].[ChiTietHDN]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDN](
	[MAHDN] [int] IDENTITY(1,1) NOT NULL,
	[MASP] [int] NULL,
	[SOLUONG] [int] NULL,
	[GIANHAP] [float] NULL,
 CONSTRAINT [PK_ChiTietHDN] PRIMARY KEY CLUSTERED 
(
	[MAHDN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ChiTietHDX]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChiTietHDX](
	[MAHDX] [int] IDENTITY(1,1) NOT NULL,
	[MASP] [int] NULL,
	[SOLUONG] [int] NULL,
	[GIABAN] [float] NULL,
 CONSTRAINT [PK_ChiTietHDX] PRIMARY KEY CLUSTERED 
(
	[MAHDX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GioHang]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GioHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENSP] [nvarchar](250) NULL,
	[DONGIA] [float] NULL,
	[SOLUONG] [int] NULL,
	[IMAGE] [nvarchar](250) NULL,
	[THANHTIEN] [float] NULL,
 CONSTRAINT [PK_GioHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonNhap]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonNhap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MANCC] [int] NULL,
	[MANV] [int] NULL,
	[NGAYNHAP] [datetime] NULL,
	[THANHTIEN] [float] NULL,
 CONSTRAINT [PK_HoaDonNhap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonXuat]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonXuat](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MAKH] [int] NULL,
	[MANV] [int] NULL,
	[NGAYXUAT] [datetime] NULL,
	[THANHTIEN] [float] NULL,
 CONSTRAINT [PK_HoaDonXuat] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[SODIENTHOAI] [int] NULL,
	[DIACHI] [nvarchar](250) NULL,
	[TENTK] [nvarchar](250) NULL,
	[MK] [nvarchar](50) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoaiSanPham]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoaiSanPham](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENLOAI] [nvarchar](250) NULL,
 CONSTRAINT [PK_LoaiSanPham] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhaCungCap]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhaCungCap](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENNCC] [nvarchar](250) NULL,
	[DIACHI] [nvarchar](250) NULL,
	[SODIENTHOAI] [int] NULL,
 CONSTRAINT [PK_NhaCungCap] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENNV] [nvarchar](50) NULL,
	[CHUCVU] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](250) NULL,
	[SODIENTHOAI] [int] NULL,
	[EMAIL] [nvarchar](250) NULL,
	[TENTK] [nvarchar](250) NULL,
	[MK] [nvarchar](50) NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Sanpham1]    Script Date: 29/06/2021 6:50:18 CH ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sanpham1](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TENSP] [nvarchar](250) NULL,
	[IMAGE] [nvarchar](250) NULL,
	[MALOAI] [int] NULL,
	[XUATXU] [nvarchar](250) NULL,
	[GIABAN] [float] NULL,
	[SOLUONG] [int] NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Sanpham1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[LoaiSanPham] ON 

INSERT [dbo].[LoaiSanPham] ([ID], [TENLOAI]) VALUES (1, N'ao')
INSERT [dbo].[LoaiSanPham] ([ID], [TENLOAI]) VALUES (2, N'quan')
INSERT [dbo].[LoaiSanPham] ([ID], [TENLOAI]) VALUES (3, N'giay')
INSERT [dbo].[LoaiSanPham] ([ID], [TENLOAI]) VALUES (4, N'ao coc')
SET IDENTITY_INSERT [dbo].[LoaiSanPham] OFF
SET IDENTITY_INSERT [dbo].[NhaCungCap] ON 

INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (1, N'GoDaddy ', N'hà nội', 354647556)
INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (2, N'Namech hai bin', N'Hưng Yênn', 354555555)
INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (3, N'PA Việt Nam', N'Hải Phòng', 957785555)
INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (4, N'Tinohost', N'TP Hồ Chí Minh', 93547777)
INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (5, N'Hai CTYTINH', N'Núi Trúc Hà-Nội', 354555555)
INSERT [dbo].[NhaCungCap] ([ID], [TENNCC], [DIACHI], [SODIENTHOAI]) VALUES (6, N'Hai ITpost', N'PHỐ NỐI Hưng-Yên', 354666666)
SET IDENTITY_INSERT [dbo].[NhaCungCap] OFF
SET IDENTITY_INSERT [dbo].[Sanpham1] ON 

INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (8, N'DEC AO Open Eyes Shirt - Blue', N'aomau.jpg', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (9, N'DEC AO Open Eyes Shirt - Blue', N'ao11.jpg
', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (10, N'DEC AO Open Eyes Shirt - Blue', N'aomau.jpg', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (11, N'DEC AO Open Eyes Shirt - Blue', N'ao11.jpg
', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (12, N'DEC AO -haibin', N'aomau.jpg', 2, N'VietNam', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (13, N'DEC AO -haibin', N'aomau.jpg', 2, N'VietNam', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (15, N'DEC AO -chu linh chi', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (16, N'DEC AO shop', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (17, N'Gucci Hawaii wool cotton', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (18, N'Gucci Hawaii wool cotton', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (19, N'Gucci Hawaii wool cotton', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (20, N'Gucci Hawaii wool cotton', N'aomau.jpg', 1, N'VietNam', 500000000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (24, N'DEC AO Open Eyes Shirt - Blue', N'aomau.jpg', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (25, N'DEC AO anh hai dz vai daidai', N'aomau.jpg', 1, N'chi na', 100000, 50, N'áo phông nam cổ dài tay đẹp ')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (28, N'ao decaooooooooooo', N'ao1.jpg', 1, N'hn', 12222222222222222, 1, N'2222222222aaaaaaaaaaaaaaaaaaaaaaaaaa')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (29, N'ao decaooooooooooo', N'ao1.jpg', 1, N'hn', 12222222222222222, 1, N'2222222222aaaaaaaaaaaaaaaaaaaaaaaaaa')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (34, N'chulinhchi', N'aomoi5.jpg', 1, N'hn', 12222222222222222, 9, N'123')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (39, N'dài fpt', N'131383228_433526231024120_472358930227536072_o.jpg', 3, N'Việt Nam', 12222222222222222, 9, N'1312')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (41, N'dài fpt', N'131383228_433526231024120_472358930227536072_o.jpg', 3, N'Việt Nam', 12222222222222222, 9, N'2222222222aaaaaaaaaaaaaaaaaaaaaaaaaa')
INSERT [dbo].[Sanpham1] ([ID], [TENSP], [IMAGE], [MALOAI], [XUATXU], [GIABAN], [SOLUONG], [Description]) VALUES (42, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Sanpham1] OFF
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_HoaDonNhap] FOREIGN KEY([MAHDN])
REFERENCES [dbo].[HoaDonNhap] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_HoaDonNhap]
GO
ALTER TABLE [dbo].[ChiTietHDN]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDN_Sanpham1] FOREIGN KEY([MASP])
REFERENCES [dbo].[Sanpham1] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHDN] CHECK CONSTRAINT [FK_ChiTietHDN_Sanpham1]
GO
ALTER TABLE [dbo].[ChiTietHDX]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDX_HoaDonXuat] FOREIGN KEY([MAHDX])
REFERENCES [dbo].[HoaDonXuat] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHDX] CHECK CONSTRAINT [FK_ChiTietHDX_HoaDonXuat]
GO
ALTER TABLE [dbo].[ChiTietHDX]  WITH CHECK ADD  CONSTRAINT [FK_ChiTietHDX_Sanpham1] FOREIGN KEY([MASP])
REFERENCES [dbo].[Sanpham1] ([ID])
GO
ALTER TABLE [dbo].[ChiTietHDX] CHECK CONSTRAINT [FK_ChiTietHDX_Sanpham1]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhaCungCap] FOREIGN KEY([MANCC])
REFERENCES [dbo].[NhaCungCap] ([ID])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhaCungCap]
GO
ALTER TABLE [dbo].[HoaDonNhap]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonNhap_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[HoaDonNhap] CHECK CONSTRAINT [FK_HoaDonNhap_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonXuat]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonXuat_KhachHang] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KhachHang] ([ID])
GO
ALTER TABLE [dbo].[HoaDonXuat] CHECK CONSTRAINT [FK_HoaDonXuat_KhachHang]
GO
ALTER TABLE [dbo].[HoaDonXuat]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonXuat_NhanVien] FOREIGN KEY([MANV])
REFERENCES [dbo].[NhanVien] ([ID])
GO
ALTER TABLE [dbo].[HoaDonXuat] CHECK CONSTRAINT [FK_HoaDonXuat_NhanVien]
GO
ALTER TABLE [dbo].[Sanpham1]  WITH CHECK ADD  CONSTRAINT [FK_Sanpham1_LoaiSanPham] FOREIGN KEY([MALOAI])
REFERENCES [dbo].[LoaiSanPham] ([ID])
GO
ALTER TABLE [dbo].[Sanpham1] CHECK CONSTRAINT [FK_Sanpham1_LoaiSanPham]
GO
