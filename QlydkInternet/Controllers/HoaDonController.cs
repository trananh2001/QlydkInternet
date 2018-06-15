using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace QlydkInternet.Controllers
{
    public class HoaDonController : Controller
    {
        private IServices services;

        public HoaDonController(IServices iservice)
        {
            services = iservice;
        }

        public async Task<IActionResult> ThanhToanHDDK(string mahoadon)
        {
            services.ThanhToanHoaDon(mahoadon);
            return RedirectToAction("HDDKDetails", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahoadon }));
        }
        public IActionResult HDDKDetails(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hoadon = services.TimHoaDon(id);
            return View(hoadon);
        }
        public IActionResult TaoHDDK(string mahopdong)
        {
            var hoadon = services.TaoHoaDonDK(mahopdong, HttpContext.Session.GetString("id"));
            return RedirectToAction("HDDKDetails", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = hoadon }));
        }
        public async Task<IActionResult> Index(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hoadon = services.GetAllHoaDon();
            hoadon = hoadon.OrderBy(m=>m.ngaythanhtoan.Value);
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<HoaDonViewModel>.
                        CreateAsync(hoadon, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }
        public async Task<IActionResult> HDDK(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hoadon = services.GetAllHoaDonDK();
            hoadon = hoadon.OrderBy(m => m.ngaythanhtoan);
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<HoaDonViewModel>.
                        CreateAsync(hoadon, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }
        //public IActionResult ChiTiet()
        //{
        //    return View();
        //}

        public IActionResult Details(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hoadon = services.TimHoaDon(id);
            return View(hoadon);
        }
        public async Task<IActionResult> TimKiem(string mahoadon)
        {
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahoadon }));
        }
        public async Task<IActionResult> ThanhToan(string mahoadon)
        {
            services.ThanhToanHoaDon(mahoadon);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahoadon }));
        }
        public async Task<IActionResult> TaoHoaDon(string id)
        {
            var user = HttpContext.Session.GetString("id");
            string mahoadon = "TT" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            var hopdong = services.TimHopDongTheoMa(id);
            var goicuoc = services.TimGoiCuocTheoMa(hopdong.magoicuoc);
            Hoadon hoadon = new Hoadon();
            hoadon.Mahopdong = id;
            hoadon.Makhachhang = hopdong.makhachhang;
            hoadon.Manhanvien = user;
            hoadon.Trigia = goicuoc.cuocthuebao;
            hoadon.Ngaylap = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            System.TimeSpan duration = new System.TimeSpan(15, 0, 0, 0);
            DateTime day = DateTime.Now.Add(duration);
            hoadon.Hanthanhtoan = DateTime.Parse(day.ToString("yyyy") + "-" + day.ToString("MM") + "-" + day.ToString("dd"));
            hoadon.Mahoadon = mahoadon;
            hoadon.Maloaihoadon = "ML002         ";
            hoadon.Matinhtrang = "TTHDON01      ";
            services.TaoHoaDonHangThang(hoadon);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahoadon }));
        }
        public async Task<IActionResult> Create(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hopdong = services.GetHopDongToiHan();
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            hopdong = hopdong.OrderByDescending(c => c.ngaydangky);
            var result = await PaginatedList<HopDongViewModel>.
                        CreateAsync(hopdong, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create(string mahd)
        //{
        //    string mahoadon = "HDT" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
        //    //services.TaoHoaDonHangThang(mahd, mahoadon);
        //    return RedirectToAction("Details", new RouteValueDictionary(
        //        new { controller = "HoaDon", action = "Main", id = mahd }));
        //}
    }
}