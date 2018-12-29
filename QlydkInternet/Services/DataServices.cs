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
        public decimal doanhthu(int month)
        {
            decimal re = 0;
            string m;
            //string month = date.ToString("MM");
            if (month < 10)
            {
                m = "0" + month.ToString();
            }
            else
                m = month.ToString();
            string year = DateTime.Now.ToString("yyyy");
            DateTime start = DateTime.Parse(year+"-"+m+"-01");
            DateTime end;
            if (month == 2)
            {
                end = DateTime.Parse(year + "-" + m + "-28");
            }
            else
                end = DateTime.Parse(year+"-"+m+"-30");
            var hd = from hoadon in _context.Hoadon
                     join khachhang in _context.Khachhang
                     on hoadon.Makh equals khachhang.Makh
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manv equals nhanvien.Manv
                     where hoadon.Ngaythanhtoan != null && hoadon.Ngaythanhtoan > start && hoadon.Ngaythanhtoan < end
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
                         hanhoadon = hoadon.Hanhoadon,
                     };
            foreach (var item in hd)
            {
                re += item.trigia;
            }
            return re;
        }
        public int sodkmoi(int month)
        {
            int re = 0;
            string m;
            //string month = date.ToString("MM");
            if (month < 10)
            {
                m = "0" + month.ToString();
            }
            else
                m = month.ToString();
            string year = DateTime.Now.ToString("yyyy");
            DateTime start = DateTime.Parse(year +"-"+ m + "-01");
            DateTime end = DateTime.Parse(year + "-" + m + "-28");
            int count = _context.Phieudangky.Where(a => a.Ngdk > start && a.Ngdk < end).Count();
            return count;
        }

        public IQueryable<HoaDonViewModel> thanhtoantre(DateTime date)
        {
            var re = from hoadon in _context.Hoadon
                     join khachhang in _context.Khachhang
                     on hoadon.Makh equals khachhang.Makh
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manv equals nhanvien.Manv
                     where (hoadon.Ngaythanhtoan == null && DateTime.Now > hoadon.Hanhoadon)
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
                         hanhoadon = hoadon.Hanhoadon,
                     };
            return re;
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
                         cmnd = khachhang.Cmnd,
                         sdt = khachhang.Sdt,
                         email = khachhang.Email,
                         diachi = khachhang.Diachi,
                         nghenghiep = khachhang.Nghenghiep,
                         ngdk = hopdong.Ngdk,
                         ngad = hopdong.Ngad,
                         doituong = hopdong.Doituong,
                         dccaidat = hopdong.Dccaidat,
                         dchoadon = hopdong.Dchoadon,
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
        public void TaoHoaDonHangThang(Hoadon hoadon)
        {
            _context.Hoadon.Add(hoadon);
            _context.SaveChanges();
        }
        public Hoadon TimHoaDonTheoMaKH(string ma)
        {
            var re = from hoadon in _context.Hoadon
                     where hoadon.Makh == ma
                     orderby hoadon.Ngayin descending
                     select hoadon;
            return re.FirstOrDefault();

           // return _context.Hoadon.FirstOrDefault(i => i.Makh == ma);
        }
        public HoaDonViewModel TimHoaDon(string ma)
        {
            var re = from hoadon in _context.Hoadon
                     join kh in _context.Khachhang
                     on hoadon.Makh equals kh.Makh
                     join nv in _context.Nhanvien
                     on hoadon.Manv equals nv.Manv
                     where hoadon.Sohd == ma
                     select new HoaDonViewModel
                     {
                         sohd = hoadon.Sohd,
                         ngin = hoadon.Ngayin,
                         ngthanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         makh = hoadon.Makh,
                         tenkh = kh.Hoten,
                         manv = hoadon.Manv,
                         tennv = nv.Hoten,
                         hanhoadon = hoadon.Hanhoadon
                     };
            return re.First();
        }
        public Apdung TimApDungKM(string makh)
        {
            var re = from ad in _context.Apdung
                     where ad.Makh == makh
                     orderby ad.Ngad descending
                     select ad;

            return re.FirstOrDefault();
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

            foreach (var item in re.ToList())
            {
                var hdon = TimHoaDonTheoMaKH(item.makh);
                if (hdon == null)
                {
                    if (DateTime.Now.Subtract(item.ngad).TotalDays < 20)
                    {
                        re.Remove(item);
                    }
                }
                else
                {
                    if (DateTime.Now.Subtract(hdon.Ngayin).TotalDays < 20)
                    {
                        re.Remove(item);
                    }
                }
                
            }
            foreach (var item in re.ToList())
            {
                var ad = TimApDungKM(item.makh);
                if (ad != null)
                {
                    var km = TimKhuyenMaiTheoMa(ad.Makm);
                    if (DateTime.Now.Subtract(ad.Ngad).TotalDays < 30 * km.trigia)
                    {
                        re.Remove(item);
                    }
                }
            }
            var res = re.AsQueryable();
            return res;
        }

        public void CapNhatGoiCuoc(string Magc, string Tengc, string Loaigc, string Tocdo, decimal Giacuoc, string Mota)
        {
            var goicuoc = _context.Goicuoc.Where(m => m.Magc == Magc).FirstOrDefault();
            goicuoc.Tengc = Tengc;
            goicuoc.Loaigc = Loaigc;
            goicuoc.Tocdo = Tocdo;
            goicuoc.Giacuoc = Giacuoc;
            goicuoc.Mota = Mota;
            _context.SaveChanges();
        }

        public void CapNhatKhuyenMai(string Makm, string Tenkm, string Loaikm, string Loaigc, string Mota, DateTime Ngbd, DateTime? Ngkt, int? Trigia)
        {
            var khuyenmai = _context.Khuyenmai.Where(m => m.Makm == Makm).FirstOrDefault();
            khuyenmai.Tenkm = Tenkm;
            khuyenmai.Loaikm = Loaikm;
            khuyenmai.Loaigc = Loaigc;
            khuyenmai.Mota = Mota;
            khuyenmai.Ngbd = Ngbd;
            khuyenmai.Ngkt = Ngkt;
            khuyenmai.Trigia = Trigia;
            _context.SaveChanges();
        }

        public void CapNhatHopDong(string Maphieu, DateTime Ngad, string Doituong, string Dccaidat, string Dchoadon, string Matkhau, string Loaitt, string Tinhtrang, string Makh, string Magc, string Hoten, DateTime Ngsinh, string Sdt, string Nghenghiep, string Email, string Diachi, string Cmnd)
        {
            var hopdong = _context.Phieudangky.Where(m => m.Maphieu == Maphieu).FirstOrDefault();
            var khachhang = _context.Khachhang.Where(m => m.Makh == Makh).FirstOrDefault();
            hopdong.Ngad = Ngad;
            hopdong.Doituong = Doituong;
            hopdong.Dccaidat = Dccaidat;
            hopdong.Dchoadon = Dchoadon;
            hopdong.Tinhtrang = Tinhtrang;
            hopdong.Matkhau = Matkhau;
            hopdong.Loaitt = Loaitt;
            hopdong.Magc = Magc;
            khachhang.Hoten = Hoten;
            khachhang.Ngsinh = Ngsinh;
            khachhang.Sdt = Sdt;
            khachhang.Nghenghiep = Nghenghiep;
            khachhang.Email = Email;
            khachhang.Diachi = Diachi;
            khachhang.Cmnd = Cmnd;
            _context.SaveChanges();
        }
    }
}
