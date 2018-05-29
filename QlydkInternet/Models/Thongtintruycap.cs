using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Thongtintruycap
    {
        public string Matc { get; set; }
        public DateTime Ngaytc { get; set; }
        public string Diachitc { get; set; }
        public int Thoigiantc { get; set; }
        public int Sombsudung { get; set; }
        public string Makh { get; set; }
        public int? Thanhtien { get; set; }

        public Khachhang MakhNavigation { get; set; }
    }
}
