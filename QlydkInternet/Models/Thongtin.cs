using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Thongtin
    {
        public int Id { get; set; }
        public string Tieusu { get; set; }
        public string Manv { get; set; }

        public Nhanvien ManvNavigation { get; set; }
    }
}
