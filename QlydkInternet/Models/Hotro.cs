using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Hotro
    {
        public string Makh { get; set; }
        public string Manv { get; set; }

        public Khachhang MakhNavigation { get; set; }
        public Nhanvien ManvNavigation { get; set; }
    }
}
