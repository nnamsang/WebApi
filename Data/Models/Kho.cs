using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class Kho
    {
        public Kho()
        {
            VatTus = new HashSet<VatTu>();
        }

        public int IdKho { get; set; }
        public string? TenKho { get; set; }

        public virtual ICollection<VatTu> VatTus { get; set; }
    }
}
