using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Loaigoicuoc
    {
        public Loaigoicuoc()
        {
            Goicuoc = new HashSet<Goicuoc>();
            Khuyenmai = new HashSet<Khuyenmai>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public ICollection<Goicuoc> Goicuoc { get; set; }
        public ICollection<Khuyenmai> Khuyenmai { get; set; }
    }
}
