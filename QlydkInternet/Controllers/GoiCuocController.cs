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
    public class GoiCuocController : Controller
    {
        private IServices services;

        public GoiCuocController(IServices iservice)
        {
            services = iservice;
        }
        public async Task<IActionResult> Index(int? page,
                                               int? firstShowedPage, int? lastShowedPage)
        {
            var goicuoc = services.GetAllGoiCuoc();
            int pageSize = 8;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<GoiCuocViewModel>.
                        CreateAsync(goicuoc, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public IActionResult Create()
        {
            var loaigc = services.GetAllLoaiGoiCuoc();
            var model = new GoiCuocViewModel();
            model.listloaigc = new SelectList(loaigc, "Maloai", "Tenloai", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tengc, string loaigc, string tocdo, decimal giacuoc, string mota)
        {
            Goicuoc goicuoc = new Goicuoc();
            goicuoc.Magc = DateTime.Now.ToString("dd") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("yy") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            goicuoc.Tengc = tengc;
            goicuoc.Loaigc = loaigc;
            goicuoc.Tocdo = tocdo;
            goicuoc.Giacuoc = giacuoc;
            goicuoc.Mota = mota;
            services.TaoGoiCuoc(goicuoc);
            var noti = new Notification
            {
                Title = "Thành Công",
                Content = "Tạo phiếu trả hàng thành công",
                Icon = "checkmark",
                MessageType = "positive",
            };
            return RedirectToAction("Details", new RouteValueDictionary(
    new { controller = "GoiCuoc", action = "Main", id = goicuoc.Magc }));
        }

        public IActionResult Details(string id)
        {
            var goicuoc = services.TimGoiCuocTheoMa(id);
            return View(goicuoc);
        }
    }
}