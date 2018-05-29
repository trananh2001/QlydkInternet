using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Goicuoc
    {
        public Goicuoc()
        {
            Capnhatgc = new HashSet<Capnhatgc>();
            Phieudangky = new HashSet<Phieudangky>();
        }

        public string Magc { get; set; }
        public string Tengc { get; set; }
        public string Loaigc { get; set; }
        public string Tocdo { get; set; }
        public decimal Giacuoc { get; set; }
        public string Mota { get; set; }
        public string Hinhanh { get; set; }

        public Loaigoicuoc LoaigcNavigation { get; set; }
        public ICollection<Capnhatgc> Capnhatgc { get; set; }
        public ICollection<Phieudangky> Phieudangky { get; set; }
    }
}
