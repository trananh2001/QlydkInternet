using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using Microsoft.AspNetCore.Routing;

namespace QlydkInternet.Controllers
{
    public class HoaDonController : Controller
    {
        private IServices services;

        public HoaDonController(IServices iservice)
        {
            services = iservice;
        }
        public async Task<IActionResult> Index(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var hoadon = services.GetAllHoaDon();
            hoadon = hoadon.OrderBy(m => m.ngthanhtoan);
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<HoaDonViewModel>.
                        CreateAsync(hoadon, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public IActionResult ChiTiet()
        {
            return View();
        }

        public IActionResult Details(string id)
        {
            var hoadon = services.TimHoaDon(id);
            return View(hoadon);
        }
        public async Task<IActionResult> TimKiem(string sohd)
        {
            
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = sohd }));
        }
        public async Task<IActionResult> ThanhToan(string sohd)
        {
            services.ThanhToanHoaDon(sohd);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = sohd }));
        }
        public async Task<IActionResult> TaoHoaDon(string id)
        {
            string mahoadon = "TT" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            var hopdong = services.TimHopDongTheoMa(id);
            var goicuoc = services.TimGoiCuocTheoMa(hopdong.magc);
            Hoadon hoadon = new Hoadon();
            hoadon.Makh = hopdong.makh;
            hoadon.Manv = "NV001";
            hoadon.Trigia = goicuoc.giacuoc;
            hoadon.Ngayin = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            System.TimeSpan duration = new System.TimeSpan(15, 0, 0, 0);
            DateTime day = DateTime.Now.Add(duration);
            hoadon.Hanhoadon = DateTime.Parse(day.ToString("yyyy") + "-" + day.ToString("MM") + "-" + day.ToString("dd"));
            hoadon.Sohd = mahoadon;
            services.TaoHoaDonHangThang(hoadon);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahoadon }));
        }
        public async Task<IActionResult> Create(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var hopdong = services.GetHopDongToiHan();
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            hopdong = hopdong.OrderByDescending(c => c.ngdk);
            var result = await PaginatedList<HopDongViewModel>.
                        CreateAsync(hopdong, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string mahd)
        {
            string mahoadon = "HDT" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            //services.TaoHoaDonHangThang(mahd, mahoadon);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HoaDon", action = "Main", id = mahd }));
        }
    }
}