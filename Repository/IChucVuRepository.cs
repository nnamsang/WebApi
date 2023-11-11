using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IChucVuRepository
    {
        IEnumerable<ChucVuVM> GetAllChucVu();
        ChucVuVM GetChucVuById(int id);
        ChucVuVM AddChucVu(ChucVuVM chucVu);
        public void UpdateChucVu(ChucVuVM chucVu, int id);
        public void DeleteChucVu(int id);
      
    }

}