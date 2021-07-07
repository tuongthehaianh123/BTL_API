using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_MVC.Models
{
    public class SanPhamViewModel
    {
        public int? ID { get; set; }

        public string TENSP { get; set; }

        public string IMAGE { get; set; }

        public int? MALOAI { get; set; }

        public string XUATXU { get; set; }

        public double? GIABAN { get; set; }

        public int? SOLUONG { get; set; }

        public string Description { get; set; }
    }
}