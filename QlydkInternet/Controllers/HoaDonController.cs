﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QlydkInternet.Models;
using QlydkInternet.ViewModels;
using QlydkInternet.Services;

namespace QlydkInternet.Controllers
{
    public class HoaDonController : Controller
    {
        private IServices services;

        public HoaDonController(IServices iservice)
        {
            services = iservice;
        }
        public async Task<IActionResult> Index(int? page,
                                               int? firstShowedPage, int? lastShowedPage)
        {
            var goicuoc = services.GetAllHoaDon();
            int pageSize = 8;
            int numberOfDisplayPages = 5;
            // page = 1;
            var result = await PaginatedList<HoaDonViewModel>.
                        CreateAsync(goicuoc, page ?? 1, pageSize,
                                    numberOfDisplayPages,
                                    firstShowedPage, lastShowedPage);
            return View(result);
        }

        public IActionResult ChiTiet()
        {
            return View();
        }
    }
}