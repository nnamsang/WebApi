using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class TinhTrangXuLy
    {
        public TinhTrangXuLy()
        {
            ChiTietPhieus = new HashSet<ChiTietPhieu>();
        }

        public int IdTinhTrangXuLy { get; set; }
        public string TenTinhTrangXuLy { get; set; } = null!;

        public virtual ICollection<ChiTietPhieu> ChiTietPhieus { get; set; }
    }
}
