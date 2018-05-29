using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Hoadon
    {
        public string Sohd { get; set; }
        public DateTime Ngayin { get; set; }
        public DateTime? Ngaythanhtoan { get; set; }
        public decimal Trigia { get; set; }
        public string Makh { get; set; }
        public string Manv { get; set; }
        public DateTime Hanhoadon { get; set; }

        public Khachhang MakhNavigation { get; set; }
        public Nhanvien ManvNavigation { get; set; }
    }
}
