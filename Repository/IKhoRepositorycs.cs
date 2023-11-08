using WebApi.Data.Models;
using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IKhoRepository
    {
        KhoVM GetKhoById(int id);
        IEnumerable<KhoVM> GetAllKhos();
        KhoVM AddKho(KhoVM kho);
        public void UpdateKho(KhoVM kho, int id);
        public void DeleteKho(int id);
    }
}
