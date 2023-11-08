using Newtonsoft.Json;
using System.Collections;
using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IPhieuDeNghiVatTuRepotirory
    {
        IEnumerable<PhieuDeNghiVatTuVM> GetAllList();
        PhieuDeNghiVatTuVM GetById(int id);
        PhieuDeNghiVatTuModel Add(PhieuDeNghiVatTuModel phieuM);
        void DeleteById(int id);
        void UpDate(int id, PhieuDeNghiVatTuModel phieuM);

    }
    public class PhieuDeNghiVatTuRepository : IPhieuDeNghiVatTuRepotirory
    {
        private readonly QuanLyVatTuContext _context;

        public PhieuDeNghiVatTuRepository(QuanLyVatTuContext context) { 
            _context = context;
        }
        public PhieuDeNghiVatTuModel Add(PhieuDeNghiVatTuModel phieuM)
        {
            var phieu = new PhieuDeNghiVatTu
            {
                IdLanhDao = phieuM.IdLanhDao,
                IdUser = phieuM.IdUser,
                IdTinhTrangPhieu = phieuM.IdTinhTrangPhieu,
                IdThuTruong = phieuM.IdThuTruong,
                IdPhieuChinhThuc = phieuM.IdPhieuChinhThuc,
                LyDoLapPhieu = phieuM.LyDoLapPhieu,
                LyDoTraPhieu = phieuM.LyDoTraPhieu,
                NguoiTraPhieu = phieuM.NguoiTraPhieu,
                IdPhieuDeNghi = phieuM.IdPhieuDeNghi,
                IdPhieuTam = phieuM.IdPhieuTam,
                IdPhongBan = phieuM.IdPhongBan,
                TimeDuyetPhieu = phieuM.TimeDuyetPhieu,
                TimeTaoPhieu = phieuM.TimeTaoPhieu

                
                
            };
            _context.Add(phieu);
            _context.SaveChanges();
            return new PhieuDeNghiVatTuModel
            {
                IdLanhDao = phieu.IdLanhDao,
                IdUser = phieu.IdUser,
                IdTinhTrangPhieu = phieu.IdTinhTrangPhieu,
                IdThuTruong = phieu.IdThuTruong,
                IdPhieuChinhThuc = phieu.IdPhieuChinhThuc,
                LyDoLapPhieu = phieu.LyDoLapPhieu,
                LyDoTraPhieu = phieu.LyDoTraPhieu,
                NguoiTraPhieu = phieu.NguoiTraPhieu,
                IdPhieuDeNghi = phieu.IdPhieuDeNghi,
                IdPhieuTam = phieu.IdPhieuTam,
                IdPhongBan = phieu.IdPhongBan,
                TimeDuyetPhieu = phieu.TimeDuyetPhieu,
                TimeTaoPhieu = phieu.TimeTaoPhieu
            };
        }

        public void DeleteById(int id)
        {
            var phieu = _context.PhieuDeNghiVatTus.SingleOrDefault(p => p.IdPhieuDeNghi == id);
            _context.Remove(phieu);
        }

        public IEnumerable<PhieuDeNghiVatTuVM> GetAllList()
        {
            var phieu = from p in _context.PhieuDeNghiVatTus 
                        join u in _context.Users on p.IdUser equals u.IdUser 
                        join pb in _context.PhongBans on p.IdPhongBan equals pb.IdPhongBan
                        join ttp in _context.TinhTrangPhieus on p.IdTinhTrangPhieu equals ttp.IdTrinhTrangPhieu
                        join cv in _context.ChucVus on u.IdChucVu equals cv.IdChucVu
                        join tt in _context.Users on p.IdThuTruong equals tt.IdUser
                        join ld in _context.Users on p.IdLanhDao equals ld.IdUser
                        select new PhieuDeNghiVatTuVM
                        
            {
                IdUser = p.IdUser,
                HoTen = u.HoTen,
                TenChucVu = cv.TenChucVu,
                TenPhongBan = pb.TenPhongBan,
                TenLanhDao = ld.HoTen,
                TenTruongPhong = tt.HoTen,
                IdPhieuDeNghi = p.IdPhieuDeNghi,
                IdPhieuTam = p.IdPhieuTam,
                IdPhieuChinhThuc = p.IdPhieuChinhThuc,
                LyDoLapPhieu = p.LyDoLapPhieu,        
                TimeTaoPhieu = p.TimeTaoPhieu,
                TimeDuyetPhieu = p.TimeDuyetPhieu,
                IdTinhTrangPhieu = p.IdTinhTrangPhieu,
                TenTinhTrangDuyet = ttp.TenTinhTrangDuyet,
                IdPhongBan = p.IdPhongBan,
                IdLanhDao = p.IdLanhDao,
                IdThuTruong = p.IdThuTruong
            };
            return phieu;
        }

        public PhieuDeNghiVatTuVM GetById(int id)
        {
            var phieu = (from p in _context.PhieuDeNghiVatTus
                         join u in _context.Users on p.IdUser equals u.IdUser
                         join pb in _context.PhongBans on p.IdPhongBan equals pb.IdPhongBan
                         join ttp in _context.TinhTrangPhieus on p.IdTinhTrangPhieu equals ttp.IdTrinhTrangPhieu
                         join cv in _context.ChucVus on u.IdChucVu equals cv.IdChucVu
                         join tt in _context.Users on p.IdThuTruong equals tt.IdUser
                         join ld in _context.Users on p.IdLanhDao equals ld.IdUser
                         where p.IdUser == id
                         select new PhieuDeNghiVatTuVM
                         {
                             IdUser = p.IdUser,
                             HoTen = u.HoTen,
                             TenChucVu = cv.TenChucVu,
                             TenPhongBan = pb.TenPhongBan,
                             TenLanhDao = ld.HoTen,
                             TenTruongPhong = tt.HoTen,
                             IdPhieuDeNghi = p.IdPhieuDeNghi,
                             IdPhieuTam = p.IdPhieuTam,
                             IdPhieuChinhThuc = p.IdPhieuChinhThuc,
                             LyDoLapPhieu = p.LyDoLapPhieu,
                             TimeTaoPhieu = p.TimeTaoPhieu,
                             TimeDuyetPhieu = p.TimeDuyetPhieu,
                             IdTinhTrangPhieu = p.IdTinhTrangPhieu,
                             TenTinhTrangDuyet = ttp.TenTinhTrangDuyet,
                             IdPhongBan =p.IdPhongBan,
                             IdLanhDao = p.IdLanhDao,
                             IdThuTruong=p.IdThuTruong
                             
                         }).FirstOrDefault();


                var jsonUser = JsonConvert.SerializeObject(phieu);
                return JsonConvert.DeserializeObject<PhieuDeNghiVatTuVM>(jsonUser);
            


        }
            public void UpDate(int id, PhieuDeNghiVatTuModel phieuM)
        {
            var phieu = _context.PhieuDeNghiVatTus.SingleOrDefault(p => p.IdPhieuDeNghi == id);
            phieu.IdLanhDao = phieuM.IdLanhDao;
            phieu.IdUser = phieuM.IdUser;
            phieu.IdTinhTrangPhieu = phieuM.IdTinhTrangPhieu;
            phieu.IdThuTruong = phieuM.IdThuTruong;
            phieu.IdPhieuChinhThuc = phieuM.IdPhieuChinhThuc;
            phieu.LyDoLapPhieu = phieuM.LyDoLapPhieu;
            phieu.LyDoTraPhieu = phieuM.LyDoTraPhieu;
            phieu.NguoiTraPhieu = phieuM.NguoiTraPhieu;
            phieu.IdPhieuDeNghi = phieuM.IdPhieuDeNghi;
            phieu.IdPhieuTam = phieuM.IdPhieuTam;
            phieu.IdPhongBan = phieuM.IdPhongBan;
            phieu.TimeDuyetPhieu = phieuM.TimeDuyetPhieu;
            phieu.TimeTaoPhieu = phieuM.TimeTaoPhieu;
        }
    }

}

