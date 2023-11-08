using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class PhieuDeNghiVatTu
    {
        public PhieuDeNghiVatTu()
        {
            ChiTietPhieus = new HashSet<ChiTietPhieu>();
        }

        public int IdPhieuDeNghi { get; set; }
        public int IdPhieuTam { get; set; }
        public int IdPhieuChinhThuc { get; set; }
        public string LyDoLapPhieu { get; set; } = null!;
        public int IdUser { get; set; }
        public int? IdPhongBan { get; set; }
        public int IdThuTruong { get; set; }
        public int IdLanhDao { get; set; }
        public DateTime TimeTaoPhieu { get; set; }
        public DateTime? TimeDuyetPhieu { get; set; }
        public string? LyDoTraPhieu { get; set; }
        public string? NguoiTraPhieu { get; set; }
        public int IdTinhTrangPhieu { get; set; }

        public virtual User IdLanhDaoNavigation { get; set; } = null!;
        public virtual PhongBan? IdPhongBanNavigation { get; set; }
        public virtual User IdThuTruongNavigation { get; set; } = null!;
        public virtual TinhTrangPhieu IdTinhTrangPhieuNavigation { get; set; } = null!;
        public virtual User IdUserNavigation { get; set; } = null!;
        public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; }
    }
}
