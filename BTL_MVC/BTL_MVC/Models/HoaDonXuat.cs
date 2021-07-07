namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonXuat")]
    public partial class HoaDonXuat
    {
        public int ID { get; set; }

        public int? MAKH { get; set; }

        public int? MANV { get; set; }

        public DateTime? NGAYXUAT { get; set; }

        public double? THANHTIEN { get; set; }

        public virtual ChiTietHDX ChiTietHDX { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
