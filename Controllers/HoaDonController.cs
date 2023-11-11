﻿using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Repository;
using WebApi.ViewModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonRepository _hoaDonRepository;
        private readonly QuanLyVatTuContext _context;
        public HoaDonController(IHoaDonRepository hoaDonRepository)
        {
            _hoaDonRepository = hoaDonRepository;
        }
        [HttpGet]
        public ActionResult GetAll()
        {
            var hoaDons = _hoaDonRepository.GetAllHoaDons();
            return Ok(hoaDons);
        }
        [HttpGet("{id}")]
        public HoaDonVM GetHoaDonById(int idHoaDon)
        {
            return _hoaDonRepository.GetHoaDonById(idHoaDon);
        }
        [HttpPost]
        public void AddHoaDon(HoaDonVM hoaDon)
        {
            _hoaDonRepository.AddHoaDon(hoaDon);
        }

        [HttpPut("id")]
        public void UpdateHoaDon(int id, HoaDonVM hoaDon)
        {
            _hoaDonRepository.UpdateHoaDon(id, hoaDon);

        }


        [HttpDelete("{id}")]
        public void DeleteHoaDon( int id)
        {
            _hoaDonRepository.DeleteHoaDon(id);
        }


    }
}
