using System;
using System.Collections.Generic;

namespace WebApi.Data.Models
{
    public partial class ChiTietPhieu
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

        public virtual HoaDon? IdHoaDonNavigation { get; set; }
        public virtual PhieuTrinhMua? IdPhieuDeNghiMuaNavigation { get; set; }
        public virtual PhieuDeNghiVatTu IdPhieuDeNghiNavigation { get; set; } = null!;
        public virtual TinhTrangXuLy IdTinhTrangXuLyNavigation { get; set; } = null!;
        public virtual VatTu IdVatTuNavigation { get; set; } = null!;
    }
}
