using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
//using QlydkInternet.Models;
namespace QlydkInternet.ViewModels
{
    public class GoiCuocViewModel
    {

        public string magoicuoc { get; set; }
        public string tengoicuoc { get; set; }
        public decimal? cuocthuebao { get; set; }
        public decimal? giacuocngay { get; set; }
        public decimal? giacuocdem { get; set; }
        public string matinhtrang { get; set; }
        public string tentinhtrang { get; set; }
        public SelectList listtinhtrang { get; set; }
    }
}
