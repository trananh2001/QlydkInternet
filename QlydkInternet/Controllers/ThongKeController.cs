using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using QlydkInternet.ViewModels;
using QlydkInternet.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;

namespace QlydkInternet.Controllers
{
    public class ThongKeController : Controller
    {
        private IServices services;

        public ThongKeController(IServices iservice)
        {
            services = iservice;
        }
        public IActionResult Index()
        {
            ThongKeViewModel tk = new ThongKeViewModel();
            tk.doanhthu = services.doanhthu(DateTime.Now);
            tk.sodangkymoi = services.sodkmoi(DateTime.Now);
            tk.thanhtoantre = services.thanhtoantre(DateTime.Now).ToList();
            return View(tk);
        }
    }
}