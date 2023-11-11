using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            Users = new HashSet<User>();
        }

        public int IdChucVu { get; set; }
        public string TenChucVu { get; set; } = null!;
        public string MaChuVu { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
