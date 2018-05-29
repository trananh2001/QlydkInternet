using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Capnhatkm
    {
        public string Noidung { get; set; }
        public DateTime Thoigian { get; set; }
        public string Makm { get; set; }
        public string Manv { get; set; }

        public Khuyenmai MakmNavigation { get; set; }
        public Nhanvien ManvNavigation { get; set; }
    }
}
