using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;

namespace QlydkInternet.Controllers
{
    public class HopDongController : Controller
    {
        private IServices services;

        public HopDongController(IServices iservice)
        {
            services = iservice;
        }
        public async Task<IActionResult> Index(int? page,
                                               int? firstShowedPage, int? lastShowedPage)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hopdong = services.GetAllHopDong();
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

        public IActionResult Details(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var hopdong = services.TimHopDongTheoMa(id);
            hopdong.mahddk = services.TimHoaDonDangKy(id);
            return View(hopdong);
        }
        public async Task<IActionResult> DinhChi(string mahopdong)
        {
            services.DinhChi(mahopdong);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "HopDong", action = "Main", id = mahopdong }));
        }
        public IActionResult Create(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var goicuoc = services.GetAllGC();
            var tinhtrang = services.GetAllTinhTrang();
            var model = new HopDongViewModel();
            model.listgc = new SelectList(goicuoc, "Magoicuoc", "Tengoicuoc", 1);
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string ngayapdung, string diachicaidat, string diachithanhtoan, string tenkhachhang, string magoicuoc, string matinhtrang, string cmnd, string nghenghiep, string email, string diachi, string soluongtaikhoan, string sdt)
        {
            Khachhang kh = new Khachhang();
            Hopdong hd = new Hopdong();
            kh.Makhachhang = "KH" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            hd.Mahopdong = "HD" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");

            kh.Tenkhachhang = tenkhachhang;
            kh.Cmnd = cmnd;
            kh.Sdt = sdt;
            kh.Email = email;
            kh.Diachi = diachi;
            kh.Nghenghiep = nghenghiep;

            services.TaoKhachHang(kh);
            if (matinhtrang != "TTHOPDONG01   " && matinhtrang != "TTHOPDONG02   ")
            {
                string[] date = ngayapdung.Split("/");
                string time = "";
                if (date[1].Length == 1)
                {
                    time = date[2] + "-0" + date[1] + "-" + date[0];
                }
                else
                {
                    time = date[2] + "-" + date[1] + "-" + date[0];
                }
                hd.Ngayapdung = DateTime.Parse(time);
                
            }
            hd.Ngaydangky = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            hd.Diachicaidat = diachicaidat;
            hd.Diachithanhtoan = diachithanhtoan;
            hd.Magiocuoc = magoicuoc;
            hd.Makhachhang = kh.Makhachhang;
            hd.Matinhtrang = matinhtrang;
            hd.Manv = HttpContext.Session.GetString("id");
            services.TaoHopDong(hd);
            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "HopDong", action = "Details", id = hd.Mahopdong }));
        }

        public IActionResult Update(string mahopdong)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var model = services.TimHopDongTheoMa(mahopdong);
            var goicuoc = services.GetAllGC();
            var tinhtrang = services.GetAllTinhTrang();
            model.listgc = new SelectList(goicuoc, "Magoicuoc", "Tengoicuoc", 1);
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string mahopdong, string diachicaidat, string diachithanhtoan, string tenkhachhang, string magoicuoc, string matinhtrang, string cmnd, string nghenghiep, string email, string diachi, string soluongtaikhoan, string sdt, string ngayapdung)
        {
            services.CapNhatHopDong(mahopdong, diachicaidat, diachithanhtoan, tenkhachhang, magoicuoc, matinhtrang, cmnd, nghenghiep, email, diachi, soluongtaikhoan, sdt, ngayapdung);
            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "HopDong", action = "Details", id = mahopdong }));
        }
    }
}