using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.ViewModels
{
    public class KhuyenMaiViewModel
    {
        public string makm { get; set; }
        public string tenkm { get; set; }
        public string loaikm { get; set; }
        public string tenloaikm { get; set; }
        public string loaigc { get; set; }
        public string tenloaigc { get; set; }
        public string mota { get; set; }
        public DateTime ngbd { get; set; }
        public DateTime? ngkt { get; set; }
        public int trigia { get; set; }
        public SelectList listloaikm { get; set; }
        public SelectList listloaigc { get; set; }
    }
}
