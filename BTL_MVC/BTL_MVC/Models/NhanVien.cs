namespace BTL_MVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NhanVien")]
    public partial class NhanVien
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhanVien()
        {
            HoaDonNhap = new HashSet<HoaDonNhap>();
            HoaDonXuat = new HashSet<HoaDonXuat>();
        }

        public int ID { get; set; }

        [StringLength(50)]
        public string TENNV { get; set; }

        [StringLength(50)]
        public string CHUCVU { get; set; }

        [StringLength(250)]
        public string DIACHI { get; set; }

        public int? SODIENTHOAI { get; set; }

        [StringLength(250)]
        public string EMAIL { get; set; }

        [StringLength(250)]
        public string TENTK { get; set; }

        [StringLength(50)]
        public string MK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonXuat> HoaDonXuat { get; set; }
    }
}
