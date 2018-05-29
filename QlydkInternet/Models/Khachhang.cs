using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Khachhang
    {
        public Khachhang()
        {
            Apdung = new HashSet<Apdung>();
            Hoadon = new HashSet<Hoadon>();
            Hotro = new HashSet<Hotro>();
            Phieudangky = new HashSet<Phieudangky>();
            Thongtintruycap = new HashSet<Thongtintruycap>();
        }

        public string Makh { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngsinh { get; set; }
        public string Sdt { get; set; }
        public string Nghenghiep { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Cmnd { get; set; }

        public ICollection<Apdung> Apdung { get; set; }
        public ICollection<Hoadon> Hoadon { get; set; }
        public ICollection<Hotro> Hotro { get; set; }
        public ICollection<Phieudangky> Phieudangky { get; set; }
        public ICollection<Thongtintruycap> Thongtintruycap { get; set; }
    }
}
