using WebApi.ViewModels;

namespace WebApi.Repository
{
    public interface IVatTuRepositoty
    {
        List<VatTuVM> GetAllVatTu();

        VatTuVM GetById(int id);
        VatTuVM AddVatTu(VatTuVM vatTuVm);

        void DeleteVatTu(int id);
        Task UpdataAsync(int id, VatTuVM vatTuVM);
    }
}
