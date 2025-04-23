﻿using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServicesController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ServiceList()
        {
            var services = _context.Services.ToList();
            return Ok(services);
        }

        [HttpGet("GetById")]
        public IActionResult GetService(int id)
        {
            var service = _context.Services.Find(id);
            return Ok(service);
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("Updated");
        }

        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var sercice = _context.Services.Find(id);
            _context.Services.Remove(sercice);
            _context.SaveChanges();
            return Ok("Deleted");
        }

    }
}
