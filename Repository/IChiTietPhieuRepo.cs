using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Newtonsoft.Json;
using WebApi.Data.Models;
using WebApi.ViewModels;
using static System.Net.WebRequestMethods;

namespace WebApi.Repository
{
    public interface IChiTietPhieuRepo
    {
        List<ChiTietPhieuVM> GetAll();
        
        ChiTietPhieuVM GetById(int id);
        ChiTietPhieuModel Add(ChiTietPhieuModel vm);
        void DeleteById(int id);
        void update(int id,  ChiTietPhieuModel vm);
    }
    public class ChiTietPhieuRepo : IChiTietPhieuRepo
    {
        private readonly QuanLyVatTuContext _context;

        public ChiTietPhieuRepo(QuanLyVatTuContext context)
        {
            _context = context;
        }
        public ChiTietPhieuModel Add( ChiTietPhieuModel vm)
        {
            var phieu = new ChiTietPhieu
            {
                GhiChuSuaPhieuMua = vm.GhiChuSuaPhieuMua,
                DonGia = vm.DonGia,
                DonViCungCap = vm.DonViCungCap,
                DonViTinhThayDoi = vm.DonViTinhThayDoi,
                GhiChuSuaTheoHoaDon = vm.DonViTinhThayDoi,
                GiChuMuaThem = vm.GhiChuSuaPhieuMua,
                GiChuThuKho = vm.GiChuThuKho,
                GiChuXuatVatTu = vm.GiChuThuKho,
                IdChiTietPhieu = vm.IdChiTietPhieu,
                IdHoaDon = vm.IdHoaDon,
                IdPhieuDeNghi = vm.IdPhieuDeNghi,
                IdPhieuDeNghiMua = vm.IdPhieuDeNghiMua,
                IdTinhTrangXuLy = vm.IdTinhTrangXuLy,
                SoLanSuaPhieuMua = vm.SoLanSuaPhieuMua,
                SoLuongDeNghi = vm.SoLuongDeNghi,
                SoLuongMuaThem = vm.SoLuongMuaThem,
                SoLuongThayDoi = vm.SoLuongThayDoi,
                IdVatTu = vm.IdVatTu,
                ThanhTien = vm.ThanhTien,
                Vat = vm.Vat,
                TongSoLuong = vm.TongSoLuong
                
            };
            _context.ChiTietPhieus.Add(phieu);
            _context.SaveChanges();
            return new ChiTietPhieuModel
            {
                IdVatTu = phieu.IdVatTu,
                GhiChuSuaPhieuMua = phieu.GhiChuSuaPhieuMua,
                DonGia = phieu.DonGia,
                DonViCungCap = phieu.DonViCungCap,
                DonViTinhThayDoi = phieu.DonViTinhThayDoi,
                GhiChuSuaTheoHoaDon = phieu.DonViTinhThayDoi,
                GiChuMuaThem = phieu.GhiChuSuaPhieuMua,
                GiChuThuKho = phieu.GiChuThuKho,
                GiChuXuatVatTu = phieu.GiChuThuKho,
                IdChiTietPhieu = phieu.IdChiTietPhieu,
                TongSoLuong = phieu.TongSoLuong,
                IdHoaDon = phieu.IdHoaDon,
                IdPhieuDeNghi = phieu.IdChiTietPhieu,
                IdPhieuDeNghiMua = phieu.IdPhieuDeNghiMua,
                IdTinhTrangXuLy = phieu.IdChiTietPhieu,
                SoLanSuaPhieuMua = phieu.SoLanSuaPhieuMua,
                SoLuongDeNghi = (float)phieu.SoLuongDeNghi,
                SoLuongMuaThem = phieu.SoLuongMuaThem,
                SoLuongThayDoi = phieu.SoLuongThayDoi,
                ThanhTien = phieu.ThanhTien,
                Vat = phieu.Vat
            };
        }

        public void DeleteById(int id)
        {
           var phieu = _context.ChiTietPhieus.SingleOrDefault(p=>p.IdChiTietPhieu == id);

            _context.Remove(phieu);
        }

        public List<ChiTietPhieuVM> GetAll()
        {
            var phieu = from ctp in _context.ChiTietPhieus
                        join vt in _context.VatTus on ctp.IdVatTu equals vt.IdVatTu
                        join hd in _context.HoaDons on ctp.IdHoaDon equals hd.IdHoaDon
                        join ttxl in _context.TinhTrangXuLies on ctp.IdTinhTrangXuLy equals ttxl.IdTinhTrangXuLy
                        select new ChiTietPhieuVM
                        {
                            IdVatTu = ctp.IdVatTu,
                            IdTinhTrangXuLy = ctp.IdTinhTrangXuLy,
                            DonGia = ctp.DonGia,
                            DonViCungCap = ctp.DonViCungCap,
                            DonViTinhThayDoi = ctp.DonViTinhThayDoi,
                            GhiChuSuaPhieuMua = ctp.GhiChuSuaPhieuMua,
                            GhiChuSuaTheoHoaDon = ctp.GhiChuSuaPhieuMua,
                            GiChuMuaThem = ctp.GhiChuSuaPhieuMua,
                            GiChuThuKho = ctp.GhiChuSuaPhieuMua,
                            GiChuXuatVatTu = ctp.GiChuXuatVatTu,
                            IdChiTietPhieu = ctp.IdChiTietPhieu,
                            TongSoLuong = ctp.TongSoLuong,
                            IdHoaDon = ctp.IdHoaDon,
                            IdPhieuDeNghi = ctp.IdPhieuDeNghi,
                            IdPhieuDeNghiMua = ctp.IdPhieuDeNghiMua,
                            SoHoaDon = hd.SoHoaDon,
                            SoLanSuaPhieuMua = ctp.SoLanSuaPhieuMua,
                            SoLuongDeNghi = ctp.SoLuongDeNghi,
                            SoLuongMuaThem = ctp.SoLuongMuaThem,
                            SoLuongThayDoi = ctp.SoLuongThayDoi,
                            TenTinhTrangSuLy = ttxl.TenTinhTrangXuLy,
                            TenVatTu = vt.TenVatTu,
                            ThanhTien = ctp.ThanhTien,
                            Vat = ctp.Vat
                        };
            return phieu.ToList();
        }

        public ChiTietPhieuVM GetById(int id)
        {
            var phieu = (from ctp in _context.ChiTietPhieus
                        join vt in _context.VatTus on ctp.IdVatTu equals vt.IdVatTu
                        join hd in _context.HoaDons on ctp.IdHoaDon equals hd.IdHoaDon
                        join ttxl in _context.TinhTrangXuLies on ctp.IdTinhTrangXuLy equals ttxl.IdTinhTrangXuLy
                        where ctp.IdChiTietPhieu == id
                        select new ChiTietPhieuVM
                        {
                            IdVatTu= ctp.IdVatTu,
                            IdTinhTrangXuLy = ctp.IdTinhTrangXuLy,
                            DonGia = ctp.DonGia,
                            DonViCungCap = ctp.DonViCungCap,
                            DonViTinhThayDoi = ctp.DonViTinhThayDoi,
                            GhiChuSuaPhieuMua = ctp.GhiChuSuaPhieuMua,
                            GhiChuSuaTheoHoaDon = ctp.GhiChuSuaPhieuMua,
                            GiChuMuaThem = ctp.GhiChuSuaPhieuMua,
                            GiChuThuKho = ctp.GhiChuSuaPhieuMua,
                            GiChuXuatVatTu = ctp.GiChuXuatVatTu,
                            IdChiTietPhieu = ctp.IdChiTietPhieu,
                            IdHoaDon = ctp.IdHoaDon,
                            TongSoLuong = ctp.TongSoLuong,
                            IdPhieuDeNghi = ctp.IdPhieuDeNghi,
                            IdPhieuDeNghiMua = ctp.IdPhieuDeNghiMua,
                            SoHoaDon = hd.SoHoaDon,
                            SoLanSuaPhieuMua = ctp.SoLanSuaPhieuMua,
                            SoLuongDeNghi = ctp.SoLuongDeNghi,
                            SoLuongMuaThem = ctp.SoLuongMuaThem,
                            SoLuongThayDoi = ctp.SoLuongThayDoi,
                            TenTinhTrangSuLy = ttxl.TenTinhTrangXuLy,
                            TenVatTu = vt.TenVatTu,
                            ThanhTien = ctp.ThanhTien,
                            Vat = ctp.Vat
                        }).FirstOrDefault();
            var jsonUser = JsonConvert.SerializeObject(phieu);
            return JsonConvert.DeserializeObject<ChiTietPhieuVM>(jsonUser);
        }

        public void update(int id, ChiTietPhieuModel vm)
        {
            var phieu = _context.ChiTietPhieus.SingleOrDefault(p => p.IdChiTietPhieu == id);
            if (phieu != null) { 
            phieu.IdVatTu = vm.IdVatTu;
            phieu.IdTinhTrangXuLy = vm.IdTinhTrangXuLy;
            phieu.DonGia = vm.DonGia;
            phieu.DonViCungCap = vm.DonViCungCap;
            phieu.DonViTinhThayDoi = vm.DonViTinhThayDoi;
            phieu.GhiChuSuaPhieuMua = vm.GhiChuSuaPhieuMua;
            phieu.GhiChuSuaTheoHoaDon = vm.GhiChuSuaPhieuMua;
            phieu.GiChuMuaThem = vm.GhiChuSuaPhieuMua;
            phieu.GiChuThuKho = vm.GhiChuSuaPhieuMua;
            phieu.GiChuXuatVatTu = vm.GiChuXuatVatTu;
            phieu.IdChiTietPhieu = vm.IdChiTietPhieu;
            phieu.IdHoaDon = vm.IdHoaDon;
            phieu.TongSoLuong = vm.TongSoLuong;
            phieu.IdPhieuDeNghi = vm.IdPhieuDeNghi;
            phieu.IdPhieuDeNghiMua = vm.IdPhieuDeNghiMua;
            phieu.SoLanSuaPhieuMua = vm.SoLanSuaPhieuMua;
            phieu.SoLuongDeNghi = vm.SoLuongDeNghi;
            phieu.SoLuongMuaThem = vm.SoLuongMuaThem;
            phieu.SoLuongThayDoi = vm.SoLuongThayDoi;
            phieu.ThanhTien = vm.ThanhTien;
            phieu.Vat = vm.Vat;
            phieu.TongSoLuong = vm.TongSoLuong;
            _context.SaveChanges();
            }
        }
    }
}

