using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Khuyenmai
    {
        public string Makhuyenmai { get; set; }
        public string Tenkhuyenmai { get; set; }
        public DateTime? Ngaybatdau { get; set; }
        public DateTime? Ngayketthuc { get; set; }
        public string Maloaikhuyenmai { get; set; }
        public string Mahopdong { get; set; }
        public int? Trigia { get; set; }
        public string Matinhtrang { get; set; }
    }
}
