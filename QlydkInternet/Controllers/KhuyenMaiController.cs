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
        public async Task<IActionResult> Create(string tenkm, string loaikm, string loaigc,string ngbd, string ngkt, int trigia, string mota)
        {
            Khuyenmai km = new Khuyenmai();
            km.Makm = "KM"+ DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            km.Tenkm = tenkm;
            km.Loaikm = loaikm;
            km.Loaigc = loaigc;
            string[] date = ngbd.Split("/");
            string time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            km.Ngbd = DateTime.Parse(time);
            date = ngkt.Split("/");
            time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            km.Ngkt = DateTime.Parse(time);
            km.Trigia = trigia;
            if (mota != null)
            {
                km.Mota = mota;
            }
            else
                km.Mota = "Không có mô tả";
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
