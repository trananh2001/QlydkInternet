using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Loaikhuyenmai
    {
        public Loaikhuyenmai()
        {
            Khuyenmai = new HashSet<Khuyenmai>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public ICollection<Khuyenmai> Khuyenmai { get; set; }
    }
}
