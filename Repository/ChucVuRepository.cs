using System.Runtime.Serialization;
using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public class ChucVuRepository : IChucVuRepository
    {
        private readonly QuanLyVatTuContext _context;
        //private readonly IChucVuRepository _chucVuRepository;
       // private readonly IChucVuRepository? chucVuRepository;

        public ChucVuRepository(QuanLyVatTuContext context)
        {
           // this._chucVuRepository = chucVuRepository;
            this._context = context;
        }

        public IEnumerable<ChucVuVM> GetAllChucVu()
        {
            // Lấy tất cả chức vụ từ database
            var chucVusDb = _context.ChucVus;

            // Chuyển đổi sang danh sách các đối tượng ChucVuVM
            var chucVusVm = chucVusDb.Select(chucVu => new ChucVuVM()
            {
                IdChucVu = chucVu.IdChucVu,
                TenChucVu = chucVu.TenChucVu,
                MaChuVu = chucVu.MaChuVu
            });

            return chucVusVm;
        }
        ChucVuVM IChucVuRepository.GetChucVuById(int id)
        {
            var chucVuDb = _context.ChucVus.Find(id);

            if (chucVuDb == null)
            {
                return null;
            }

            var chucVuVm = new ChucVuVM
            {
                IdChucVu = chucVuDb.IdChucVu,
                TenChucVu = chucVuDb.TenChucVu,
                MaChuVu = chucVuDb.MaChuVu
            };

            return chucVuVm;
        }
        public ChucVuVM AddChucVu(ChucVuVM chucVu)
        {
            if (chucVu != null)
            {
                var cv = new ChucVu
                {
                    IdChucVu = chucVu.IdChucVu,
                    TenChucVu = chucVu.TenChucVu,
                    MaChuVu = chucVu.MaChuVu

                };

                _context.ChucVus.Add(cv);
                _context.SaveChanges();

                var chucVuDb = new ChucVuVM
                {
                    IdChucVu = chucVu.IdChucVu,
                    TenChucVu = chucVu.TenChucVu,
                    MaChuVu = chucVu.MaChuVu
                };

                return chucVuDb;
            }

            return null;

            //_chucVuRepository.AddChucVu(chucVuDb);
        }
        /** public void UpdateChucVu(ChucVuVM chucVu, int id)
         {
             var chucVuDb = _chucVuRepository.GetChucVuById( id);

             chucVuDb.TenChucVu = chucVu.TenChucVu;
             chucVuDb.MaChuVu = chucVu.MaChuVu;

             _chucVuRepository.UpdateChucVu(chucVuDb, id);
         }
        **/
        

        public void DeleteChucVu(int id)
        {
            var chucVu = _context.ChucVus.Find(id);
            _context.ChucVus.Remove(chucVu);
            _context.SaveChanges();
        }

        public void UpdateChucVu(ChucVuVM chucVu, int id)
        {
          
            var _chucVu = _context.ChucVus.SingleOrDefault(o => o.IdChucVu == id);
            if (_chucVu != null)
            {
                _chucVu.TenChucVu = chucVu.TenChucVu;
                _chucVu.MaChuVu = chucVu.MaChuVu;
                _context.SaveChanges();
            }
        }
    }

   
}
