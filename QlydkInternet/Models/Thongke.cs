using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Thongke
    {
        public string Matk { get; set; }
        public int? Nam { get; set; }
        public int? Thang { get; set; }
        public decimal? Doanhthu { get; set; }
        public int? Dkmoi { get; set; }
        public int? Chantruycap { get; set; }
        public string Manv { get; set; }

        public Nhanvien ManvNavigation { get; set; }
    }
}
