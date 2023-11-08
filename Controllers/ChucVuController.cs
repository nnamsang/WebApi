using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class ChucVuController : ControllerBase
    {
        private readonly IChucVuRepository _chucVuRepository;
        private readonly QuanLyVatTuContext _context;
        public ChucVuController(IChucVuRepository chucVuRepository)
        {
            _chucVuRepository = chucVuRepository;
        }

        //[HttpGet]
        //public IEnumerable<ChucVuVM> GetAllChucVu()
        //{
        //    return _chucVuRepository.GetAllChucVu();
        //}

        [HttpGet]
        public IActionResult GetAll()
        {
            var vatTus = _chucVuRepository.GetAllChucVu();
            return Ok(vatTus);
        }

        [HttpGet("{id}")]
        public ChucVuVM GetChucVuById(int id)
        {
            return _chucVuRepository.GetChucVuById(id);
        }

        [HttpPost]
        public void AddChucVu(ChucVuVM chucVu)
        {
            _chucVuRepository.AddChucVu(chucVu);
        }

        [HttpPut("{id}")]
        public void UpdateChucVu(int id ,ChucVuVM chucVu)
        {
            _chucVuRepository.UpdateChucVu(chucVu, id);
           
        }

        [HttpDelete("{id}")]
        public void DeleteChucVu(int id)
        {
            _chucVuRepository.DeleteChucVu(id);
        }
    }
}

