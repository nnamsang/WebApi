using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class VatTu
    {
        public VatTu()
        {
            ChiTietPhieus = new HashSet<ChiTietPhieu>();
        }

        public int IdVatTu { get; set; }
        public string TenVatTu { get; set; } = null!;
        public string MaVatTu { get; set; } = null!;
        public string DonViTinh { get; set; } = null!;
        public double? SoLuongTonKho { get; set; }
        public int? IdKho { get; set; }
        public string? ViTri { get; set; }
        public string? GhiChu { get; set; }
        public string? HinhAnhVatTu { get; set; }

        public virtual Kho? IdKhoNavigation { get; set; }
        public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; }
    }
}
