using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IHoaDonRepository
    {
        IEnumerable<HoaDonVM> GetAllHoaDons();
        HoaDonVM GetHoaDonById(int id);
        public void AddHoaDon(HoaDonVM hoaDon);
        public void UpdateHoaDon(int id,HoaDonVM hoaDon);
       public void DeleteHoaDon(int id);

      
    }
}
