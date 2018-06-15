using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.ViewModels
{
    public class KhuyenMaiViewModel
    {
        public string makhuyenmai { get; set; }
        public string tenkhuyenmai { get; set; }
        public DateTime? ngaybatdau { get; set; }
        public DateTime? ngayketthuc { get; set; }
        public string maloaikhuyenmai { get; set; }
        public string tenloaikhuyenmai { get; set; }
        public string mahopdong { get; set; }
        public int? trigia { get; set; }
        public string matinhtrang { get; set; }
        public string tentinhtrang { get; set; }
        public SelectList listtinhtrang { get; set; }
        public SelectList listloaikm { get; set; }
    }
}
