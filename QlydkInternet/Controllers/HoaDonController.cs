﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace QlydkInternet.Controllers
{
    public class HoaDonController : Controller
    {
        public IActionResult TaoHoaDon()
        {
            return View();
        }

        public IActionResult ChiTiet()
        {
            return View();
        }
    }
}