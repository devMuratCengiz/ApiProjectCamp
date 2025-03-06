using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.DTOs.FeatureDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly ApiContext _context;
        private readonly IMapper _mapper;

        public FeaturesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values = _context.Features.ToList();
            var mappedValues = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(mappedValues);
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            var value = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Added");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Deleted");
        }
        [HttpGet("GetById")]
        public IActionResult GetFeature(int id)
        {
            var value = _context.Features.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            var mappedValue = _mapper.Map<GetByIdFeatureDto>(value);
            return Ok(mappedValue);
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            var value = _mapper.Map<Feature>(updateFeatureDto);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Updated");
        }
    }
}
