using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IKhoRepository
    {
        KhoVM GetKhoById(int id);
        IEnumerable<KhoVM> GetAllKhos();
        KhoVM AddKho(KhoVM kho);
        public void UpdateKho( int id , KhoVM kho);
        public void DeleteKho(int id);
    }
}
