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
            var hopdong = services.GetAllHopDong();
            hopdong = hopdong.OrderByDescending(c => c.ngdk);
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
            var hopdong = services.TimHopDongTheoMa(id);
            return View(hopdong);
        }
        public IActionResult Create(string id)
        {
            var loaitt = services.GetAllLoaiThanhToan();
            var goicuoc = services.GetAllGC();
            var model = new HopDongViewModel();
            model.listloaitt = new SelectList(loaitt, "Maloai", "Tenloai", 1);
            model.listgc = new SelectList(goicuoc, "Magc", "Tengc", 1);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string tenkh, string cmnd, string sdt, string email, string diachi, string ngad, string doituong, string ngsinh, string dccaidat, string dchoadon, string loaitt, string magc, string nghenghiep)
        {
            Khachhang kh = new Khachhang();
            Phieudangky hd = new Phieudangky();
            kh.Makh = "KH" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            hd.Maphieu = "HD" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");

            kh.Hoten = tenkh;
            kh.Cmnd = cmnd;
            kh.Sdt = sdt;
            kh.Email = email;
            kh.Diachi = diachi;
            string[] date = ngsinh.Split("/");
            string time = "";
            if (date[1].Length == 1)
            {
                string temp = date[1];
                date[1] = "0" + temp;
            }
            if (date[0].Length == 1)
            {
                string temp = date[0];
                date[0] = "0" + temp;
            }

            time = date[2] + "-" + date[1] + "-" + date[0];
            kh.Ngsinh = DateTime.Parse(time);
            kh.Nghenghiep = nghenghiep;

            services.TaoKhachHang(kh);

            date = ngad.Split("/");
            time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            hd.Ngad = DateTime.Parse(time);
            hd.Ngdk = DateTime.Parse(DateTime.Now.ToString("yyyy") +"-"+ DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            hd.Dccaidat = dccaidat;
            hd.Dchoadon = dchoadon;
            hd.Doituong = doituong;
            hd.Loaitt = loaitt;
            hd.Magc = magc;
            hd.Makh = kh.Makh;
            hd.Tinhtrang = "lưu thông";
            hd.Taikhoan = hd.Maphieu;
            hd.Matkhau = hd.Maphieu;

            services.TaoHopDong(hd);
            return RedirectToAction("Details", new RouteValueDictionary(
                    new { controller = "HopDong", action = "Details", id = hd.Maphieu }));
        }
    }
}