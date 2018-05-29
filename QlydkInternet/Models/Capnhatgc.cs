using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Capnhatgc
    {
        public string Noidung { get; set; }
        public DateTime Thoigian { get; set; }
        public string Manv { get; set; }
        public string Magc { get; set; }

        public Goicuoc MagcNavigation { get; set; }
        public Nhanvien ManvNavigation { get; set; }
    }
}
