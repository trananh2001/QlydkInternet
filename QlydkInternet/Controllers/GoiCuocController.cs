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
using Microsoft.AspNetCore.Http;

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
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var goicuoc = services.GetAllGoiCuoc();
            goicuoc = goicuoc.OrderByDescending(c => c.magoicuoc);
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
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            var tinhtrang = services.GetAllTinhTrang();
            var model = new GoiCuocViewModel();
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tengoicuoc, decimal cuocthuebao, decimal giacuocdem, decimal giacuocngay)
        {
            Goicuoc goicuoc = new Goicuoc();
            goicuoc.Magoicuoc = "GC" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            goicuoc.Tengoicuoc = tengoicuoc;
            goicuoc.Cuocthuebao = cuocthuebao;
            goicuoc.Giacuocdem = giacuocdem;
            goicuoc.Giacuocngay = giacuocngay;
            goicuoc.Matinhtrang = "TTKM01";
            services.TaoGoiCuoc(goicuoc);
            return RedirectToAction("Details", new RouteValueDictionary(
    new { controller = "GoiCuoc", action = "Main", id = goicuoc.Magoicuoc }));
        }

        public IActionResult Details(string id)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            var goicuoc = services.TimGoiCuocTheoMa(id);
            return View(goicuoc);
        }

        public IActionResult Update(string magoicuoc)
        {
            var user = HttpContext.Session.GetString("user");
            if (user == "null" || user == null)
                return RedirectToAction("Index", "Admin");
            ViewBag.sessionnv = user;
            var tinhtrang = services.GetAllTinhTrang();
            var model = services.TimGoiCuocTheoMa(magoicuoc);
            model.listtinhtrang = new SelectList(tinhtrang, "Matinhtrang", "Tentinhtrang", 1);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(string magoicuoc, string tengoicuoc, decimal cuocthuebao, decimal giacuocdem, decimal giacuocngay, string matinhtrang)
        {

            services.CapNhatGoiCuoc(magoicuoc,tengoicuoc,cuocthuebao,giacuocngay,giacuocdem,matinhtrang);
            return RedirectToAction("Details", new RouteValueDictionary(
                new { controller = "GoiCuoc", action = "Main", id = magoicuoc }));
        }
    }
}