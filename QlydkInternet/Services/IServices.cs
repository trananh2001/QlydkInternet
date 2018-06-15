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
        void DinhChi(string mahopdong);
        string TimHoaDonDangKy(string mahopdong);
        IQueryable<HopDongViewModel> GetHopDongDinhChi();
        string TaoHoaDonDK(string mahopdong, string manv);
        Nhanvien TimNhanVien(string taikhoan, string mk);
        IQueryable<HoaDonViewModel> thanhtoantre(DateTime date);
        void ThanhToanHoaDon(string mahdon);
        int sodkmoi(int m);
        decimal? doanhthu(int m);
        IQueryable<GoiCuocViewModel> GetAllGoiCuoc();
        IQueryable<KhuyenMaiViewModel> GetAllKhuyenMai();
        IQueryable<HopDongViewModel> GetAllHopDong();
        IQueryable<HoaDonViewModel> GetAllHoaDon();
        IQueryable<HoaDonViewModel> GetAllHoaDonDK();
        
        void TaoGoiCuoc(Goicuoc goicuoc);
        IEnumerable<Loaikhuyenmai> GetAllLoaiKhuyenMai();
        GoiCuocViewModel TimGoiCuocTheoMa(string ma);
        KhuyenMaiViewModel TimKhuyenMaiTheoMa(string ma);
        void TaoKhuyenMai(Khuyenmai km);
        HopDongViewModel TimHopDongTheoMa(string ma);
        void TaoHopDong(Hopdong hd);
        void TaoKhachHang(Khachhang kh);
        IEnumerable<Goicuoc> GetAllGC();
        void TaoHoaDonHangThang(Hoadon hoadon);
        IQueryable<HopDongViewModel> GetHopDongToiHan();
        Hoadon TimHoaDonTheoMaKH(string ma);
        HoaDonViewModel TimHoaDon(string ma);
        void CapNhatGoiCuoc(string Magc, string Tengc, decimal cuocthuebao, decimal giacuocngay, decimal giacuocdem, string matinhtrang);
        void CapNhatKhuyenMai(string makhuyenmai, string tenkhuyenmai, string maloaikhuyenmai, string ngaybatdau, string ngayketthuc, int trigia, string matinhtrang);
        void CapNhatHopDong(string mahopdong, string diachicaidat, string diachithanhtoan, string tenkhachhang, string magoicuoc, string matinhtrang, string cmnd, string nghenghiep, string email, string diachi, string soluongtaikhoan, string sdt, string ngayapdung);
        IEnumerable<Tinhtrang> GetAllTinhTrang();

    }
}
