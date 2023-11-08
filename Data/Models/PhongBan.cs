using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            PhieuDeNghiVatTus = new HashSet<PhieuDeNghiVatTu>();
            Users = new HashSet<User>();
        }

        public int IdPhongBan { get; set; }
        public string TenPhongBan { get; set; } = null!;
        public string MaPhongBan { get; set; } = null!;

        public virtual ICollection<PhieuDeNghiVatTu> PhieuDeNghiVatTus { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
