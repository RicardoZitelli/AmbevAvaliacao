using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale
{
    public class SaleItemValidator : AbstractValidator<SaleItemCommand>
    {
        public SaleItemValidator()
        {
            RuleFor(x => x.Product).NotEmpty().WithMessage("Product name is required.");
            RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
            RuleFor(x => x.UnitPrice).GreaterThan(0).WithMessage("Unit price must be greater than zero.");
        }
    }
}
