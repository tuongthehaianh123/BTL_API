namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sanpham1
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sanpham1()
        {
            ChiTietHDN = new HashSet<ChiTietHDN>();
            ChiTietHDX = new HashSet<ChiTietHDX>();
        }

        public int ID { get; set; }

        [StringLength(250)]
        public string TENSP { get; set; }

        [StringLength(250)]
        public string IMAGE { get; set; }

        public int? MALOAI { get; set; }

        [StringLength(250)]
        public string XUATXU { get; set; }

        public double? GIABAN { get; set; }

        public int? SOLUONG { get; set; }

        [StringLength(250)]
        public string Description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDN> ChiTietHDN { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietHDX> ChiTietHDX { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
