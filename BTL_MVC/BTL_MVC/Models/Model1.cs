namespace BTL_MVC.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<ChiTietHDN> ChiTietHDN { get; set; }
        public virtual DbSet<ChiTietHDX> ChiTietHDX { get; set; }
        public virtual DbSet<GioHang> GioHang { get; set; }
        public virtual DbSet<HoaDonNhap> HoaDonNhap { get; set; }
        public virtual DbSet<HoaDonXuat> HoaDonXuat { get; set; }
        public virtual DbSet<KhachHang> KhachHang { get; set; }
        public virtual DbSet<LoaiSanPham> LoaiSanPham { get; set; }
        public virtual DbSet<NhaCungCap> NhaCungCap { get; set; }
        public virtual DbSet<NhanVien> NhanVien { get; set; }
        public virtual DbSet<Sanpham1> Sanpham1 { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HoaDonNhap>()
                .HasOptional(e => e.ChiTietHDN)
                .WithRequired(e => e.HoaDonNhap);

            modelBuilder.Entity<HoaDonXuat>()
                .HasOptional(e => e.ChiTietHDX)
                .WithRequired(e => e.HoaDonXuat);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.HoaDonXuat)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.MAKH);

            modelBuilder.Entity<LoaiSanPham>()
                .HasMany(e => e.Sanpham1)
                .WithOptional(e => e.LoaiSanPham)
                .HasForeignKey(e => e.MALOAI);

            modelBuilder.Entity<NhaCungCap>()
                .HasMany(e => e.HoaDonNhap)
                .WithOptional(e => e.NhaCungCap)
                .HasForeignKey(e => e.MANCC);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonNhap)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.MANV);

            modelBuilder.Entity<NhanVien>()
                .HasMany(e => e.HoaDonXuat)
                .WithOptional(e => e.NhanVien)
                .HasForeignKey(e => e.MANV);

            modelBuilder.Entity<Sanpham1>()
                .HasMany(e => e.ChiTietHDN)
                .WithOptional(e => e.Sanpham1)
                .HasForeignKey(e => e.MASP);

            modelBuilder.Entity<Sanpham1>()
                .HasMany(e => e.ChiTietHDX)
                .WithOptional(e => e.Sanpham1)
                .HasForeignKey(e => e.MASP);
        }

        public System.Data.Entity.DbSet<BTL_MVC.Models.SanPhamViewModel> SanPhamViewModels { get; set; }
    }
}
