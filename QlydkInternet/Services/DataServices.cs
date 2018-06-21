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
        private QUANLYINTERNETContext _context;

        public DataServices(QUANLYINTERNETContext context)
        {
            _context = context;
        }

        public string TimHoaDonDangKy(string mahopdong)
        {
            var re = _context.Hoadon.Where(m => m.Mahopdong == mahopdong && m.Maloaihoadon == "ML001         ").FirstOrDefault();
            if (re == null)
                return "";
            else return re.Mahoadon;
        }
        public string TaoHoaDonDK(string mahopdong, string manv)
        {
            Hoadon hoadon = new Hoadon();
            Hopdong hopdong = _context.Hopdong.Where(m => m.Mahopdong == mahopdong).FirstOrDefault();
            Khachhang kh = _context.Khachhang.Where(m => m.Makhachhang == hopdong.Makhachhang).FirstOrDefault();
            Nhanvien nv = _context.Nhanvien.Where(m => m.Manv == hopdong.Manv).FirstOrDefault();

            hoadon.Mahoadon = "TT" + DateTime.Now.ToString("yy") + DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd") + DateTime.Now.ToString("HH") + DateTime.Now.ToString("mm") + DateTime.Now.ToString("ss");
            hoadon.Maloaihoadon = "ML001         ";
            hoadon.Ngaylap = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            hoadon.Trigia = 100000;
            hoadon.Manhanvien = manv;
            hoadon.Mahopdong = mahopdong;
            hoadon.Makhachhang = hopdong.Makhachhang;
            hoadon.Matinhtrang = "TTHDON01      ";
            _context.Hoadon.Add(hoadon);
            _context.SaveChanges();
            return hoadon.Mahoadon;
        }

        public IEnumerable<Tinhtrang> GetAllTinhTrang()
        {
            var query = from tinhtrang in _context.Tinhtrang
                        select tinhtrang;
            return query;
        }
        public Nhanvien TimNhanVien(string taikhoan, string mk)
        {
            return _context.Nhanvien.Where(m => m.Tendangnhap == taikhoan && m.Matkhau == mk).FirstOrDefault();
        }
        public void ThanhToanHoaDon(string mahdon)
        {
            var hoadon = _context.Hoadon.Where(m => m.Mahoadon == mahdon).FirstOrDefault();
            hoadon.Ngaythanhtoan = DateTime.Parse(DateTime.Now.ToString("yyyy") + "-" + DateTime.Now.ToString("MM") + "-" + DateTime.Now.ToString("dd"));
            hoadon.Matinhtrang = "TTHDON02      ";
            _context.SaveChanges();
        }

        public void DinhChi(string mahopdong)
        {
            var hd = _context.Hopdong.Where(m=>m.Mahopdong == mahopdong).FirstOrDefault();
            if (hd.Matinhtrang == "TTHOPDONG04   ")
            {
                hd.Matinhtrang = "TTHOPDONG03   ";
            }
            else
            {
                hd.Matinhtrang = "TTHOPDONG04   ";
            }
            _context.SaveChanges();
        }
        public decimal? doanhthu(int month)
        {
            decimal? re = 0;
            string m;
            //string month = date.ToString("MM");
            if (month < 10)
            {
                m = "0" + month.ToString();
            }
            else
                m = month.ToString();
            string year = DateTime.Now.ToString("yyyy");
            DateTime start = DateTime.Parse(year + "-" + m + "-01");
            DateTime end;
            if (month == 2)
            {
                end = DateTime.Parse(year + "-" + m + "-28");
            }
            else
                end = DateTime.Parse(year + "-" + m + "-30");
            var hd = from hoadon in _context.Hoadon
                     join khachhang in _context.Khachhang
                     on hoadon.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manhanvien equals nhanvien.Manv
                     where hoadon.Ngaythanhtoan != null && hoadon.Ngaythanhtoan > start && hoadon.Ngaythanhtoan < end
                     select new HoaDonViewModel
                     {
                         trigia = hoadon.Trigia,
                     };
            foreach (var item in hd)
            {
                re += item.trigia;
            }
            return re;
        }
        public int sodkmoi(int month)
        {
            string m;
            //string month = date.ToString("MM");
            if (month < 10)
            {
                m = "0" + month.ToString();
            }
            else
                m = month.ToString();
            string year = DateTime.Now.ToString("yyyy");
            DateTime start = DateTime.Parse(year + "-" + m + "-01");
            DateTime end = DateTime.Parse(year + "-" + m + "-28");
            int count = _context.Hopdong.Where(a => a.Ngayapdung > start && a.Ngayapdung < end).Count();
            return count;
        }

        public IQueryable<HoaDonViewModel> thanhtoantre(DateTime date)
        {
            var re = from hoadon in _context.Hoadon
                     join hopdong in _context.Hopdong
                     on hoadon.Mahopdong equals hopdong.Mahopdong
                     join khachhang in _context.Khachhang
                     on hoadon.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manhanvien equals nhanvien.Manv
                     join loaihd in _context.Loaihoadon
                     on hoadon.Maloaihoadon equals loaihd.Maloaihoadon
                     join tinhtrang in _context.Tinhtrang
                     on hoadon.Matinhtrang equals tinhtrang.Matinhtrang
                     where (hoadon.Ngaythanhtoan == null && DateTime.Now > hoadon.Hanthanhtoan)
                     select new HoaDonViewModel
                     {
                         mahoadon = hoadon.Mahoadon,
                         ngaylap = hoadon.Ngaylap,
                         ngaythanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         hanthanhtoan = hoadon.Hanthanhtoan,
                         manhanvien = hoadon.Manhanvien,
                         tennhanvien = nhanvien.Tennv,
                         mahopdong = hoadon.Mahopdong,
                         maloaihoadon = hoadon.Maloaihoadon,
                         tenloaihoadon = loaihd.Tenloaihoadon,
                         makhachhang = hoadon.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         matinhtrang = hoadon.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re;
        }
        public IQueryable<GoiCuocViewModel> GetAllGoiCuoc()
        {
            var re = from goicuoc in _context.Goicuoc
                     join tinhtrang in _context.Tinhtrang
                     on goicuoc.Matinhtrang equals tinhtrang.Matinhtrang
                     select new GoiCuocViewModel
                     {
                        magoicuoc = goicuoc.Magoicuoc,
                        tengoicuoc = goicuoc.Tengoicuoc,
                        cuocthuebao = goicuoc.Cuocthuebao,
                        giacuocdem = goicuoc.Giacuocdem,
                        giacuocngay = goicuoc.Giacuocngay,
                        matinhtrang = goicuoc.Matinhtrang,
                        tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re;
        }

        public IQueryable<KhuyenMaiViewModel> GetAllKhuyenMai()
        {
            var re = from khuyenmai in _context.Khuyenmai
                     join loaikm in _context.Loaikhuyenmai
                     on khuyenmai.Maloaikhuyenmai equals loaikm.Maloaikhuyenmai
                     join tinhtrang in _context.Tinhtrang
                     on khuyenmai.Matinhtrang equals tinhtrang.Matinhtrang
                     select new KhuyenMaiViewModel
                     {
                         makhuyenmai = khuyenmai.Makhuyenmai,
                         tenkhuyenmai = khuyenmai.Tenkhuyenmai,
                         ngaybatdau = khuyenmai.Ngaybatdau,
                         ngayketthuc = khuyenmai.Ngayketthuc,
                         maloaikhuyenmai = khuyenmai.Maloaikhuyenmai,
                         tenloaikhuyenmai = loaikm.Tenloaikhuyenmai,
                         trigia = khuyenmai.Trigia,
                         matinhtrang = khuyenmai.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re;
        }

        public IQueryable<HopDongViewModel> GetAllHopDong()
        {
            var re = from hopdong in _context.Hopdong
                     join khachhang in _context.Khachhang
                     on hopdong.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hopdong.Manv equals nhanvien.Manv
                     join tinhtrang in _context.Tinhtrang
                     on hopdong.Matinhtrang equals tinhtrang.Matinhtrang
                     join goicuoc in _context.Goicuoc
                     on hopdong.Magiocuoc equals goicuoc.Magoicuoc
                     select new HopDongViewModel
                     {
                         mahopdong = hopdong.Mahopdong,
                         ngaydangky = hopdong.Ngaydangky,
                         ngayapdung = hopdong.Ngayapdung,
                         diachicaidat = hopdong.Diachicaidat,
                         diachithanhtoan = hopdong.Diachithanhtoan,
                         makhachhang = hopdong.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         magoicuoc = hopdong.Magiocuoc,
                         tengoicuoc = goicuoc.Tengoicuoc,
                         manhanvien = hopdong.Manv,
                         tennhanvien = nhanvien.Tennv,
                         matinhtrang = hopdong.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang,
                         cmnd = khachhang.Cmnd,
                         nghenghiep = khachhang.Nghenghiep,
                         email = khachhang.Email,
                         diachi = khachhang.Diachi,
                         soluongtaikhoan = khachhang.Soluongtaikhoan
                     };
            return re;
        }
        public IQueryable<HopDongViewModel> GetHopDongDinhChi()
        {
            var re = from hopdong in _context.Hopdong
                     join khachhang in _context.Khachhang
                     on hopdong.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hopdong.Manv equals nhanvien.Manv
                     join tinhtrang in _context.Tinhtrang
                     on hopdong.Matinhtrang equals tinhtrang.Matinhtrang
                     join goicuoc in _context.Goicuoc
                     on hopdong.Magiocuoc equals goicuoc.Magoicuoc
                     where hopdong.Matinhtrang == "TTHOPDONG04   "
                     select new HopDongViewModel
                     {
                         mahopdong = hopdong.Mahopdong,
                         ngaydangky = hopdong.Ngaydangky,
                         ngayapdung = hopdong.Ngayapdung,
                         diachicaidat = hopdong.Diachicaidat,
                         diachithanhtoan = hopdong.Diachithanhtoan,
                         makhachhang = hopdong.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         magoicuoc = hopdong.Magiocuoc,
                         tengoicuoc = goicuoc.Tengoicuoc,
                         manhanvien = hopdong.Manv,
                         tennhanvien = nhanvien.Tennv,
                         matinhtrang = hopdong.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang,
                         cmnd = khachhang.Cmnd,
                         nghenghiep = khachhang.Nghenghiep,
                         email = khachhang.Email,
                         diachi = khachhang.Diachi,
                         soluongtaikhoan = khachhang.Soluongtaikhoan
                     };
            return re;
        }
        public IQueryable<HoaDonViewModel> GetAllHoaDonDK()
        {
            var re = from hoadon in _context.Hoadon
                     join hopdong in _context.Hopdong
                     on hoadon.Mahopdong equals hopdong.Mahopdong
                     join khachhang in _context.Khachhang
                     on hopdong.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manhanvien equals nhanvien.Manv
                     join loaihd in _context.Loaihoadon
                     on hoadon.Maloaihoadon equals loaihd.Maloaihoadon
                     join tinhtrang in _context.Tinhtrang
                     on hoadon.Matinhtrang equals tinhtrang.Matinhtrang
                     where hoadon.Maloaihoadon == "ML001         "
                     select new HoaDonViewModel
                     {
                         mahoadon = hoadon.Mahoadon,
                         ngaylap = hoadon.Ngaylap,
                         ngaythanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         hanthanhtoan = hoadon.Hanthanhtoan,
                         manhanvien = hoadon.Manhanvien,
                         tennhanvien = nhanvien.Tennv,
                         mahopdong = hoadon.Mahopdong,
                         maloaihoadon = hoadon.Maloaihoadon,
                         tenloaihoadon = loaihd.Tenloaihoadon,
                         makhachhang = hoadon.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         matinhtrang = hoadon.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re;
        }
        public IQueryable<HoaDonViewModel> GetAllHoaDon()
        {
            var re = from hoadon in _context.Hoadon
                     join hopdong in _context.Hopdong
                     on hoadon.Mahopdong equals hopdong.Mahopdong
                     join khachhang in _context.Khachhang
                     on hopdong.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manhanvien equals nhanvien.Manv
                     join loaihd in _context.Loaihoadon
                     on hoadon.Maloaihoadon equals loaihd.Maloaihoadon
                     join tinhtrang in _context.Tinhtrang
                     on hoadon.Matinhtrang equals tinhtrang.Matinhtrang
                     where hoadon.Maloaihoadon != "ML001         "
                     select new HoaDonViewModel
                     {
                         mahoadon = hoadon.Mahoadon,
                         ngaylap = hoadon.Ngaylap,
                         ngaythanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         hanthanhtoan = hoadon.Hanthanhtoan,
                         manhanvien = hoadon.Manhanvien,
                         tennhanvien = nhanvien.Tennv,
                         mahopdong = hoadon.Mahopdong,
                         maloaihoadon = hoadon.Maloaihoadon,
                         tenloaihoadon = loaihd.Tenloaihoadon,
                         makhachhang = hoadon.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         matinhtrang = hoadon.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
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

            var re = from goicuoc in _context.Goicuoc
                     join tinhtrang in _context.Tinhtrang
                     on goicuoc.Matinhtrang equals tinhtrang.Matinhtrang
                     where goicuoc.Magoicuoc == ma
                     select new GoiCuocViewModel
                     {
                         magoicuoc = goicuoc.Magoicuoc,
                         tengoicuoc = goicuoc.Tengoicuoc,
                         cuocthuebao = goicuoc.Cuocthuebao,
                         giacuocdem = goicuoc.Giacuocdem,
                         giacuocngay = goicuoc.Giacuocngay,
                         matinhtrang = goicuoc.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re.First();
        }
        public KhuyenMaiViewModel TimKhuyenMaiTheoMa(string ma)
        {

            var re = from khuyenmai in _context.Khuyenmai
                     join loaikm in _context.Loaikhuyenmai
                     on khuyenmai.Maloaikhuyenmai equals loaikm.Maloaikhuyenmai
                     join tinhtrang in _context.Tinhtrang
                     on khuyenmai.Matinhtrang equals tinhtrang.Matinhtrang
                     where khuyenmai.Makhuyenmai == ma
                     select new KhuyenMaiViewModel
                     {
                         makhuyenmai = khuyenmai.Makhuyenmai,
                         tenkhuyenmai = khuyenmai.Tenkhuyenmai,
                         ngaybatdau = khuyenmai.Ngaybatdau,
                         ngayketthuc = khuyenmai.Ngayketthuc,
                         maloaikhuyenmai = khuyenmai.Maloaikhuyenmai,
                         tenloaikhuyenmai = loaikm.Tenloaikhuyenmai,
                         trigia = khuyenmai.Trigia,
                         matinhtrang = khuyenmai.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang
                     };
            return re.First();
        }
        public HopDongViewModel TimHopDongTheoMa(string ma)
        {
            var re = from hopdong in _context.Hopdong
                     join khachhang in _context.Khachhang
                     on hopdong.Makhachhang equals khachhang.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hopdong.Manv equals nhanvien.Manv
                     join tinhtrang in _context.Tinhtrang
                     on hopdong.Matinhtrang equals tinhtrang.Matinhtrang
                     join goicuoc in _context.Goicuoc
                     on hopdong.Magiocuoc equals goicuoc.Magoicuoc
                     where hopdong.Mahopdong == ma
                     select new HopDongViewModel
                     {
                         mahopdong = hopdong.Mahopdong,
                         ngaydangky = hopdong.Ngaydangky,
                         ngayapdung = hopdong.Ngayapdung,
                         diachicaidat = hopdong.Diachicaidat,
                         diachithanhtoan = hopdong.Diachithanhtoan,
                         makhachhang = hopdong.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         magoicuoc = hopdong.Magiocuoc,
                         tengoicuoc = goicuoc.Tengoicuoc,
                         manhanvien = hopdong.Manv,
                         tennhanvien = nhanvien.Tennv,
                         matinhtrang = hopdong.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang,
                         cmnd = khachhang.Cmnd,
                         nghenghiep = khachhang.Nghenghiep,
                         email = khachhang.Email,
                         diachi = khachhang.Diachi,
                         soluongtaikhoan = khachhang.Soluongtaikhoan,
                         sdt = khachhang.Sdt
                     };
            return re.First();
        }

        public void TaoHopDong(Hopdong hd)
        {
            _context.Hopdong.Add(hd);
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
                     where hoadon.Makhachhang == ma
                     orderby hoadon.Ngaylap descending
                     select hoadon;
            return re.FirstOrDefault();

            // return _context.Hoadon.FirstOrDefault(i => i.Makh == ma);
        }
        public HoaDonViewModel TimHoaDon(string ma)
        {
            var re = from hoadon in _context.Hoadon
                     join khachhang in _context.Khachhang
                     on hoadon.Makhachhang equals khachhang.Makhachhang
                     join hopdong in _context.Hopdong
                     on khachhang.Makhachhang equals hopdong.Makhachhang
                     join nhanvien in _context.Nhanvien
                     on hoadon.Manhanvien equals nhanvien.Manv
                     join loaihd in _context.Loaihoadon
                     on hoadon.Maloaihoadon equals loaihd.Maloaihoadon
                     join tinhtrang in _context.Tinhtrang
                     on hoadon.Matinhtrang equals tinhtrang.Matinhtrang
                     where hoadon.Mahoadon == ma
                     select new HoaDonViewModel
                     {
                         mahoadon = hoadon.Mahoadon,
                         ngaylap = hoadon.Ngaylap,
                         ngaythanhtoan = hoadon.Ngaythanhtoan,
                         trigia = hoadon.Trigia,
                         hanthanhtoan = hoadon.Hanthanhtoan,
                         manhanvien = hoadon.Manhanvien,
                         tennhanvien = nhanvien.Tennv,
                         mahopdong = hoadon.Mahopdong,
                         maloaihoadon = hoadon.Maloaihoadon,
                         tenloaihoadon = loaihd.Tenloaihoadon,
                         makhachhang = hoadon.Makhachhang,
                         tenkhachhang = khachhang.Tenkhachhang,
                         matinhtrang = hoadon.Matinhtrang,
                         tentinhtrang = tinhtrang.Tentinhtrang,
                         sdt = khachhang.Sdt,
                         email = khachhang.Email,
                         diachithanhtoan = hopdong.Diachithanhtoan
                     };
            return re.First();
        }
        public Apdung TimApDungKM(string mahd)
        {
            var re = from ad in _context.Apdung
                     where ad.Mahopdong == mahd
                     orderby ad.Makhuyenmai descending
                     select ad;

            return re.FirstOrDefault();
        }
        public IQueryable<HopDongViewModel> GetHopDongToiHan()
        {

            var re = (from hopdong in _context.Hopdong
                      join khachhang in _context.Khachhang
                      on hopdong.Makhachhang equals khachhang.Makhachhang
                      join nhanvien in _context.Nhanvien
                      on hopdong.Manv equals nhanvien.Manv
                      join tinhtrang in _context.Tinhtrang
                      on hopdong.Matinhtrang equals tinhtrang.Matinhtrang
                      join goicuoc in _context.Goicuoc
                      on hopdong.Magiocuoc equals goicuoc.Magoicuoc
                      where hopdong.Matinhtrang != "TTHOPDONG04   "
                      select new HopDongViewModel
                      {
                          mahopdong = hopdong.Mahopdong,
                          ngaydangky = hopdong.Ngaydangky,
                          ngayapdung = hopdong.Ngayapdung,
                          diachicaidat = hopdong.Diachicaidat,
                          diachithanhtoan = hopdong.Diachithanhtoan,
                          makhachhang = hopdong.Makhachhang,
                          tenkhachhang = khachhang.Tenkhachhang,
                          magoicuoc = hopdong.Magiocuoc,
                          tengoicuoc = goicuoc.Tengoicuoc,
                          manhanvien = hopdong.Manv,
                          tennhanvien = nhanvien.Tennv,
                          matinhtrang = hopdong.Matinhtrang,
                          tentinhtrang = tinhtrang.Tentinhtrang,
                          cmnd = khachhang.Cmnd,
                          nghenghiep = khachhang.Nghenghiep,
                          email = khachhang.Email,
                          diachi = khachhang.Diachi,
                          soluongtaikhoan = khachhang.Soluongtaikhoan
                      }).ToList();

            foreach (HopDongViewModel item in re.ToList())
            {
                var hdon = TimHoaDonTheoMaKH(item.makhachhang);
                if (hdon == null && item.ngayapdung.HasValue)
                {
                    if (DateTime.Now.Subtract(item.ngayapdung.Value).TotalDays < 28)
                    {
                        re.Remove(item);
                    }
                }
                else
                {
                    if (DateTime.Now.Subtract(hdon.Ngaylap.Value).TotalDays < 28)
                    {
                        re.Remove(item);
                    }
                }
            }
            //foreach (var HopDongViewModel in re.ToList())
            //{
            //    var ad = TimApDungKM(item.makh);
            //    if (ad != null)
            //    {
            //        var km = TimKhuyenMaiTheoMa(ad.Makm);
            //        if (DateTime.Now.Subtract(ad.Ngad).TotalDays < 30 * km.trigia)
            //        {
            //            re.Remove(item);
            //        }
            //    }
            //}
            var res = re.AsQueryable();
            return res;
        }

        public void CapNhatGoiCuoc(string Magc, string Tengc, decimal cuocthuebao, decimal giacuocngay, decimal giacuocdem, string matinhtrang)
        {
            var goicuoc = _context.Goicuoc.Where(m => m.Magoicuoc == Magc).FirstOrDefault();
            goicuoc.Tengoicuoc = Tengc;
            goicuoc.Cuocthuebao = cuocthuebao;
            goicuoc.Giacuocdem = giacuocdem;
            goicuoc.Giacuocngay = giacuocngay;
            goicuoc.Matinhtrang = matinhtrang;
            _context.SaveChanges();
        }

        public void CapNhatKhuyenMai(string makhuyenmai,string tenkhuyenmai, string maloaikhuyenmai, string ngaybatdau, string ngayketthuc, int trigia, string matinhtrang)
        {
            var khuyenmai = _context.Khuyenmai.Where(m => m.Makhuyenmai == makhuyenmai).FirstOrDefault();
            khuyenmai.Tenkhuyenmai = tenkhuyenmai;

            string[] date = ngaybatdau.Split("/");
            string time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            khuyenmai.Ngaybatdau = DateTime.Parse(time);
            date = ngayketthuc.Split("/");
            time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            khuyenmai.Ngayketthuc = DateTime.Parse(time);

            khuyenmai.Trigia = trigia;
            khuyenmai.Matinhtrang = matinhtrang;
            _context.SaveChanges();
        }

        public void CapNhatHopDong(string mahopdong, string diachicaidat, string diachithanhtoan, string tenkhachhang, string magoicuoc, string matinhtrang, string cmnd, string nghenghiep, string email, string diachi, string soluongtaikhoan, string sdt, string ngayapdung)
        {
            var hopdong = _context.Hopdong.Where(m => m.Mahopdong == mahopdong).FirstOrDefault();
            hopdong.Diachicaidat = diachicaidat;
            hopdong.Diachithanhtoan = diachithanhtoan;
            hopdong.Magiocuoc = magoicuoc;
            hopdong.Matinhtrang = matinhtrang;
            string[] date = ngayapdung.Split("/");
            string time = "";
            if (date[1].Length == 1)
            {
                time = date[2] + "-0" + date[1] + "-" + date[0];
            }
            else
            {
                time = date[2] + "-" + date[1] + "-" + date[0];
            }
            hopdong.Ngayapdung = DateTime.Parse(time);
            var khachhang = _context.Khachhang.Where(m => m.Makhachhang == hopdong.Makhachhang).FirstOrDefault();
            khachhang.Tenkhachhang = tenkhachhang;
            khachhang.Cmnd = cmnd;
            khachhang.Nghenghiep = nghenghiep;
            khachhang.Email = email;
            khachhang.Diachi = diachi;
            khachhang.Sdt = sdt;
            _context.SaveChanges();
        }
    }
}
