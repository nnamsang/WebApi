using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class PhieuTrinhMua
    {
        public PhieuTrinhMua()
        {
            ChiTietPhieus = new HashSet<ChiTietPhieu>();
            HoaDons = new HashSet<HoaDon>();
        }

        public int IdPhieuDeNghiMua { get; set; }
        public int IdUser { get; set; }
        public int? SoLanSuaPhieu { get; set; }
        public string? LyDoSuaPhieu { get; set; }
        public int TongTien { get; set; }
        public DateTime TimeTaoPhieu { get; set; }

        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; }
        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
