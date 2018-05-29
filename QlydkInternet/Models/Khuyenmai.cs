using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Khuyenmai
    {
        public Khuyenmai()
        {
            Apdung = new HashSet<Apdung>();
            Capnhatkm = new HashSet<Capnhatkm>();
        }

        public string Makm { get; set; }
        public string Tenkm { get; set; }
        public string Loaikm { get; set; }
        public string Loaigc { get; set; }
        public string Mota { get; set; }
        public DateTime Ngbd { get; set; }
        public DateTime? Ngkt { get; set; }
        public int? Trigia { get; set; }
        public string Hinhanh { get; set; }

        public Loaigoicuoc LoaigcNavigation { get; set; }
        public Loaikhuyenmai LoaikmNavigation { get; set; }
        public ICollection<Apdung> Apdung { get; set; }
        public ICollection<Capnhatkm> Capnhatkm { get; set; }
    }
}
