using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public class HoaDonRepository : IHoaDonRepository
    {
        private readonly QuanLyVatTuContext _context;

        public HoaDonRepository(QuanLyVatTuContext context)
        {
            _context = context;
        }

        /**  IEnumerable<HoaDonVM> IHoaDonRepository.GetAllHoaDons()
          {
              var hoaDonsDb = _context.HoaDons;

              // Chuyển đổi sang danh sách các đối tượng HoaDonVM
              var hoaDonVm = hoaDonsDb.Select(HoaDon => new HoaDonVM()
              {   IdHoaDon = HoaDon.IdHoaDon,
                  TenHoaDon = HoaDon.TenHoaDon,
                  SoHoaDon = HoaDon.SoHoaDon,
                  IdPhieuDeNghiMua = HoaDon.IdPhieuDeNghiMua,
                  DonViCungCap = HoaDon.DonViCungCap,
                  HinhThucThanhToan = HoaDon.HinhThucThanhToan,
                  NgayNhapHoaDon = HoaDon.NgayNhapHoaDon,
                  NgayHoaDon = HoaDon.NgayHoaDon

                 
              });

              return hoaDonVm;
          }
        **/
        public List<HoaDonVM> GetAllHoaDons()
        {

            // Tạo danh sách các đối tượng HoaDonVM

            var hoaDonsDb = from hd in _context.HoaDons
                            join ctp in _context.ChiTietPhieus on hd.IdHoaDon equals ctp.IdHoaDon
                            select new HoaDonVM

                            {

                                IdHoaDon = hd.IdHoaDon,
                                TenHoaDon = hd.TenHoaDon,
                                SoHoaDon = hd.SoHoaDon,
                                IdPhieuDeNghiMua = hd.IdPhieuDeNghiMua,
                                DonViCungCap = hd.DonViCungCap,
                                HinhThucThanhToan = hd.HinhThucThanhToan,
                                NgayNhapHoaDon = hd.NgayNhapHoaDon,
                                NgayHoaDon = hd.NgayHoaDon,
                                //danh sach cac thuoc tính dc them
                                DonGia = ctp.DonGia,

                                TongSoLuong = ctp.TongSoLuong,
                                ThanhTien = ctp.ThanhTien


                            };
         return hoaDonsDb.ToList();
        }
        public HoaDonModel GetHoaDonById(int idHoaDon)
        {
            var hoaDonsDb = _context.HoaDons.Find(idHoaDon);

            if (hoaDonsDb == null)
            {
                return null;
            }

            var hoaDonVm = new HoaDonModel
            {
                IdHoaDon = hoaDonsDb.IdHoaDon,
                TenHoaDon = hoaDonsDb.TenHoaDon,
                SoHoaDon = hoaDonsDb.SoHoaDon,
                IdPhieuDeNghiMua = hoaDonsDb.IdPhieuDeNghiMua,
                DonViCungCap = hoaDonsDb.DonViCungCap,
                HinhThucThanhToan = hoaDonsDb.HinhThucThanhToan,
                NgayNhapHoaDon = hoaDonsDb.NgayNhapHoaDon,
                NgayHoaDon = hoaDonsDb.NgayHoaDon
            };

            return hoaDonVm;
        }

        public HoaDonModel AddHoaDon(HoaDonModel hoaDon)
        {
                var hd = new HoaDon
                {
                    SoHoaDon = hoaDon.SoHoaDon,
                    TenHoaDon = hoaDon.TenHoaDon,
                    IdPhieuDeNghiMua = hoaDon.IdPhieuDeNghiMua,
                    DonViCungCap = hoaDon.DonViCungCap,
                    HinhThucThanhToan = hoaDon.HinhThucThanhToan,
                    NgayNhapHoaDon = hoaDon.NgayNhapHoaDon,
                    NgayHoaDon = hoaDon.NgayHoaDon
                };

                _context.HoaDons.Add(hd);
                _context.SaveChanges();
            return new HoaDonModel
            {

                SoHoaDon = hd.SoHoaDon,
                TenHoaDon = hd.TenHoaDon,
                IdPhieuDeNghiMua = hd.IdPhieuDeNghiMua,
                DonViCungCap = hd.DonViCungCap,
                HinhThucThanhToan = hd.HinhThucThanhToan,
                NgayNhapHoaDon = hd.NgayNhapHoaDon,
                NgayHoaDon = hd.NgayHoaDon
            };
        }

        public void UpdateHoaDon(int id, HoaDonModel hoaDon)
        {
            var _hoaDon = _context.HoaDons.SingleOrDefault(o => o.IdHoaDon == id);
            if (_hoaDon != null)
            {
                _hoaDon.SoHoaDon = hoaDon.SoHoaDon;
                _hoaDon.TenHoaDon = hoaDon.TenHoaDon;
                _hoaDon.IdPhieuDeNghiMua = hoaDon.IdPhieuDeNghiMua;
                _hoaDon.DonViCungCap = hoaDon.DonViCungCap;
                _hoaDon.HinhThucThanhToan = hoaDon.HinhThucThanhToan;
                _hoaDon.NgayNhapHoaDon = hoaDon.NgayNhapHoaDon;
                _hoaDon.NgayHoaDon = hoaDon.NgayHoaDon;

                _context.SaveChanges();
            }
        }

        public void DeleteHoaDon(int id)
        {
            var hoadon = _context.HoaDons.Find(id);
            _context.HoaDons.Remove(hoadon);
            _context.SaveChanges();
        }
        
    }
}

