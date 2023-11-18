using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebApi.Data.Models;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VatTuController : ControllerBase
    {
        private readonly IVatTuRepositoty _vatTuRepo;
        private readonly QuanLyVatTuContext _context;

        public VatTuController(IVatTuRepositoty vatTuRepo, QuanLyVatTuContext context) 
        {
            _vatTuRepo=vatTuRepo;
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var vatTus = _vatTuRepo.GetAllVatTu();
            return Ok(vatTus);
        }
        [HttpGet("id")]
        public IActionResult GetById(int id) 
        {
            var vatTu = _vatTuRepo.GetById(id);


                if (vatTu == null)
                {
                    return NotFound();
                }
                return Ok(vatTu);
            
        }
        [HttpDelete("id")]
        public IActionResult DeleteByName(int  id)
        {
            try
            {
                _vatTuRepo.DeleteVatTu(id);
                return NoContent();
            }
            catch { 
                return StatusCode(statusCode:500);
            }
            
        }
        [HttpPost]
        public async Task<IActionResult> PostAnh( VatTuVM vatTu)
        {
            var anh = new VatTu { 
                IdVatTu = vatTu.IdVatTu,
                TenVatTu = vatTu.TenVatTu,
                MaVatTu = vatTu.MaVatTu,
                DonViTinh = vatTu.DonViTinh,
                SoLuongTonKho = vatTu.SoLuongTonKho,
                IdKho = vatTu?.IdKho,
                ViTri = vatTu?.ViTri,
                GhiChu = vatTu?.GhiChu  

            };
            //lấy đường dẫn hình ảnh
            if (vatTu.Imger.Length > 0)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", vatTu.Imger.FileName);
                using (var stream = System.IO.File.Create(path))
                {
                    await vatTu.Imger.CopyToAsync(stream);
                }
                anh.HinhAnhVatTu = "/images/" + vatTu.Imger.FileName;
            }
            else

            {
                anh.HinhAnhVatTu = " ";
            }
            _context.VatTus.Add(anh);
            _context.SaveChanges();
            return Ok(anh);
        }
        [HttpPut("id")]
        
        public async Task<IActionResult> UpdateVatTuAsync(int id, [FromForm] VatTuVM vatTu)
        {

            try
            {
                await _vatTuRepo.UpdataAsync(id, vatTu);
                return new JsonResult("update thanh cong");
            }
            catch
            {
                return StatusCode(statusCode: 500);
            }
        }
    }
}
