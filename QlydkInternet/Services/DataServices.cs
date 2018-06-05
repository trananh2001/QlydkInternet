using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using QlydkInternet.ViewModels;
using QlydkInternet.Models;
using Microsoft.EntityFrameworkCore;

namespace QlydkInternet.Services
{
    public partial class DataServices : IServices
    {
        private QUANLYDANGKYINTERNETContext _context;

        public DataServices(QUANLYDANGKYINTERNETContext context)
        {
            _context = context;
        }
        public IQueryable<GoiCuocViewModel> GetAllGoiCuoc()
        {
            var re = from _goicuoc in _context.Goicuoc
                     join _loaigoicuoc in _context.Loaigoicuoc
                     on _goicuoc.Loaigc equals _loaigoicuoc.Maloai
                     select new GoiCuocViewModel
                     {
                         tengc = _goicuoc.Tengc,
                         magc = _goicuoc.Magc,
                         loaigc = _loaigoicuoc.Maloai,
                         tenloaigc = _loaigoicuoc.Tenloai,
                         tocdo = _goicuoc.Tocdo,
                         giacuoc = _goicuoc.Giacuoc,
                         mota = _goicuoc.Mota,
                         hinhanh = _goicuoc.Hinhanh
                     };
            return re;
        }

        public IQueryable<KhuyenMaiViewModel> GetAllKhuyenMai()
        {
            var re = from khuyenmai in _context.Khuyenmai
                     join loaikm in _context.Loaikhuyenmai
                     on khuyenmai.Loaikm equals loaikm.Maloai
                     join loaigc in _context.Loaigoicuoc
                     on khuyenmai.Loaigc equals loaigc.Maloai
                     select new KhuyenMaiViewModel
                     {
                         makm = khuyenmai.Makm,
                         tenkm = khuyenmai.Tenkm,
                         loaikm = loaikm.Maloai,
                         tenloaikm = loaikm.Tenloai,
                         loaigc = loaigc.Maloai,
                         tenloaigc = loaigc.Tenloai,
                         mota = khuyenmai.Mota,
                         ngbd = khuyenmai.Ngbd,
                         ngkt = khuyenmai.Ngkt
                     };
            return re;
        }

        public IQueryable<HopDongViewModel> GetAllHopDong()
        {
            var re = from hopdong in _context.Phieudangky
                     join khachhang in _context.Khachhang
                     on hopdong.Makh equals khachhang.Makh
                     join goicuoc in _context.Goicuoc
                     on hopdong.Magc equals goicuoc.Magc
                     join loaitt in _context.Loaithanhtoan
                     on hopdong.Loaitt equals loaitt.Maloai
                     select new HopDongViewModel
                     {
                         mahd = hopdong.Maphieu,
                         ngdk = hopdong.Ngdk,
                         ngad = hopdong.Ngad,
                         doituong = hopdong.Doituong,
                         dccaidat = hopdong.Dccaidat,
                         taikhoan = hopdong.Taikhoan,
                         matkhau = hopdong.Matkhau,
                         loaitt = hopdong.Loaitt,
                         tenloaitt = loaitt.Tenloai,
                         tinhtrang = hopdong.Tinhtrang,
                         makh = hopdong.Makh,
                         tenkh = khachhang.Hoten,
                         magc = hopdong.Magc,
                         tengc = goicuoc.Tengc
                     };
            return re;
        }

        public IQueryable<HoaDonViewModel> GetAllHoaDon()
        {
            var re = from hoadon in _context.Hoadon
                     join khachhang in _context.Khachhang
                     on hoadon.Makh equals khachhang.Makh
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manv equals nhanvien.Manv
                     select new HoaDonViewModel
                     {
                         sohd = hoadon.Sohd,
                         ngin = hoadon.Ngayin,
                         ngthanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         makh = hoadon.Makh,
                         tenkh = khachhang.Hoten,
                         manv = hoadon.Manv,
                         tennv = nhanvien.Hoten,
                         hanhoadon = hoadon.Hanhoadon
                     };
            return re;
        }

        public void TaoGoiCuoc(Goicuoc goicuoc)
        {
            _context.Goicuoc.Add(goicuoc);
            _context.SaveChanges();
        }
        public void TaoKhuyenMai(Khuyenmai km)
        {
            _context.Khuyenmai.Add(km);
            _context.SaveChanges();
        }
        public IEnumerable<Loaigoicuoc> GetAllLoaiGoiCuoc()
        {
            var query = from loaigc in _context.Loaigoicuoc
                        select loaigc;
            return query;
        }
        public IEnumerable<Loaithanhtoan> GetAllLoaiThanhToan()
        {
            var query = from loaitt in _context.Loaithanhtoan
                        select loaitt;
            return query;
        }
        public IEnumerable<Loaikhuyenmai> GetAllLoaiKhuyenMai()
        {
            var query = from loaikm in _context.Loaikhuyenmai
                        select loaikm;
            return query;
        }

        public IEnumerable<Goicuoc> GetAllGC()
        {
            var query = from gc in _context.Goicuoc
                        select gc;
            return query;
        }
        public GoiCuocViewModel TimGoiCuocTheoMa(string ma)
        {
            var re = from _goicuoc in _context.Goicuoc
                     join _loaigoicuoc in _context.Loaigoicuoc
                     on _goicuoc.Loaigc equals _loaigoicuoc.Maloai
                     where _goicuoc.Magc == ma
                     select new GoiCuocViewModel
                     {
                         tengc = _goicuoc.Tengc,
                         magc = _goicuoc.Magc,
                         loaigc = _loaigoicuoc.Maloai,
                         tenloaigc = _loaigoicuoc.Tenloai,
                         tocdo = _goicuoc.Tocdo,
                         giacuoc = _goicuoc.Giacuoc,
                         mota = _goicuoc.Mota,
                         hinhanh = _goicuoc.Hinhanh
                     };
            return re.First();
        }
        public KhuyenMaiViewModel TimKhuyenMaiTheoMa(string ma)
        {
            var re = from khuyenmai in _context.Khuyenmai
                     join loaikm in _context.Loaikhuyenmai
                     on khuyenmai.Loaikm equals loaikm.Maloai
                     join loaigc in _context.Loaigoicuoc
                     on khuyenmai.Loaigc equals loaigc.Maloai
                     where khuyenmai.Makm == ma
                     select new KhuyenMaiViewModel
                     {
                         makm = khuyenmai.Makm,
                         tenkm = khuyenmai.Tenkm,
                         loaikm = loaikm.Maloai,
                         tenloaikm = loaikm.Tenloai,
                         loaigc = loaigc.Maloai,
                         tenloaigc = loaigc.Tenloai,
                         mota = khuyenmai.Mota,
                         ngbd = khuyenmai.Ngbd,
                         ngkt = khuyenmai.Ngkt
                     };
            return re.First();
        }
        public HopDongViewModel TimHopDongTheoMa(string ma)
        {
            var re = from hopdong in _context.Phieudangky
                     join khachhang in _context.Khachhang
                     on hopdong.Makh equals khachhang.Makh
                     join goicuoc in _context.Goicuoc
                     on hopdong.Magc equals goicuoc.Magc
                     join loaitt in _context.Loaithanhtoan
                     on hopdong.Loaitt equals loaitt.Maloai
                     where hopdong.Maphieu == ma
                     select new HopDongViewModel
                     {
                         mahd = hopdong.Maphieu,
                         ngdk = hopdong.Ngdk,
                         ngad = hopdong.Ngad,
                         doituong = hopdong.Doituong,
                         dccaidat = hopdong.Dccaidat,
                         taikhoan = hopdong.Taikhoan,
                         matkhau = hopdong.Matkhau,
                         loaitt = hopdong.Loaitt,
                         tenloaitt = loaitt.Tenloai,
                         tinhtrang = hopdong.Tinhtrang,
                         makh = hopdong.Makh,
                         tenkh = khachhang.Hoten,
                         magc = hopdong.Magc,
                         tengc = goicuoc.Tengc
                     };
            return re.First();
        }

        public void TaoHopDong(Phieudangky hd)
        {
            _context.Phieudangky.Add(hd);
            _context.SaveChanges();
        }
        public void TaoKhachHang(Khachhang kh)
        {
            _context.Khachhang.Add(kh);
            _context.SaveChanges();
        }
        public void TaoHoaDonHangThang()
        {
            var hopdong = GetAllHopDong();

        }
        public Hoadon TimHoaDonTheoMaKH(string ma)
        {
            //var re = from hoadon in _context.Hoadon
            //         where hoadon.Makh == ma
            //         orderby hoadon.Ngayin descending
            //         select hoadon;
            //return re.First();

            return _context.Hoadon.First(i => i.Makh == ma);
        }
        public IQueryable<HopDongViewModel> GetHopDongToiHan()
        {
            var re = (from hopdong in _context.Phieudangky
                      join khachhang in _context.Khachhang
                      on hopdong.Makh equals khachhang.Makh
                      join goicuoc in _context.Goicuoc
                      on hopdong.Magc equals goicuoc.Magc
                      join loaitt in _context.Loaithanhtoan
                      on hopdong.Loaitt equals loaitt.Maloai
                      where hopdong.Ngad < DateTime.Now
                      select new HopDongViewModel
                      {
                          mahd = hopdong.Maphieu,
                          ngdk = hopdong.Ngdk,
                          ngad = hopdong.Ngad,
                          doituong = hopdong.Doituong,
                          dccaidat = hopdong.Dccaidat,
                          taikhoan = hopdong.Taikhoan,
                          matkhau = hopdong.Matkhau,
                          loaitt = hopdong.Loaitt,
                          tenloaitt = loaitt.Tenloai,
                          tinhtrang = hopdong.Tinhtrang,
                          makh = hopdong.Makh,
                          tenkh = khachhang.Hoten,
                          magc = hopdong.Magc,
                          tengc = goicuoc.Tengc
                      }).ToList();

            foreach (var item in re)
            {
                if (TimHoaDonTheoMaKH(item.makh) == null && DateTime.Now.Subtract(item.ngad).TotalDays < 25)
                {
                    re.Remove(item);
                }
                else
                {
                    if (DateTime.Now.Subtract(TimHoaDonTheoMaKH(item.makh).Ngayin).TotalDays < 25)
                    {
                        re.Remove(item);
                    }
                }
                
            }
            var res = re.AsQueryable();
            return res;
        }
    }
}
