namespace WebApi.ViewModels
{
    public class PhieuTrinhMuaVM : PhieuTrinhMuaModel
    { 
        public string? HoTen { get; set; }
        public string? TenVatTu { get; set; } = null!;
        public string? MaVatTu { get; set; } = null!;
        public int? TongTien { get; set; }
        public float? TongSoLuong { get; set; }
    }
    public class PhieuTrinhMuaModel
    {
        public int IdPhieuDeNghiMua { get; set; }
        public int IdUser { get; set; }
        public int? SoLanSuaPhieu { get; set; }
        public string? LyDoSuaPhieu { get; set; }

        public DateTime TimeTaoPhieu { get; set; }
    }
}
