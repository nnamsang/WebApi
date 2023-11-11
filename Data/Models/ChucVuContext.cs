using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApi.Data.Models
{
    public partial class ChucVuContext : DbContext
    {
        public ChucVuContext()
        {
        }

        public ChucVuContext(DbContextOptions<ChucVuContext> options)
            : base(options)
        {
        }

        public int? IdChucVu { get; set; }
        public string? TenChucVu { get; set; } = null!;
        public string? MaChuVu { get; set; } = null!;
        public virtual DbSet<ChucVu> ChucVus { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.  
                optionsBuilder.UseSqlServer("Data SourceACER-K\\KIETHJ;Initial Catalog=QuanLyVatTu;Integrated Security=True");
            }
        }
    } 
}