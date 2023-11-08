using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class User
    {
        public User()
        {
            PhieuDeNghiVatTuIdLanhDaoNavigations = new HashSet<PhieuDeNghiVatTu>();
            PhieuDeNghiVatTuIdThuTruongNavigations = new HashSet<PhieuDeNghiVatTu>();
            PhieuDeNghiVatTuIdUserNavigations = new HashSet<PhieuDeNghiVatTu>();
            PhieuTrinhMuas = new HashSet<PhieuTrinhMua>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; } = null!;
        public string? MatKhau { get; set; }
        public string HoTen { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MaBiMat { get; set; }
        public int IdChucVu { get; set; }
        public int IdPhongBan { get; set; }
        public int? CapNhat { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? HinhDaiDien { get; set; }

        public virtual ChucVu IdChucVuNavigation { get; set; } = null!;
        public virtual PhongBan IdPhongBanNavigation { get; set; } = null!;
        public virtual ICollection<PhieuDeNghiVatTu> PhieuDeNghiVatTuIdLanhDaoNavigations { get; set; }
        public virtual ICollection<PhieuDeNghiVatTu> PhieuDeNghiVatTuIdThuTruongNavigations { get; set; }
        public virtual ICollection<PhieuDeNghiVatTu> PhieuDeNghiVatTuIdUserNavigations { get; set; }
        public virtual ICollection<PhieuTrinhMua> PhieuTrinhMuas { get; set; }
    }
}
