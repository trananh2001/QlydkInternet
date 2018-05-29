using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Apdung
    {
        public string Makm { get; set; }
        public string Makh { get; set; }
        public DateTime Ngad { get; set; }

        public Khachhang MakhNavigation { get; set; }
        public Khuyenmai MakmNavigation { get; set; }
    }
}
