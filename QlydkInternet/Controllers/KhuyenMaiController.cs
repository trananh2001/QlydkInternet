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
            var goicuoc = services.GetAllKhuyenMai();
            int pageSize = 8;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<KhuyenMaiViewModel>.
                        CreateAsync(goicuoc, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public IActionResult Create()
        {
            var loaikm = services.GetAllLoaiKhuyenMai();
            var loaigc = services.GetAllLoaiGoiCuoc();
            var model = new KhuyenMaiViewModel();
            model.listloaigc = new SelectList(loaigc, "Maloai", "Tenloai", 1);
            model.listloaikm = new SelectList(loaikm, "Maloai", "Tenloai", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tenkm, string loaikm, string loaigc,DateTime ngbd, DateTime ngkt, int trigia, string mota)
        {
            Khuyenmai km = new Khuyenmai();
            km.Makm = DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            km.Tenkm = tenkm;
            km.Loaikm = loaikm;
            km.Loaigc = loaigc;
            //km.Ngbd = ngbd;
            //km.Ngbd = Convert.ToDateTime(String.Format(ngbd.ToString(), "yyyy/MM/dd"));
            //km.Ngkt = ngkt;
            //km.Ngkt = Convert.ToDateTime(String.Format(ngkt.ToString(), "yyyy/MM/dd"));
            km.Ngbd = DateTime.ParseExact(ngbd.ToString("dd/MM/yyyy"), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            km.Ngkt = DateTime.ParseExact(ngkt.ToString("dd/MM/yyyy"), "yy/MM/dd HH:mm:ss", CultureInfo.InvariantCulture);
            km.Trigia = trigia;
            km.Mota = mota;
            services.TaoKhuyenMai(km);
            
            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "KhuyenMai", action = "Details", id = km.Makm }));
        }

        public IActionResult Details(string id)
        {
            var khuyenmai = services.TimKhuyenMaiTheoMa(id);
            return View(khuyenmai);
        }
    }
}
