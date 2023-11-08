using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class HinhAnhVatTu
    {
        public int IdHinhAnh { get; set; }
        public string UrlHinhAnh { get; set; } = null!;
        public int IdVatTu { get; set; }
        public int? IdUser { get; set; }

        public virtual User? IdUserNavigation { get; set; }
        public virtual VatTu IdVatTuNavigation { get; set; } = null!;
    }
}
