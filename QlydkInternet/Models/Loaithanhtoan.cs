using System;
using System.Collections.Generic;

namespace QlydkInternet.Models
{
    public partial class Loaithanhtoan
    {
        public Loaithanhtoan()
        {
            Phieudangky = new HashSet<Phieudangky>();
        }

        public string Maloai { get; set; }
        public string Tenloai { get; set; }

        public ICollection<Phieudangky> Phieudangky { get; set; }
    }
}
