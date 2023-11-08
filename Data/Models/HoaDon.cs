using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class HoaDon
    {
        public HoaDon()
        {
            ChiTietPhieus = new HashSet<ChiTietPhieu>();
        }

        public int IdHoaDon { get; set; }
        public string SoHoaDon { get; set; } = null!;
        public int IdPhieuDeNghiMua { get; set; }
        public string DonViCungCap { get; set; } = null!;
        public string HinhThucThanhToan { get; set; } = null!;
        public DateTime NgayNhapHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }

        public virtual PhieuTrinhMua IdPhieuDeNghiMuaNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; }
    }
}
