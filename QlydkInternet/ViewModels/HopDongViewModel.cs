using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.ViewModels
{
    public class HopDongViewModel
    {
        /// <summary>
        /// thông tin hợp đồng
        /// </summary>
        public string mahd { get; set; }
        public DateTime ngdk { get; set; }
        public DateTime ngad { get; set; }
        public string doituong { get; set; }
        public string dccaidat { get; set; }
        public string dchoadon { get; set; }
        public string taikhoan { get; set; }
        public string matkhau { get; set; }
        public string loaitt { get; set; }
        public string tenloaitt { get; set; }
        public string magc { get; set; }
        public string tengc { get; set; }
        public string tinhtrang { get; set; }
        public SelectList listloaitt { get; set; }
        public SelectList listgc { get; set; }
        /// <summary>
        /// thông tin khách hàng
        /// </summary>
        public string makh { get; set; }
        public string tenkh { get; set; }
        public DateTime ngsinh { get; set; }
        public string sdt { get; set; }
        public string nghenghiep { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string cmnd { get; set; }
    }
}
