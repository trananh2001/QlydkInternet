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
            goicuoc = goicuoc.OrderByDescending(c => c.magc);
            int pageSize = 10;
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
            goicuoc.Magc = "GC"+DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            goicuoc.Tengc = tengc;
            goicuoc.Loaigc = loaigc;
            goicuoc.Tocdo = tocdo;
            goicuoc.Giacuoc = giacuoc;
            if (mota != null)
            {
                goicuoc.Mota = mota;
            }
            else
                goicuoc.Mota = "Không có mô tả";
            services.TaoGoiCuoc(goicuoc);
            return RedirectToAction("Details", new RouteValueDictionary(
    new { controller = "GoiCuoc", action = "Main", id = goicuoc.Magc }));
        }

        public IActionResult Details(string id)
        {
            var goicuoc = services.TimGoiCuocTheoMa(id);
            return View(goicuoc);
        }

        public IActionResult Update(string magc)
        {
            var loaigc = services.GetAllLoaiGoiCuoc();
            var model = services.TimGoiCuocTheoMa(magc);
            model.listloaigc = new SelectList(loaigc, "Maloai", "Tenloai", 1);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string magc, string tengc, string loaigc, string tocdo, decimal giacuoc, string mota)
        {

            if (mota == null)
            {
                mota = "Không có mô tả";
            }

            services.CapNhatGoiCuoc(magc, tengc, loaigc, tocdo, giacuoc, mota);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "GoiCuoc", action = "Main", id = magc }));
        }
    }
}