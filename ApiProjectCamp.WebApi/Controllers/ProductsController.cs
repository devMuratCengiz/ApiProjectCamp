using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.DTOs.ProductDtos;
using ApiProjectCamp.WebApi.Entities;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IValidator<Product> _validator;
        private readonly ApiContext _context;

        public ProductsController(IMapper mapper, ApiContext context, IValidator<Product> validator)
        {
            _mapper = mapper;
            _context = context;
            _validator = validator;
        }

        [HttpGet]
        public IActionResult ProductList()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }

        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x=>x.ErrorMessage));
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Added");
        }

        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if(product == null)
            {
                return NotFound("Id not found.");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Deleted");
        }

        [HttpGet("GetById")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Id not found");
            }
            return Ok(product);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if(!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Updated");
        }

        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDto createProductDto)
        {
            var product = _mapper.Map<Product>(createProductDto);
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Added");
        }

        [HttpGet("PorductListWihtCategory")]
        public IActionResult PorductListWihtCategory()
        {
            var products = _context.Products.Include(p => p.Category).ToList();
            return Ok(_mapper.Map<List<ResultProductWithCategoryDto>>(products));
        }
    }
}
