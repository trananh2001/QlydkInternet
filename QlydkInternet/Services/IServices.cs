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
        Nhanvien TimNhanVien(string taikhoan, string mk);
        IQueryable<HoaDonViewModel> thanhtoantre(DateTime date);
        void ThanhToanHoaDon(string mahdon);
        int sodkmoi(int m);
        decimal doanhthu(int m);
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
        void TaoHopDong(Phieudangky hd);
        void TaoKhachHang(Khachhang kh);
        IEnumerable<Loaithanhtoan> GetAllLoaiThanhToan();
        IEnumerable<Goicuoc> GetAllGC();
        void TaoHoaDonHangThang(Hoadon hoadon);
        IQueryable<HopDongViewModel> GetHopDongToiHan();
        Hoadon TimHoaDonTheoMaKH(string ma);
        HoaDonViewModel TimHoaDon(string ma);
        void CapNhatGoiCuoc(string Magc, string Tengc, string Loaigc, string Tocdo, decimal Giacuoc, string Mota);
        void CapNhatKhuyenMai(string Makm, string Tenkm, string Loaikm, string Loaigc, string Mota, DateTime Ngbd, DateTime? Ngkt, int? Trigia);
        void CapNhatHopDong(string Maphieu, DateTime Ngad, string Doituong, string Dccaidat, string Dchoadon, string Matkhau, string Loaitt, string Tinhtrang, string Makh, string Magc, string Hoten, DateTime Ngsinh, string Sdt, string Nghenghiep, string Email, string Diachi, string Cmnd);

    }
}
