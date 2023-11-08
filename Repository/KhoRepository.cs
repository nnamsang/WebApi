using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public class KhoRepository : IKhoRepository
    {
        private readonly QuanLyVatTuContext _context;

        public KhoRepository(QuanLyVatTuContext context)
        {
            _context = context;
        }

        public KhoVM AddKho(KhoVM kho)
        {
            if (kho != null)
            {
                var k = new Kho
                {
                    IdKho = kho.IdKho,
                    TenKho = kho.TenKho
                };
                //Console.WriteLine(k.ToString());    
                _context.Khos.Add(k);
                _context.SaveChanges();

                var khoDb = new KhoVM
                {
                    IdKho = kho.IdKho,
                    TenKho = kho.TenKho
                };

                return khoDb;
            }

            return null;
        }

        public void DeleteKho( int id)
        {
            var kho = _context.Khos.Find(id);
            _context.Khos.Remove(kho);
            _context.SaveChanges();
        }

        public IEnumerable<KhoVM> GetAllKhos()
        {
            var khosDb = _context.Khos;

            // Chuyển đổi sang danh sách các đối tượng KhoVM
            var khosVm = khosDb.Select(kho => new KhoVM()
            {
                IdKho = kho.IdKho,
                TenKho = kho.TenKho
            });

            return khosVm;
        }

        public KhoVM GetKhoById(int idKho)
        {
            var khosDb = _context.Khos.Find(idKho);

            if (khosDb == null)
            {
                return null;
            }

            var KhoVm = new KhoVM
            {
                IdKho = khosDb.IdKho,
                TenKho = khosDb.TenKho
            };

            return KhoVm;
        }

        public void UpdateKho(KhoVM kho,int id)
        {
            var _kho = _context.Khos.SingleOrDefault(o => o.IdKho == id);
            if (_kho != null)
            {
                _kho.TenKho = kho.TenKho;
                
                _context.SaveChanges();
            }
        }
    }
       
}
