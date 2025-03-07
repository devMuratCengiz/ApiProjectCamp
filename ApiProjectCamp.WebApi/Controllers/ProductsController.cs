using ApiProjectCamp.WebApi.Context;
using ApiProjectCamp.WebApi.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectCamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _productValidator;
        private readonly ApiContext _context;

        public ProductsController(IValidator<Product> productValidator, ApiContext context)
        {
            _productValidator = productValidator;
            _context = context;
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
            var validatorResult = _productValidator.Validate(product);
            if (!validatorResult.IsValid)
            {
                foreach (var error in validatorResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün ekleme işlemi başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Silmek istediğiniz ürün bulunamadı!");
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün silme işlemi başarılı.");
        }
        [HttpGet("GetById")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound("Ürün bulunamadı!");
            }
            return Ok(product);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validatorResult = _productValidator.Validate(product);
            if (!validatorResult.IsValid)
            {
                foreach (var error in validatorResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return BadRequest(ModelState);
            }
            _context.Products.Update(product);
            _context.SaveChanges();
            return Ok("Ürün güncelleme işlemi başarılı.");
        }
    }
}
