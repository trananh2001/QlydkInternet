using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QlydkInternet.Models
{
    public partial class QUANLYINTERNETContext : DbContext
    {
        public virtual DbSet<Apdung> Apdung { get; set; }
        public virtual DbSet<Goicuoc> Goicuoc { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Hopdong> Hopdong { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Khuyenmai> Khuyenmai { get; set; }
        public virtual DbSet<Loaihoadon> Loaihoadon { get; set; }
        public virtual DbSet<Loaikhuyenmai> Loaikhuyenmai { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Taikhoan> Taikhoan { get; set; }
        public virtual DbSet<Thongtintruycap> Thongtintruycap { get; set; }
        public virtual DbSet<Tinhtrang> Tinhtrang { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=DESKTOP-N5TI1HT;Database=QUANLYINTERNET;Trusted_Connection=True;");
//            }
//        }
        public QUANLYINTERNETContext(DbContextOptions<QUANLYINTERNETContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apdung>(entity =>
            {
                entity.HasKey(e => new { e.Mahopdong, e.Makhuyenmai });

                entity.ToTable("APDUNG");

                entity.Property(e => e.Mahopdong)
                    .HasColumnName("mahopdong")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Makhuyenmai)
                    .HasColumnName("makhuyenmai")
                    .HasColumnType("char(14)");
            });

            modelBuilder.Entity<Goicuoc>(entity =>
            {
                entity.HasKey(e => e.Magoicuoc);

                entity.ToTable("GOICUOC");

                entity.Property(e => e.Magoicuoc)
                    .HasColumnName("magoicuoc")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cuocthuebao)
                    .HasColumnName("cuocthuebao")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Giacuocdem)
                    .HasColumnName("giacuocdem")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Giacuocngay)
                    .HasColumnName("giacuocngay")
                    .HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Tengoicuoc)
                    .HasColumnName("tengoicuoc")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mahoadon);

                entity.ToTable("HOADON");

                entity.Property(e => e.Mahoadon)
                    .HasColumnName("mahoadon")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hanthanhtoan)
                    .HasColumnName("hanthanhtoan")
                    .HasColumnType("date");

                entity.Property(e => e.Mahopdong)
                    .HasColumnName("mahopdong")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("makhachhang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Maloaihoadon)
                    .HasColumnName("maloaihoadon")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Manhanvien)
                    .HasColumnName("manhanvien")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Ngaylap)
                    .HasColumnName("ngaylap")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaythanhtoan)
                    .HasColumnName("ngaythanhtoan")
                    .HasColumnType("date");

                entity.Property(e => e.Trigia)
                    .HasColumnName("trigia")
                    .HasColumnType("decimal(18, 0)");
            });

            modelBuilder.Entity<Hopdong>(entity =>
            {
                entity.HasKey(e => e.Mahopdong);

                entity.ToTable("HOPDONG");

                entity.Property(e => e.Mahopdong)
                    .HasColumnName("mahopdong")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Diachicaidat)
                    .HasColumnName("diachicaidat")
                    .HasMaxLength(50);

                entity.Property(e => e.Diachithanhtoan)
                    .HasColumnName("diachithanhtoan")
                    .HasMaxLength(50);

                entity.Property(e => e.Magiocuoc)
                    .HasColumnName("magiocuoc")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("makhachhang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Manv)
                    .HasColumnName("manv")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Ngayapdung)
                    .HasColumnName("ngayapdung")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaydangky)
                    .HasColumnName("ngaydangky")
                    .HasColumnType("date");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("makhachhang")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasColumnName("cmnd")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Diachi)
                    .HasColumnName("diachi")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("char(50)");

                entity.Property(e => e.Nghenghiep)
                    .HasColumnName("nghenghiep")
                    .HasMaxLength(50);

                entity.Property(e => e.Sdt)
                    .HasColumnName("sdt")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Soluongtaikhoan).HasColumnName("soluongtaikhoan");

                entity.Property(e => e.Tenkhachhang)
                    .IsRequired()
                    .HasColumnName("tenkhachhang")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Khuyenmai>(entity =>
            {
                entity.HasKey(e => e.Makhuyenmai);

                entity.ToTable("KHUYENMAI");

                entity.Property(e => e.Makhuyenmai)
                    .HasColumnName("makhuyenmai")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mahopdong)
                    .HasColumnName("mahopdong")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Maloaikhuyenmai)
                    .HasColumnName("maloaikhuyenmai")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Ngaybatdau)
                    .HasColumnName("ngaybatdau")
                    .HasColumnType("date");

                entity.Property(e => e.Ngayketthuc)
                    .HasColumnName("ngayketthuc")
                    .HasColumnType("date");

                entity.Property(e => e.Tenkhuyenmai)
                    .HasColumnName("tenkhuyenmai")
                    .HasMaxLength(50);

                entity.Property(e => e.Trigia).HasColumnName("trigia");
            });

            modelBuilder.Entity<Loaihoadon>(entity =>
            {
                entity.HasKey(e => e.Maloaihoadon);

                entity.ToTable("LOAIHOADON");

                entity.Property(e => e.Maloaihoadon)
                    .HasColumnName("maloaihoadon")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloaihoadon)
                    .HasColumnName("tenloaihoadon")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Loaikhuyenmai>(entity =>
            {
                entity.HasKey(e => e.Maloaikhuyenmai);

                entity.ToTable("LOAIKHUYENMAI");

                entity.Property(e => e.Maloaikhuyenmai)
                    .HasColumnName("maloaikhuyenmai")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloaikhuyenmai)
                    .HasColumnName("tenloaikhuyenmai")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv)
                    .HasColumnName("manv")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .HasColumnName("cmnd")
                    .HasColumnType("char(11)");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Matkhau)
                    .HasColumnName("matkhau")
                    .HasColumnType("nchar(14)");

                entity.Property(e => e.Tendangnhap)
                    .HasColumnName("tendangnhap")
                    .HasColumnType("nchar(14)");

                entity.Property(e => e.Tennv)
                    .HasColumnName("tennv")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Taikhoan>(entity =>
            {
                entity.HasKey(e => e.Tentaikhoan);

                entity.ToTable("TAIKHOAN");

                entity.Property(e => e.Tentaikhoan)
                    .HasColumnName("tentaikhoan")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Makhachhang)
                    .HasColumnName("makhachhang")
                    .HasColumnType("char(14)");

                entity.Property(e => e.Matkhau)
                    .HasColumnName("matkhau")
                    .HasColumnType("char(14)");
            });

            modelBuilder.Entity<Thongtintruycap>(entity =>
            {
                entity.HasKey(e => e.Matruycap);

                entity.ToTable("THONGTINTRUYCAP");

                entity.Property(e => e.Matruycap)
                    .HasColumnName("matruycap")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Sophuttruycap).HasColumnName("sophuttruycap");

                entity.Property(e => e.Thoigiantruycap)
                    .HasColumnName("thoigiantruycap")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Tinhtrang>(entity =>
            {
                entity.HasKey(e => e.Matinhtrang);

                entity.ToTable("TINHTRANG");

                entity.Property(e => e.Matinhtrang)
                    .HasColumnName("matinhtrang")
                    .HasColumnType("char(14)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tentinhtrang)
                    .HasColumnName("tentinhtrang")
                    .HasMaxLength(50);
            });
        }
    }
}
