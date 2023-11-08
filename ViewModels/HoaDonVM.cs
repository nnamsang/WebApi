namespace WebApi.ViewModels
{
    public class HoaDonVM
    {
        public int IdHoaDon { get; set; }
        public string SoHoaDon { get; set; } = null!;
        public int IdPhieuDeNghiMua { get; set; }
        public string DonViCungCap { get; set; } = null!;
        public string HinhThucThanhToan { get; set; } = null!;
        public DateTime NgayNhapHoaDon { get; set; }
        public DateTime NgayHoaDon { get; set; }
    }

}
