using Microsoft.AspNetCore.Http;

namespace WebApi.ViewModels
{
    public class UserVM : UserModel
    {
        public int IdUser { get; set; }
        public string TenChucVu { get; set; } = null!;
        public string TenPhongBan { get; set; } = null!;

    }
    public class UserModel
    {
        
        public string Username { get; set; } = null!;
        public string? MatKhau { get; set; }
        public string HoTen { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? MaBiMat { get; set; }
        public int IdChucVu { get; set; }
        public int IdPhongBan { get; set; }
        public string? DiaChi { get; set; }
        public string? DienThoai { get; set; }
        public string? HinhDaiDien { get; set; }
        public IFormFile? Img { get; set; }
    }
}
