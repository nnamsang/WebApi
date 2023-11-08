namespace WebApi.ViewModels
{
    public class ChiTietPhieuVM : ChiTietPhieuModel
    {
       
        public string? TenTinhTrangSuLy { get;set; }
        public string? TenVatTu { get; set; }
        public string? SoHoaDon { get; set; }

    }
    public class ChiTietPhieuModel
    {
        public int IdChiTietPhieu { get; set; }
        public int IdPhieuDeNghi { get; set; }
        public int IdTinhTrangXuLy { get; set; }
        public int IdVatTu { get; set; }
        public double SoLuongDeNghi { get; set; }
        public double? SoLuongThayDoi { get; set; }
        public string? DonViTinhThayDoi { get; set; }
        public double? SoLuongMuaThem { get; set; }
        public string? GiChuThuKho { get; set; }
        public string? GiChuMuaThem { get; set; }
        public string? GiChuXuatVatTu { get; set; }
        public double? TongSoLuong { get; set; }
        public int? DonGia { get; set; }
        public string? Vat { get; set; }
        public int? ThanhTien { get; set; }
        public int? IdPhieuDeNghiMua { get; set; }
        public string? DonViCungCap { get; set; }
        public int? IdHoaDon { get; set; }
        public string? GhiChuSuaPhieuMua { get; set; }
        public string? GhiChuSuaTheoHoaDon { get; set; }
        public int? SoLanSuaPhieuMua { get; set; }
    }

}
