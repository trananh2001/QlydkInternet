using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QlydkInternet.ViewModels
{
    public class DoanhThuThangViewModel
    {
        public List<ThongKeViewModel> thongke { get; set; }

        public decimal tongdoanhthu { get; set; }
        public int tongdangky { get; set; }
    }
}
