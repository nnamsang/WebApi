using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;

namespace WebApi.Data.EF
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<PhieuDeNghiVatTu> PhieuDeNghiVatTus { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhieuDeNghiVatTu>()
                .HasOne(p => p.IdLanhDaoNavigation)
                .WithMany(u => u.PhieuDeNghiVatTuIdLanhDaoNavigations)
                .HasForeignKey(p => p.IdLanhDao)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<PhieuDeNghiVatTu>()
                .HasOne(p => p.IdThuTruongNavigation)
                .WithMany(u => u.PhieuDeNghiVatTuIdThuTruongNavigations)
                .HasForeignKey(p => p.IdThuTruong)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PhieuDeNghiVatTu>()
                .HasOne(p => p.IdUserNavigation)
                .WithMany(u => u.PhieuDeNghiVatTuIdUserNavigations)
                .HasForeignKey(p => p.IdUser)
                .OnDelete(DeleteBehavior.Restrict);


         
            modelBuilder.Entity<ChiTietPhieu>()
            .HasKey(c => c.IdChiTietPhieu);

            modelBuilder.Entity<ChucVu>()
            .HasKey(c => c.IdChucVu);

            modelBuilder.Entity<HinhAnhVatTu>()
                .HasKey(c => c.IdHinhAnh);

            modelBuilder.Entity<HoaDon>()
                .HasKey(c => c.IdHoaDon);

            modelBuilder.Entity<PhieuDeNghiVatTu>()
                .HasKey(c => c.IdPhieuDeNghi);

            modelBuilder.Entity<PhieuTrinhMua>()
                .HasKey(c => c.IdPhieuDeNghiMua);

            modelBuilder.Entity<PhongBan>()
                .HasKey(c => c.IdPhongBan);

            modelBuilder.Entity<TinhTrangPhieu>()
                .HasKey(c => c.IdTrinhTrangPhieu);

            modelBuilder.Entity<TinhTrangXuLy>()
                .HasKey(c => c.IdTinhTrangXuLy);

            modelBuilder.Entity<User>()
                .HasKey(c => c.IdUser);

            modelBuilder.Entity<VatTu>()
                .HasKey(c => c.IdVatTu);

            base.OnModelCreating(modelBuilder);
        }
    }
}
