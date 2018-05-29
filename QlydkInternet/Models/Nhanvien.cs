using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Nhanvien
    {
        public Nhanvien()
        {
            Capnhatgc = new HashSet<Capnhatgc>();
            Capnhatkm = new HashSet<Capnhatkm>();
            Hoadon = new HashSet<Hoadon>();
            Hotro = new HashSet<Hotro>();
            Thongke = new HashSet<Thongke>();
            Thongtin = new HashSet<Thongtin>();
        }

        public string Manv { get; set; }
        public string Hoten { get; set; }
        public DateTime Ngsinh { get; set; }
        public string Sdt { get; set; }
        public string Chucvu { get; set; }
        public string Bophan { get; set; }
        public string Taikhoan { get; set; }
        public string Matkhau { get; set; }
        public DateTime Ngvl { get; set; }

        public ICollection<Capnhatgc> Capnhatgc { get; set; }
        public ICollection<Capnhatkm> Capnhatkm { get; set; }
        public ICollection<Hoadon> Hoadon { get; set; }
        public ICollection<Hotro> Hotro { get; set; }
        public ICollection<Thongke> Thongke { get; set; }
        public ICollection<Thongtin> Thongtin { get; set; }
    }
}
