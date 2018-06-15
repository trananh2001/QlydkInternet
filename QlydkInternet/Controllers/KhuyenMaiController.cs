using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using QlydkInternet;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace QlydkInternet.Controllers
{
    public class KhuyenMaiController : Controller
    {
        private IServices services;

        public KhuyenMaiController(IServices iservice)
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
            var km = services.GetAllKhuyenMai();
            km = km.OrderByDescending(c => c.ngayketthuc);
            int pageSize = 10;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<KhuyenMaiViewModel>.
                        CreateAsync(km, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public IActionResult Create()
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var loaikm = services.GetAllLoaiKhuyenMai();
            var tinhtrang = services.GetAllTinhTrang();
            var model = new KhuyenMaiViewModel();
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            model.listloaikm = new SelectList(loaikm, "Maloaikhuyenmai", "Tenloaikhuyenmai", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tenkhuyenmai, string maloaikhuyenmai, string ngaybatdau, string ngayketthuc, int trigia, string matinhtrang)
        {
            Khuyenmai km = new Khuyenmai();
            km.Makhuyenmai = "KM" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            km.Tenkhuyenmai = tenkhuyenmai;
            km.Maloaikhuyenmai = maloaikhuyenmai;
            km.Matinhtrang = matinhtrang;
            string[] date = ngaybatdau.Split("/");
            string time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            km.Ngaybatdau = DateTime.Parse(time);
            date = ngayketthuc.Split("/");
            time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            km.Ngayketthuc = DateTime.Parse(time);
            km.Trigia = trigia;
            services.TaoKhuyenMai(km);

            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "KhuyenMai", action = "Details", id = km.Makhuyenmai }));
        }

        public IActionResult Details(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var khuyenmai = services.TimKhuyenMaiTheoMa(id);
            return View(khuyenmai);
        }

        public IActionResult Update(string makhuyenmai)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var model = services.TimKhuyenMaiTheoMa(makhuyenmai);
            var loaikm = services.GetAllLoaiKhuyenMai();
            var tinhtrang = services.GetAllTinhTrang();
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            model.listloaikm = new SelectList(loaikm, "Maloaikhuyenmai", "Tenloaikhuyenmai", 1);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string makhuyenmai,string tenkhuyenmai, string maloaikhuyenmai, string ngaybatdau, string ngayketthuc, int trigia, string matinhtrang)
        {

                services.CapNhatKhuyenMai(makhuyenmai,tenkhuyenmai,maloaikhuyenmai,ngaybatdau,ngayketthuc,trigia,matinhtrang);

            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "KhuyenMai", action = "Details", id = makhuyenmai }));
        }
    }
}
