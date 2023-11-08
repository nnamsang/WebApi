using Newtonsoft.Json;
using WebApi.Data.Models;
using WebApi.ViewModels;
using static System.Net.WebRequestMethods;

namespace WebApi.Repository
{
    public interface IPhieuTrinhMuaRepo
    {
        List<PhieuTrinhMuaVM> GetAll();
        PhieuTrinhMuaVM GetById(int id);
        PhieuTrinhMuaModel Add(PhieuTrinhMuaModel vm);
        void DeleteById(int id);
        void Update(int id, PhieuTrinhMuaModel vm);
    }
    public class PhieuTrinhMuaRepo : IPhieuTrinhMuaRepo
    {
        private readonly QuanLyVatTuContext _context;

        public PhieuTrinhMuaRepo(QuanLyVatTuContext context)
        {
            _context = context;
        }

        public PhieuTrinhMuaModel Add(PhieuTrinhMuaModel vm)
        {
            var phieu = new PhieuTrinhMua
            {
              // IdPhieuDeNghiMua = vm.IdPhieuDeNghiMua,
               IdUser = vm.IdUser,
               LyDoSuaPhieu = vm.LyDoSuaPhieu,
               SoLanSuaPhieu = vm.SoLanSuaPhieu,
               TimeTaoPhieu = vm.TimeTaoPhieu,
                
                

            };
            _context.PhieuTrinhMuas.Add(phieu);
            _context.SaveChanges();
            return new PhieuTrinhMuaModel
            {

                IdPhieuDeNghiMua = phieu.IdPhieuDeNghiMua,
                IdUser = phieu.IdUser,
                LyDoSuaPhieu = phieu.LyDoSuaPhieu,
                SoLanSuaPhieu = phieu.SoLanSuaPhieu,
                TimeTaoPhieu = phieu.TimeTaoPhieu,
            };
        }

        public void DeleteById(int id)
        {
            var phieu = _context.PhieuTrinhMuas.SingleOrDefault(p=>p.IdPhieuDeNghiMua == id);
            _context.Remove(phieu);
        }

        public List<PhieuTrinhMuaVM> GetAll()
        {
            var phieu = from p in _context.PhieuTrinhMuas
                        join ctp in _context.ChiTietPhieus on p.IdPhieuDeNghiMua equals ctp.IdPhieuDeNghiMua
                        join vt in _context.VatTus on ctp.IdVatTu equals vt.IdVatTu
                        join u in _context.Users on p.IdUser equals u.IdUser
                        select new PhieuTrinhMuaVM
                        {
                            IdPhieuDeNghiMua = p.IdPhieuDeNghiMua,
                            IdUser = p.IdUser,
                            LyDoSuaPhieu = p.LyDoSuaPhieu,
                            SoLanSuaPhieu = p.SoLanSuaPhieu,
                            TongSoLuong = (float)ctp.TongSoLuong,
                            HoTen = u.HoTen,
                            MaVatTu = vt.MaVatTu,
                            TenVatTu = vt.TenVatTu,
                            TimeTaoPhieu = p.TimeTaoPhieu,
                            TongTien = ctp.ThanhTien ?? 0
                        };
            return phieu.ToList();
        }

        public PhieuTrinhMuaVM GetById(int id)
        {
            var phieu = (from p in _context.PhieuTrinhMuas
                         join ctp in _context.ChiTietPhieus on p.IdPhieuDeNghiMua equals ctp.IdPhieuDeNghiMua
                         join vt in _context.VatTus on ctp.IdVatTu equals vt.IdVatTu
                         join u in _context.Users on p.IdUser equals u.IdUser
                         where p.IdPhieuDeNghiMua == id
                         select new PhieuTrinhMuaVM
                         {

                             IdPhieuDeNghiMua = p.IdPhieuDeNghiMua,
                             IdUser = p.IdUser,
                             LyDoSuaPhieu = p.LyDoSuaPhieu,
                             SoLanSuaPhieu = p.SoLanSuaPhieu,
                             TongSoLuong = (float)ctp.TongSoLuong,
                             HoTen = u.HoTen,
                             MaVatTu = vt.MaVatTu,
                             TenVatTu = vt.TenVatTu,
                             TimeTaoPhieu = p.TimeTaoPhieu,
                             TongTien = ctp.ThanhTien ?? 0

                         }).FirstOrDefault();
            var jsonUser = JsonConvert.SerializeObject(phieu);
            return JsonConvert.DeserializeObject<PhieuTrinhMuaVM>(jsonUser);
        }

        public void Update(int id, PhieuTrinhMuaModel vm)
        {
            var phieu = _context.PhieuTrinhMuas.SingleOrDefault(p => p.IdPhieuDeNghiMua == id);
            phieu.IdUser = vm.IdUser;
            phieu.IdPhieuDeNghiMua = vm.IdPhieuDeNghiMua;
            phieu.LyDoSuaPhieu = vm.LyDoSuaPhieu;
            phieu.SoLanSuaPhieu = vm.SoLanSuaPhieu;
            phieu.TimeTaoPhieu = vm.TimeTaoPhieu;
            _context.SaveChanges();

        }
    }
}
