using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public class VatTuRepository : IVatTuRepositoty
    {
        private readonly QuanLyVatTuContext _context;

        public VatTuRepository(QuanLyVatTuContext context) {
            _context = context;
        
        }
        public VatTuVM AddVatTu(VatTuVM vatTuVM)
          {
            var vatTu = new VatTu
            {
                IdVatTu = vatTuVM.IdVatTu,
                TenVatTu = vatTuVM.TenVatTu,
                MaVatTu = vatTuVM.MaVatTu,
                DonViTinh = vatTuVM.DonViTinh,
                SoLuongTonKho = vatTuVM.SoLuongTonKho,
                IdKho = vatTuVM.IdKho,
                ViTri = vatTuVM.ViTri,
                GhiChu = vatTuVM.GhiChu,
                HinhAnhVatTu = vatTuVM.HinhAnhVatTu

            };
            _context.Add(vatTu);
            _context.SaveChanges();
            return new VatTuVM
            {
                IdVatTu = vatTu.IdVatTu,
                TenVatTu = vatTu.TenVatTu,
                MaVatTu = vatTu.MaVatTu,
                DonViTinh = vatTu.DonViTinh,
                SoLuongTonKho = vatTu.SoLuongTonKho,
                IdKho = vatTu.IdKho,
                ViTri = vatTu.ViTri,
                GhiChu = vatTu.GhiChu,
                HinhAnhVatTu = vatTu.HinhAnhVatTu
            };
        }

        public void DeleteVatTu(int id)
        {
            var vatTu = _context.VatTus.SingleOrDefault(v => v.IdVatTu == id);

            _context.VatTus.Remove(vatTu);
            _context.SaveChanges();
        }

        public List<VatTuVM> GetAllVatTu()
        {
            var vatTu = _context.VatTus.Select(v => new VatTuVM
            {
                IdVatTu =v.IdVatTu,
                TenVatTu=v.TenVatTu,
                MaVatTu=v.MaVatTu,
                DonViTinh =v.DonViTinh,
                SoLuongTonKho = v.SoLuongTonKho,
                IdKho = v.IdKho,
                ViTri = v.ViTri,
                GhiChu = v.GhiChu,  
                HinhAnhVatTu =v.HinhAnhVatTu
            });
            return vatTu.ToList();
        }

        public VatTuVM GetById(int id)
        {
            var vatTus = _context.VatTus.SingleOrDefault(v => v.IdVatTu == id);
            if (vatTus != null)
            {
                return new VatTuVM
                {
                    IdVatTu = vatTus.IdVatTu,
                    TenVatTu = vatTus.TenVatTu,
                    MaVatTu = vatTus.MaVatTu,
                    DonViTinh = vatTus.DonViTinh,
                    SoLuongTonKho = vatTus.SoLuongTonKho,
                    IdKho = vatTus.IdKho,
                    ViTri = vatTus.ViTri,
                    GhiChu = vatTus.GhiChu,
                    HinhAnhVatTu = vatTus.HinhAnhVatTu
                };

            }
            return null;
            
        }

        public async Task UpdataAsync(int id, VatTuVM vatTuVM)
        {
            var vatTu= _context.VatTus.SingleOrDefault(v=>v.IdVatTu == id);
            if(vatTu != null)
            {
                vatTu.IdVatTu = vatTuVM.IdVatTu;
                vatTu.TenVatTu = vatTuVM.TenVatTu;
                vatTu.MaVatTu = vatTuVM.MaVatTu;
                vatTu.DonViTinh = vatTuVM.DonViTinh;
                vatTu.SoLuongTonKho = vatTuVM.SoLuongTonKho;
                vatTu.IdKho = vatTuVM.IdKho;
                vatTu.ViTri = vatTuVM.ViTri;
                vatTu.GhiChu = vatTuVM.GhiChu;
                if (vatTuVM.Imger != null && vatTuVM.Imger.Length > 0)
                {
                    var uniqueFileName = Guid.NewGuid().ToString() + "_" + vatTuVM.Imger.FileName;
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", uniqueFileName);

                    using (var stream = new FileStream(uploadPath, FileMode.Create))
                    {
                        await vatTuVM.Imger.CopyToAsync(stream);
                    }

                    vatTu.HinhAnhVatTu = "/images/" + uniqueFileName;
                }

                _context.Entry(vatTu).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        
    }
}
