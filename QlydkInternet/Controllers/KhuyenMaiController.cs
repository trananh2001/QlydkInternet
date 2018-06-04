using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;
using QlydkInternet;

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
    }
}