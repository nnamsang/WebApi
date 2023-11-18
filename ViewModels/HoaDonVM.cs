using WebApi.Data.Models;

namespace WebApi.ViewModels
{
    public class HoaDonVM : HoaDonModel
    {

        public double? TongSoLuong { get; set; }
        public int? ThanhTien { get; set; }
        public int? DonGia { get; set; }
        
    } 
    public class HoaDonModel
    {

        public int IdHoaDon { get; set; }
        public string TenHoaDon { get; set; } = null!;
        public string SoHoaDon { get; set; } = null!;
        public int IdPhieuDeNghiMua { get; set; }
        public string DonViCungCap { get; set; } = null!;
        public string HinhThucThanhToan { get; set; } = null!;
        public DateTime NgayNhapHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }
    }
       
    
   
}
