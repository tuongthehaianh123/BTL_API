namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietHDX")]
    public partial class ChiTietHDX
    {
        [Key]
        public int MAHDX { get; set; }

        public int? MASP { get; set; }

        public int? SOLUONG { get; set; }

        public double? GIABAN { get; set; }

        public virtual HoaDonXuat HoaDonXuat { get; set; }

        public virtual Sanpham1 Sanpham1 { get; set; }
    }
}
