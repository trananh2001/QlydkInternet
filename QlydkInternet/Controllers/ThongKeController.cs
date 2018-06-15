using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using QlydkInternet.Models;
using QlydkInternet.Helper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

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
            //ThongKeViewModel tk = new ThongKeViewModel();
            //tk.doanhthu = services.doanhthu(DateTime.Now);
            //tk.sodangkymoi = services.sodkmoi(DateTime.Now);
            //tk.thanhtoantre = services.thanhtoantre(DateTime.Now).ToList();
            //tk.time = DateTime.Now;
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            DoanhThuThangViewModel dthu = new DoanhThuThangViewModel();
            dthu.thongke = new List<ThongKeViewModel>();
            int month = Convert.ToInt32(DateTime.Now.ToString("MM"));
            for (int i = month; i > 0; i--)
            {
                ThongKeViewModel tk = new ThongKeViewModel();
                tk.doanhthu = services.doanhthu(i);
                tk.sodangkymoi = services.sodkmoi(i);
                //tk.thanhtoantre = services.thanhtoantre(DateTime.Now).ToList();
                string m;
                if (i < 10)
                {
                    m = "0" + i.ToString();
                }
                else
                    m = i.ToString();
                //tk.time = DateTime.Now;
                string year = DateTime.Now.ToString("yyyy");
                tk.time = DateTime.Parse(year + "-" + m + "-01");
                dthu.tongdangky += tk.sodangkymoi;
                dthu.tongdoanhthu += tk.doanhthu.Value;
                dthu.thongke.Add(tk);
            }
            return View(dthu);
        }

        public async Task<IActionResult> HoaDonQuaHan(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            ThongKeViewModel tk = new ThongKeViewModel();
            tk.thanhtoantre = services.thanhtoantre(DateTime.Now).ToList();
            tk.time = DateTime.Now;
            int pageSize = 8;
            int numberOfDisplayPages = 5;
            var result = await PaginatedList<HoaDonViewModel>.
                        CreateAsync(tk.thanhtoantre.AsQueryable(), page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public async Task<IActionResult> DanhSachDinhChi(int? page, int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hopdong = services.GetHopDongDinhChi();
            hopdong = hopdong.OrderByDescending(c => c.ngayapdung);
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<HopDongViewModel>.
                        CreateAsync(hopdong, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }
    }
}