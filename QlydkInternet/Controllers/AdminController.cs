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
using Microsoft.AspNetCore.Http;


namespace QlydkInternet.Controllers
{
    public class AdminController : Controller
    {
        private IServices services;

        public AdminController(IServices iservice)
        {
            services = iservice;
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("user", "null");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Taikhoan, string Matkhau)
        {
            var user = services.TimNhanVien(Taikhoan, Matkhau);
            HttpContext.Session.SetString("user", user.Hoten);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}