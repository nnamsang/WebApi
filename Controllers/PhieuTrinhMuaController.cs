using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhieuTrinhMuaController : ControllerBase
    {
        private readonly IPhieuTrinhMuaRepo _repo;

        public PhieuTrinhMuaController(IPhieuTrinhMuaRepo repo) 
        {
            _repo= repo;

        }
        [HttpGet]
        public IActionResult GetAll() 
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_repo.GetById(id));
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult Add(PhieuTrinhMuaModel vm)
        {
            try
            {
                return Ok( _repo.Add(vm));
            }
            catch
            {
                return BadRequest();
            }

        }
        [HttpPut("id")]
        public IActionResult UpdateById(int id, PhieuTrinhMuaModel vm)
        {
            try
            {
                _repo.Update(id, vm);
                return new JsonResult("update thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            try
            {
                _repo.DeleteById(id);
                return new JsonResult("delete thanh cong");
            }
            catch
            {
                return BadRequest();
            }
        }
        
    }
}
