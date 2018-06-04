using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QlydkInternet.ViewModels;
using QlydkInternet.Models;
namespace QlydkInternet.Services
{
    public interface IServices
    {
        IQueryable<GoiCuocViewModel> GetAllGoiCuoc();
        IQueryable<KhuyenMaiViewModel> GetAllKhuyenMai();
        IQueryable<HopDongViewModel> GetAllHopDong();
        IQueryable<HoaDonViewModel> GetAllHoaDon();
        void TaoGoiCuoc(Goicuoc goicuoc);
        IEnumerable<Loaigoicuoc> GetAllLoaiGoiCuoc();
        IEnumerable<Loaikhuyenmai> GetAllLoaiKhuyenMai();
        GoiCuocViewModel TimGoiCuocTheoMa(string ma);
        KhuyenMaiViewModel TimKhuyenMaiTheoMa(string ma);
        void TaoKhuyenMai(Khuyenmai km);
        HopDongViewModel TimHopDongTheoMa(string ma);
    }
}
