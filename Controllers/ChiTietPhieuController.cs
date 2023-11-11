using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietPhieuController : ControllerBase
    {
        private readonly IChiTietPhieuRepo _repo;

        public ChiTietPhieuController(IChiTietPhieuRepo repo)
        {
            _repo = repo;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repo.GetAll());
        }
        [HttpGet("id")]
        public IActionResult GetById(int id) 
        { 
            return Ok(_repo.GetById(id));
        }
        [HttpPost]
        public IActionResult Post(ChiTietPhieuModel vm)
        {
            return Ok(_repo.Add(vm));
        }
        [HttpPut("id")]
        public IActionResult Update(int id, ChiTietPhieuModel vm)
        {
            _repo.update(id, vm);
            return new JsonResult("update thanh cong");
        }
        [HttpDelete("id")]
        public IActionResult DeleteById(int id)
        {
            _repo.DeleteById(id);
            return new JsonResult("delete thanh cong");
        }
    }
}
