namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HoaDonNhap")]
    public partial class HoaDonNhap
    {
        public int ID { get; set; }

        public int? MANCC { get; set; }

        public int? MANV { get; set; }

        public DateTime? NGAYNHAP { get; set; }

        public double? THANHTIEN { get; set; }

        public virtual ChiTietHDN ChiTietHDN { get; set; }

        public virtual NhaCungCap NhaCungCap { get; set; }

        public virtual NhanVien NhanVien { get; set; }
    }
}
