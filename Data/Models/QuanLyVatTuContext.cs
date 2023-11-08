using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Data.Models
{
    public partial class QuanLyVatTuContext : DbContext
    {
        public QuanLyVatTuContext()
        {
        }

        public QuanLyVatTuContext(DbContextOptions<QuanLyVatTuContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ChiTietPhieu> ChiTietPhieus { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        public virtual DbSet<HoaDon> HoaDons { get; set; } = null!;
        public virtual DbSet<Kho> Khos { get; set; } = null!;
        public virtual DbSet<PhieuDeNghiVatTu> PhieuDeNghiVatTus { get; set; } = null!;
        public virtual DbSet<PhieuTrinhMua> PhieuTrinhMuas { get; set; } = null!;
        public virtual DbSet<PhongBan> PhongBans { get; set; } = null!;
        public virtual DbSet<TinhTrangPhieu> TinhTrangPhieus { get; set; } = null!;
        public virtual DbSet<TinhTrangXuLy> TinhTrangXuLies { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<VatTu> VatTus { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=NAMSANG-2002\\SQLEXPRESS;Initial Catalog=QuanLyVatTu;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChiTietPhieu>(entity =>
            {
                entity.HasKey(e => e.IdChiTietPhieu);

                entity.ToTable("ChiTietPhieu");

                entity.Property(e => e.DonViCungCap).HasMaxLength(50);

                entity.Property(e => e.DonViTinhThayDoi).HasMaxLength(50);

                entity.Property(e => e.GhiChuSuaPhieuMua).HasColumnType("text");

                entity.Property(e => e.GhiChuSuaTheoHoaDon).HasColumnType("text");

                entity.Property(e => e.GiChuMuaThem).HasColumnType("text");

                entity.Property(e => e.GiChuThuKho).HasColumnType("text");

                entity.Property(e => e.GiChuXuatVatTu).HasColumnType("text");

                entity.Property(e => e.Vat)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("VAT");

                entity.HasOne(d => d.IdHoaDonNavigation)
                    .WithMany(p => p.ChiTietPhieus)
                    .HasForeignKey(d => d.IdHoaDon)
                    .HasConstraintName("FK_ChiTietPhieu_HoaDon");

                entity.HasOne(d => d.IdPhieuDeNghiNavigation)
                    .WithMany(p => p.ChiTietPhieus)
                    .HasForeignKey(d => d.IdPhieuDeNghi)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieu_PhieuDeNghiVatTu");

                entity.HasOne(d => d.IdPhieuDeNghiMuaNavigation)
                    .WithMany(p => p.ChiTietPhieus)
                    .HasForeignKey(d => d.IdPhieuDeNghiMua)
                    .HasConstraintName("FK_ChiTietPhieu_PhieuTrinhMua");

                entity.HasOne(d => d.IdTinhTrangXuLyNavigation)
                    .WithMany(p => p.ChiTietPhieus)
                    .HasForeignKey(d => d.IdTinhTrangXuLy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieu_TinhTrangXuLy");

                entity.HasOne(d => d.IdVatTuNavigation)
                    .WithMany(p => p.ChiTietPhieus)
                    .HasForeignKey(d => d.IdVatTu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ChiTietPhieu_VatTu");
            });

            modelBuilder.Entity<ChucVu>(entity =>
            {
                entity.HasKey(e => e.IdChucVu);

                entity.ToTable("ChucVu");

                entity.Property(e => e.MaChuVu)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenChucVu).HasMaxLength(50);
            });

            modelBuilder.Entity<HoaDon>(entity =>
            {
                entity.HasKey(e => e.IdHoaDon);

                entity.ToTable("HoaDon");

                entity.Property(e => e.DonViCungCap).HasMaxLength(200);

                entity.Property(e => e.HinhThucThanhToan).HasMaxLength(50);

                entity.Property(e => e.NgayHoaDon).HasColumnType("date");

                entity.Property(e => e.NgayNhapHoaDon).HasColumnType("date");

                entity.Property(e => e.SoHoaDon).HasMaxLength(100);

                entity.HasOne(d => d.IdPhieuDeNghiMuaNavigation)
                    .WithMany(p => p.HoaDons)
                    .HasForeignKey(d => d.IdPhieuDeNghiMua)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HoaDon_PhieuTrinhMua");
            });

            modelBuilder.Entity<Kho>(entity =>
            {
                entity.HasKey(e => e.IdKho);

                entity.ToTable("Kho");

                entity.Property(e => e.IdKho).ValueGeneratedNever();

                entity.Property(e => e.TenKho).HasMaxLength(50);
            });

            modelBuilder.Entity<PhieuDeNghiVatTu>(entity =>
            {
                entity.HasKey(e => e.IdPhieuDeNghi);

                entity.ToTable("PhieuDeNghiVatTu");

                entity.Property(e => e.LyDoLapPhieu).HasMaxLength(250);

                entity.Property(e => e.LyDoTraPhieu).HasColumnType("text");

                entity.Property(e => e.NguoiTraPhieu).HasMaxLength(250);

                entity.Property(e => e.TimeDuyetPhieu).HasColumnType("datetime");

                entity.Property(e => e.TimeTaoPhieu).HasColumnType("datetime");

                entity.HasOne(d => d.IdLanhDaoNavigation)
                    .WithMany(p => p.PhieuDeNghiVatTuIdLanhDaoNavigations)
                    .HasForeignKey(d => d.IdLanhDao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDeNghiVatTu_User2");

                entity.HasOne(d => d.IdPhongBanNavigation)
                    .WithMany(p => p.PhieuDeNghiVatTus)
                    .HasForeignKey(d => d.IdPhongBan)
                    .HasConstraintName("FK_PhieuDeNghiVatTu_PhongBan");

                entity.HasOne(d => d.IdThuTruongNavigation)
                    .WithMany(p => p.PhieuDeNghiVatTuIdThuTruongNavigations)
                    .HasForeignKey(d => d.IdThuTruong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDeNghiVatTu_User1");

                entity.HasOne(d => d.IdTinhTrangPhieuNavigation)
                    .WithMany(p => p.PhieuDeNghiVatTus)
                    .HasForeignKey(d => d.IdTinhTrangPhieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDeNghiVatTu_TinhTrangPhieu");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PhieuDeNghiVatTuIdUserNavigations)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuDeNghiVatTu_User");
            });

            modelBuilder.Entity<PhieuTrinhMua>(entity =>
            {
                entity.HasKey(e => e.IdPhieuDeNghiMua);

                entity.ToTable("PhieuTrinhMua");

                entity.Property(e => e.LyDoSuaPhieu).HasMaxLength(250);

                entity.Property(e => e.TimeTaoPhieu).HasColumnType("datetime");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.PhieuTrinhMuas)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PhieuTrinhMua_User");
            });

            modelBuilder.Entity<PhongBan>(entity =>
            {
                entity.HasKey(e => e.IdPhongBan);

                entity.ToTable("PhongBan");

                entity.Property(e => e.MaPhongBan)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TenPhongBan).HasMaxLength(50);
            });

            modelBuilder.Entity<TinhTrangPhieu>(entity =>
            {
                entity.HasKey(e => e.IdTrinhTrangPhieu);

                entity.ToTable("TinhTrangPhieu");

                entity.Property(e => e.TenTinhTrangDuyet).HasMaxLength(50);
            });

            modelBuilder.Entity<TinhTrangXuLy>(entity =>
            {
                entity.HasKey(e => e.IdTinhTrangXuLy);

                entity.ToTable("TinhTrangXuLy");

                entity.Property(e => e.TenTinhTrangXuLy).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("User");

                entity.Property(e => e.DiaChi).HasMaxLength(250);

                entity.Property(e => e.DienThoai)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.HinhDaiDien).HasMaxLength(200);

                entity.Property(e => e.HoTen).HasMaxLength(200);

                entity.Property(e => e.MaBiMat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MatKhau)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Username).HasMaxLength(100);

                entity.HasOne(d => d.IdChucVuNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdChucVu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_ChucVu");

                entity.HasOne(d => d.IdPhongBanNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.IdPhongBan)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_PhongBan");
            });

            modelBuilder.Entity<VatTu>(entity =>
            {
                entity.HasKey(e => e.IdVatTu);

                entity.ToTable("VatTu");

                entity.Property(e => e.IdVatTu).ValueGeneratedNever();

                entity.Property(e => e.DonViTinh).HasMaxLength(50);

                entity.Property(e => e.GhiChu).HasColumnType("text");

                entity.Property(e => e.HinhAnhVatTu).HasColumnType("text");

                entity.Property(e => e.MaVatTu)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoLuongTonKho).HasDefaultValueSql("((0))");

                entity.Property(e => e.TenVatTu).HasMaxLength(200);

                entity.Property(e => e.ViTri).HasMaxLength(50);

                entity.HasOne(d => d.IdKhoNavigation)
                    .WithMany(p => p.VatTus)
                    .HasForeignKey(d => d.IdKho)
                    .HasConstraintName("FK_VatTu_Kho1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
