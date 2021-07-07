namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHDN")]
    public partial class ChiTietHDN
    {
        [Key]
        public int MAHDN { get; set; }

        public int? MASP { get; set; }

        public int? SOLUONG { get; set; }

        public double? GIANHAP { get; set; }

        public virtual HoaDonNhap HoaDonNhap { get; set; }

        public virtual Sanpham1 Sanpham1 { get; set; }
    }
}
