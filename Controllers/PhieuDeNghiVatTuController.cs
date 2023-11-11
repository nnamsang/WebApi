using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuDeNghiVatTuController : ControllerBase
    {
        private readonly IPhieuDeNghiVatTuRepotirory _phieuRepo;

        public PhieuDeNghiVatTuController(IPhieuDeNghiVatTuRepotirory phieuRepo) {
            _phieuRepo=phieuRepo;
        
        }
        [HttpGet]
        public IActionResult GetAll (){
            try
            {
                return Ok(_phieuRepo.GetAllList());
            }
            catch 
            {
                return BadRequest("looi khong coo du lie");
            }
            
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                var phieu = _phieuRepo.GetById(id);
                return Ok(phieu); 
            }
            catch
            {
                return BadRequest(" không tìm thấy phiếu ");
            }
        }
        [HttpPost]
        public IActionResult Add(PhieuDeNghiVatTuModel phieuM)
        {

            try
            {
                return Ok(_phieuRepo.Add(phieuM));
            }
            catch
            {

                return StatusCode(statusCode: 500);
            }
        }
        [HttpPut("id")]
        public IActionResult PutById(int id, PhieuDeNghiVatTuModel phieuVM)
        {
            try
            {
                _phieuRepo.UpDate(id, phieuVM);
                return NoContent();
            }
            catch 
            {
                return StatusCode(statusCode: 500);
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            try
            {

                _phieuRepo.DeleteById(id);
                return NoContent();
            }
            catch 
            {
                return StatusCode(statusCode: 500);
            }
        }
    }
}
