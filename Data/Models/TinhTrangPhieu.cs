using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class TinhTrangPhieu
    {
        public TinhTrangPhieu()
        {
            PhieuDeNghiVatTus = new HashSet<PhieuDeNghiVatTu>();
        }

        public int IdTrinhTrangPhieu { get; set; }
        public string? TenTinhTrangDuyet { get; set; }

        public virtual ICollection<PhieuDeNghiVatTu> PhieuDeNghiVatTus { get; set; }
    }
}
