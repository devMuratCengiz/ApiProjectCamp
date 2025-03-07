using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x=>x.Name).NotEmpty().WithMessage("Ürün adı boş bırakılamaz!");
            RuleFor(x=>x.Name).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır!");
            RuleFor(x=>x.Name).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır!");

            RuleFor(x=>x.Price).NotEmpty().WithMessage("Ürün fiyatı boş bırakılamaz!").GreaterThan(0).WithMessage("Ürün fiyatı 0'dan küçük olamaz!").LessThan(1000).WithMessage("Ürün fiyatı 1000'den fazla olamaz!");

            RuleFor(x=>x.Description).NotEmpty().WithMessage("Ürün açıklaması boş bırakılamaz!");
        }
    }
}
