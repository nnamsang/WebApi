using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IHoaDonRepository
    {
        List<HoaDonVM> GetAllHoaDons();
        HoaDonModel GetHoaDonById(int id);
        public HoaDonModel AddHoaDon(HoaDonModel hoaDon);
        public void UpdateHoaDon(int id,HoaDonModel hoaDon);
       public void DeleteHoaDon(int id);

      
    }
}
