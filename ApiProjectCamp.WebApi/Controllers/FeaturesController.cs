using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.DTOs.FeaturesDtos;
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
        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public FeaturesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var features = _context.Features.ToList();
            if (features == null || !features.Any())
            {
                return NotFound("No features found.");
            }
            return Ok(_mapper.Map<List<ResultFeatureDto>>(features));
        }

        [HttpGet("GetById")]
        public IActionResult GetFeature(int id)
        {
            var feature = _context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDto>(feature));
        }

        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDto createFeatureDto)
        {
            if (createFeatureDto == null)
            {
                return BadRequest("Feature data is required.");
            }
            var feature = _mapper.Map<Feature>(createFeatureDto);
            _context.Features.Add(feature);
            _context.SaveChanges();
            return Ok("Added");
        }

        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDto updateFeatureDto)
        {
            if (updateFeatureDto == null)
            {
                return BadRequest("Feature data is required.");
            }
            var feature = _context.Features.Find(updateFeatureDto.Id);
            feature.Title = updateFeatureDto.Title;
            feature.Subtitle = updateFeatureDto.Subtitle;
            feature.Description = updateFeatureDto.Description;
            feature.VideoUrl = updateFeatureDto.VideoUrl;
            feature.ImageUrl = updateFeatureDto.ImageUrl;
            _context.Features.Update(feature);
            _context.SaveChanges();
            return Ok("Updated");
        }

        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var feature = _context.Features.Find(id);
            if (feature == null)
            {
                return NotFound("Feature not found.");
            }
            _context.Features.Remove(feature);
            _context.SaveChanges();
            return Ok("Deleted");
        }
    }
}
