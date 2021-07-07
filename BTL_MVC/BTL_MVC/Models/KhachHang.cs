namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            HoaDonXuat = new HashSet<HoaDonXuat>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TENKH { get; set; }

        public int? SODIENTHOAI { get; set; }

        [StringLength(250)]
        public string DIACHI { get; set; }

        [StringLength(250)]
        public string TENTK { get; set; }

        [StringLength(50)]
        public string MK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonXuat> HoaDonXuat { get; set; }
    }
}
