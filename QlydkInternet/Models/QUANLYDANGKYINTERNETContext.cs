using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace QlydkInternet.Models
{
    public partial class QUANLYDANGKYINTERNETContext : DbContext
    {
        public virtual DbSet<Apdung> Apdung { get; set; }
        public virtual DbSet<Capnhatgc> Capnhatgc { get; set; }
        public virtual DbSet<Capnhatkm> Capnhatkm { get; set; }
        public virtual DbSet<Goicuoc> Goicuoc { get; set; }
        public virtual DbSet<Hoadon> Hoadon { get; set; }
        public virtual DbSet<Hotro> Hotro { get; set; }
        public virtual DbSet<Khachhang> Khachhang { get; set; }
        public virtual DbSet<Khuyenmai> Khuyenmai { get; set; }
        public virtual DbSet<Loaigoicuoc> Loaigoicuoc { get; set; }
        public virtual DbSet<Loaikhuyenmai> Loaikhuyenmai { get; set; }
        public virtual DbSet<Loaithanhtoan> Loaithanhtoan { get; set; }
        public virtual DbSet<Nhanvien> Nhanvien { get; set; }
        public virtual DbSet<Phieudangky> Phieudangky { get; set; }
        public virtual DbSet<Thongke> Thongke { get; set; }
        public virtual DbSet<Thongtin> Thongtin { get; set; }
        public virtual DbSet<Thongtintruycap> Thongtintruycap { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer(@"Server=DESKTOP-N5TI1HT;Database=QUANLYDANGKYINTERNET;Trusted_Connection=True;");
//            }
//        }
        public QUANLYDANGKYINTERNETContext(DbContextOptions<QUANLYDANGKYINTERNETContext> options)
: base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Apdung>(entity =>
            {
                entity.HasKey(e => new { e.Makm, e.Makh, e.Ngad });

                entity.ToTable("APDUNG");

                entity.Property(e => e.Makm)
                    .HasColumnName("MAKM")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Ngad)
                    .HasColumnName("NGAD")
                    .HasColumnType("date");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Apdung)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APDUNG_MAKH_KHACHHANG");

                entity.HasOne(d => d.MakmNavigation)
                    .WithMany(p => p.Apdung)
                    .HasForeignKey(d => d.Makm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_APDUNG_MAKM_GOICUOC");
            });

            modelBuilder.Entity<Capnhatgc>(entity =>
            {
                entity.HasKey(e => new { e.Manv, e.Magc });

                entity.ToTable("CAPNHATGC");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Magc)
                    .HasColumnName("MAGC")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Noidung)
                    .HasColumnName("NOIDUNG")
                    .HasMaxLength(200);

                entity.Property(e => e.Thoigian)
                    .HasColumnName("THOIGIAN")
                    .HasColumnType("date");

                entity.HasOne(d => d.MagcNavigation)
                    .WithMany(p => p.Capnhatgc)
                    .HasForeignKey(d => d.Magc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAPNHATGC_MAGC_GOICUOC");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Capnhatgc)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAPNHATGC_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Capnhatkm>(entity =>
            {
                entity.HasKey(e => new { e.Makm, e.Manv });

                entity.ToTable("CAPNHATKM");

                entity.Property(e => e.Makm)
                    .HasColumnName("MAKM")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Noidung)
                    .HasColumnName("NOIDUNG")
                    .HasMaxLength(200);

                entity.Property(e => e.Thoigian)
                    .HasColumnName("THOIGIAN")
                    .HasColumnType("date");

                entity.HasOne(d => d.MakmNavigation)
                    .WithMany(p => p.Capnhatkm)
                    .HasForeignKey(d => d.Makm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAPNHATKM_MAKM_KHUYENMAI");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Capnhatkm)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CAPNHATKM_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Goicuoc>(entity =>
            {
                entity.HasKey(e => e.Magc);

                entity.ToTable("GOICUOC");

                entity.Property(e => e.Magc)
                    .HasColumnName("MAGC")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Giacuoc)
                    .HasColumnName("GIACUOC")
                    .HasColumnType("money");

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(20);

                entity.Property(e => e.Loaigc)
                    .IsRequired()
                    .HasColumnName("LOAIGC")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Mota)
                    .IsRequired()
                    .HasColumnName("MOTA")
                    .HasMaxLength(1000);

                entity.Property(e => e.Tengc)
                    .IsRequired()
                    .HasColumnName("TENGC")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tocdo)
                    .IsRequired()
                    .HasColumnName("TOCDO")
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.LoaigcNavigation)
                    .WithMany(p => p.Goicuoc)
                    .HasForeignKey(d => d.Loaigc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GOICUOC_LOAIGC_LOAIGC");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Sohd);

                entity.ToTable("HOADON");

                entity.Property(e => e.Sohd)
                    .HasColumnName("SOHD")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hanhoadon)
                    .HasColumnName("HANHOADON")
                    .HasColumnType("date");

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Manv)
                    .IsRequired()
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Ngayin)
                    .HasColumnName("NGAYIN")
                    .HasColumnType("date");

                entity.Property(e => e.Ngaythanhtoan)
                    .HasColumnName("NGAYTHANHTOAN")
                    .HasColumnType("date");

                entity.Property(e => e.Trigia)
                    .HasColumnName("TRIGIA")
                    .HasColumnType("money");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_MAKH_KHACHHANG");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hoadon)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HOADON_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Hotro>(entity =>
            {
                entity.HasKey(e => new { e.Makh, e.Manv });

                entity.ToTable("HOTRO");

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hotro)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAMSOC_MAKH_KHACHHANG");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Hotro)
                    .HasForeignKey(d => d.Manv)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CHAMSOC_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh);

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh)
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cmnd)
                    .IsRequired()
                    .HasColumnName("CMND")
                    .HasMaxLength(12)
                    .IsUnicode(false);

                entity.Property(e => e.Diachi)
                    .IsRequired()
                    .HasColumnName("DIACHI")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("HOTEN")
                    .HasMaxLength(30);

                entity.Property(e => e.Nghenghiep)
                    .HasColumnName("NGHENGHIEP")
                    .HasMaxLength(20);

                entity.Property(e => e.Ngsinh)
                    .HasColumnName("NGSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(11)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Khuyenmai>(entity =>
            {
                entity.HasKey(e => e.Makm);

                entity.ToTable("KHUYENMAI");

                entity.Property(e => e.Makm)
                    .HasColumnName("MAKM")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Hinhanh)
                    .HasColumnName("HINHANH")
                    .HasMaxLength(20);

                entity.Property(e => e.Loaigc)
                    .IsRequired()
                    .HasColumnName("LOAIGC")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Loaikm)
                    .IsRequired()
                    .HasColumnName("LOAIKM")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Mota)
                    .HasColumnName("MOTA")
                    .HasMaxLength(1000);

                entity.Property(e => e.Ngbd)
                    .HasColumnName("NGBD")
                    .HasColumnType("date");

                entity.Property(e => e.Ngkt)
                    .HasColumnName("NGKT")
                    .HasColumnType("date");

                entity.Property(e => e.Tenkm)
                    .IsRequired()
                    .HasColumnName("TENKM")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Trigia).HasColumnName("TRIGIA");

                entity.HasOne(d => d.LoaigcNavigation)
                    .WithMany(p => p.Khuyenmai)
                    .HasForeignKey(d => d.Loaigc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHUYENMAI_LOAIGC_LOAIGC");

                entity.HasOne(d => d.LoaikmNavigation)
                    .WithMany(p => p.Khuyenmai)
                    .HasForeignKey(d => d.Loaikm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_KHUYENMAI_LOAIKM_LOAIKM");
            });

            modelBuilder.Entity<Loaigoicuoc>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAIGOICUOC");

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloai)
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Loaikhuyenmai>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAIKHUYENMAI");

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloai)
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Loaithanhtoan>(entity =>
            {
                entity.HasKey(e => e.Maloai);

                entity.ToTable("LOAITHANHTOAN");

                entity.Property(e => e.Maloai)
                    .HasColumnName("MALOAI")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tenloai)
                    .HasColumnName("TENLOAI")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.Manv);

                entity.ToTable("NHANVIEN");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Bophan)
                    .IsRequired()
                    .HasColumnName("BOPHAN")
                    .HasMaxLength(50);

                entity.Property(e => e.Chucvu)
                    .IsRequired()
                    .HasColumnName("CHUCVU")
                    .HasMaxLength(15);

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasColumnName("HOTEN")
                    .HasMaxLength(30);

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ngsinh)
                    .HasColumnName("NGSINH")
                    .HasColumnType("date");

                entity.Property(e => e.Ngvl)
                    .HasColumnName("NGVL")
                    .HasColumnType("date");

                entity.Property(e => e.Sdt)
                    .IsRequired()
                    .HasColumnName("SDT")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Taikhoan)
                    .IsRequired()
                    .HasColumnName("TAIKHOAN")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phieudangky>(entity =>
            {
                entity.HasKey(e => e.Maphieu);

                entity.ToTable("PHIEUDANGKY");

                entity.Property(e => e.Maphieu)
                    .HasColumnName("MAPHIEU")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Dccaidat)
                    .IsRequired()
                    .HasColumnName("DCCAIDAT")
                    .HasMaxLength(50);

                entity.Property(e => e.Dchoadon)
                    .HasColumnName("DCHOADON")
                    .HasMaxLength(50);

                entity.Property(e => e.Doituong)
                    .HasColumnName("DOITUONG")
                    .HasMaxLength(15);

                entity.Property(e => e.Loaitt)
                    .HasColumnName("LOAITT")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Magc)
                    .IsRequired()
                    .HasColumnName("MAGC")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Matkhau)
                    .IsRequired()
                    .HasColumnName("MATKHAU")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ngad)
                    .HasColumnName("NGAD")
                    .HasColumnType("date");

                entity.Property(e => e.Ngdk)
                    .HasColumnName("NGDK")
                    .HasColumnType("date");

                entity.Property(e => e.Taikhoan)
                    .IsRequired()
                    .HasColumnName("TAIKHOAN")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Tinhtrang)
                    .IsRequired()
                    .HasColumnName("TINHTRANG")
                    .HasMaxLength(20);

                entity.HasOne(d => d.LoaittNavigation)
                    .WithMany(p => p.Phieudangky)
                    .HasForeignKey(d => d.Loaitt)
                    .HasConstraintName("FK_PHIEUDANGKY_LOAITT_LOAITT");

                entity.HasOne(d => d.MagcNavigation)
                    .WithMany(p => p.Phieudangky)
                    .HasForeignKey(d => d.Magc)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEUDANGKY_MAGC_GOICUOC");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Phieudangky)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PHIEUDANGKY_MAKH_KHACHHANG");
            });

            modelBuilder.Entity<Thongke>(entity =>
            {
                entity.HasKey(e => e.Matk);

                entity.ToTable("THONGKE");

                entity.Property(e => e.Matk)
                    .HasColumnName("MATK")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Chantruycap).HasColumnName("CHANTRUYCAP");

                entity.Property(e => e.Dkmoi).HasColumnName("DKMOI");

                entity.Property(e => e.Doanhthu)
                    .HasColumnName("DOANHTHU")
                    .HasColumnType("money");

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Nam).HasColumnName("NAM");

                entity.Property(e => e.Thang).HasColumnName("THANG");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Thongke)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_THONGKE_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Thongtin>(entity =>
            {
                entity.ToTable("THONGTIN");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Manv)
                    .HasColumnName("MANV")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Tieusu).HasColumnName("TIEUSU");

                entity.HasOne(d => d.ManvNavigation)
                    .WithMany(p => p.Thongtin)
                    .HasForeignKey(d => d.Manv)
                    .HasConstraintName("FK_THONGTIN_MANV_NHANVIEN");
            });

            modelBuilder.Entity<Thongtintruycap>(entity =>
            {
                entity.HasKey(e => e.Matc);

                entity.ToTable("THONGTINTRUYCAP");

                entity.Property(e => e.Matc)
                    .HasColumnName("MATC")
                    .HasColumnType("char(5)")
                    .ValueGeneratedNever();

                entity.Property(e => e.Diachitc)
                    .IsRequired()
                    .HasColumnName("DIACHITC")
                    .HasMaxLength(50);

                entity.Property(e => e.Makh)
                    .IsRequired()
                    .HasColumnName("MAKH")
                    .HasColumnType("char(5)");

                entity.Property(e => e.Ngaytc)
                    .HasColumnName("NGAYTC")
                    .HasColumnType("date");

                entity.Property(e => e.Sombsudung).HasColumnName("SOMBSUDUNG");

                entity.Property(e => e.Thanhtien).HasColumnName("THANHTIEN");

                entity.Property(e => e.Thoigiantc).HasColumnName("THOIGIANTC");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Thongtintruycap)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_THONGTINTRUYCAP_MAKH_KHACHHANG");
            });
        }
    }
}
