//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BTL_Api.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public partial class NhaCungCap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NhaCungCap()
        {
            this.HoaDonNhap = new HashSet<HoaDonNhap>();
        }
    
        public int ID { get; set; }
        public string TENNCC { get; set; }
        public string DIACHI { get; set; }
        public Nullable<int> SODIENTHOAI { get; set; }
    [XmlIgnore]
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HoaDonNhap> HoaDonNhap { get; set; }
    }
}