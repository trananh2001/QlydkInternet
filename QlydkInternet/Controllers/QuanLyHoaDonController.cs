using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QlydkInternet.Controllers
{
    public class QuanLyHoaDonController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TaoHoaDon()
        {
            return View();
        }
    }
}