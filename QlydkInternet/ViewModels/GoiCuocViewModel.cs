using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using QlydkInternet.Models;
namespace QlydkInternet.ViewModels
{
    public class GoiCuocViewModel
    {
        public Goicuoc goicuoc = new Goicuoc();
        public Loaigoicuoc loaigoicuoc = new Loaigoicuoc();

        public string magc { get; set; }
        public string tengc { get; set; }
        public string loaigc { get; set; }
        public string tenloaigc { get; set; }
        public string tocdo { get; set; }
        public decimal giacuoc { get; set; }
        public string mota { get; set; }
        public string hinhanh { get; set; }
        public SelectList listloaigc { get; set; }
    }
}
