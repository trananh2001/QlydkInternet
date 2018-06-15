using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using QlydkInternet.Models;
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
            //HttpContext.Session.SetString("user", "null");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(string Tendangnhap, string Matkhau)
        {
            var user = services.TimNhanVien(Tendangnhap, Matkhau);
            if (user == null)
                return RedirectToAction("Error", "Admin");
            HttpContext.Session.SetString("user", user.Tennv);
            HttpContext.Session.SetString("id", user.Manv);
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Logout()
        {

            HttpContext.Session.SetString("user", "null");
            HttpContext.Session.SetString("id", "null");
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult Error()
        {
            return View();
        }
    }
}