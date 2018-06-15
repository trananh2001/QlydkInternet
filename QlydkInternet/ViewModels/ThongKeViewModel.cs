using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.ViewModels
{
    public class ThongKeViewModel
    {
        public decimal? doanhthu { get; set; }
        public int sodangkymoi { get; set; }
        public DateTime time { get; set; }
        public List<HoaDonViewModel> thanhtoantre { get; set; }
    }
}
