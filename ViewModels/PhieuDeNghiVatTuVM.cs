namespace WebApi.ViewModels
{
    public class PhieuDeNghiVatTuVM : PhieuDeNghiVatTuModel
    {
       
        public string HoTen { get; set; } = null!;
        public string TenChucVu { get; set; } = null!;
        public string TenPhongBan { get; set; } = null!;
        public string TenTruongPhong { get; set;} = null!;
        public string TenLanhDao { get; set; } = null!;
        public string? TenTinhTrangDuyet { get; set; }
    }
    public class PhieuDeNghiVatTuModel
    {
        public int IdPhieuDeNghi { get; set; }
        public int IdPhieuTam { get; set; }
        public int IdPhieuChinhThuc { get; set; }
        public string LyDoLapPhieu { get; set; } = null!;
        public int IdUser { get; set; }
        public int? IdPhongBan { get; set; }
        public int IdThuTruong { get; set; }
        public int IdLanhDao { get; set; }
        public DateTime TimeTaoPhieu { get; set; }
        public DateTime? TimeDuyetPhieu { get; set; }
        public string? LyDoTraPhieu { get; set; }
        public string? NguoiTraPhieu { get; set; }
        public int IdTinhTrangPhieu { get; set; }
    }
}
