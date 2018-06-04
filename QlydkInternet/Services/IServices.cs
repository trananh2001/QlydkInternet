using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QlydkInternet.ViewModels;
namespace QlydkInternet.Services
{
    public interface IServices
    {
        IQueryable<GoiCuocViewModel> GetAllGoiCuoc();
        IQueryable<KhuyenMaiViewModel> GetAllKhuyenMai();
        IQueryable<HopDongViewModel> GetAllHopDong();
        IQueryable<HoaDonViewModel> GetAllHoaDon();
    }
}
