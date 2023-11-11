using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoController : ControllerBase
    {
        private readonly IKhoRepository _khoRepository;
        private readonly QuanLyVatTuContext _context;

        public KhoController(IKhoRepository khoRepository)
        {
            _khoRepository = khoRepository;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var khos = _khoRepository.GetAllKhos();
            return Ok(khos);
        }
        [HttpGet("{id}")]
        public KhoVM GetKhoById(int idKho)
        {
            return _khoRepository.GetKhoById(idKho);
        }
        [HttpPost]
        public void AddKho(KhoVM kho)
        {
            _khoRepository.AddKho(kho);
        }

        [HttpPut("id")]
        public void UpdateKho(int id, KhoVM kho)
        {
            _khoRepository.UpdateKho(id, kho);

        }


        [HttpDelete("{id}")]
        public void DeleteKho(int idKho, int id)
        {
            _khoRepository.DeleteKho(idKho);
        }
    }
}
