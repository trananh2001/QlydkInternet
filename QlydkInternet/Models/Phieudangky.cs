using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Phieudangky
    {
        public string Maphieu { get; set; }
        public DateTime Ngdk { get; set; }
        public DateTime Ngad { get; set; }
        public string Doituong { get; set; }
        public string Dccaidat { get; set; }
        public string Dchoadon { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public string Loaitt { get; set; }
        public string Tinhtrang { get; set; }
        public string Makh { get; set; }
        public string Magc { get; set; }

        public Loaithanhtoan LoaittNavigation { get; set; }
        public Goicuoc MagcNavigation { get; set; }
        public Khachhang MakhNavigation { get; set; }
    }
}
