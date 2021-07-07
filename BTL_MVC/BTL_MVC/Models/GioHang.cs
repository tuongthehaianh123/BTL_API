namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GioHang")]
    public partial class GioHang
    {
        public int ID { get; set; }

        [StringLength(250)]
        public string TENSP { get; set; }

        public double? DONGIA { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(250)]
        public string IMAGE { get; set; }

        public double? THANHTIEN { get; set; }
    }
}
