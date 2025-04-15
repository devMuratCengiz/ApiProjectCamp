using ApiProjectCamp.WebApi.Entities;
using FluentValidation;

namespace ApiProjectCamp.WebApi.ValidationRules
{
    public class ProductValidator : AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().WithMessage("Lütfen ürün adını boş geçmeyiniz.");
            RuleFor(p => p.Name).MinimumLength(2).WithMessage("Ürün adı en az 2 karakter olmalıdır.");
            RuleFor(p => p.Name).MaximumLength(50).WithMessage("Ürün adı en fazla 50 karakter olmalıdır.");

            RuleFor(p => p.Price).NotEmpty().WithMessage("Lütfen ürün adını boş geçmeyiniz.").GreaterThan(0).WithMessage("Ürün fiyatı negatif olamaz.").LessThan(1000).WithMessage("Ürün fiyatı 1000 TL'den fazla olamaz.");

            RuleFor(p => p.Description).NotEmpty().WithMessage("Ürün açıklaması boş geçilemez.");
        }
    }
}
