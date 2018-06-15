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
        public string mahopdong { get; set; }
        public DateTime? ngaydangky { get; set; }
        public DateTime? ngayapdung { get; set; }
        public string diachicaidat { get; set; }
        public string diachithanhtoan { get; set; }
        public string makhachhang { get; set; }
        public string tenkhachhang { get; set; }
        public string magoicuoc { get; set; }
        public string tengoicuoc { get; set; }
        public string manhanvien { get; set; }
        public string tennhanvien { get; set; }
        public string matinhtrang { get; set; }
        public string tentinhtrang { get; set; }
        /// <summary>
        /// thông tin khách hàng
        /// </summary>
        //public string makhachhang { get; set; }
        //public string tenkhachhang { get; set; }
        public string cmnd { get; set; }
        public string nghenghiep { get; set; }
        public string email { get; set; }
        public string diachi { get; set; }
        public string sdt { get; set; }
        public int? soluongtaikhoan { get; set; }

        public SelectList listgc { get; set; }
        public SelectList listtinhtrang { get; set; }
        public string mahddk { get; set; }
    }
}
