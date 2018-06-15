using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Khachhang
    {
        public string Makhachhang { get; set; }
        public string Tenkhachhang { get; set; }
        public string Cmnd { get; set; }
        public string Sdt { get; set; }
        public string Nghenghiep { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public int? Soluongtaikhoan { get; set; }
    }
}
