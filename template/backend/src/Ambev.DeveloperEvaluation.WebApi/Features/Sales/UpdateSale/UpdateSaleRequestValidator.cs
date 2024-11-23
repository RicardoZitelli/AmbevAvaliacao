using Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleRequest
/// </summary>
public class UpdateSaleRequestValidator : AbstractValidator<UpdateSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for UpdateSaleRequest
    /// </summary>
    public UpdateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required.")
            .Length(1, 50).WithMessage("Sale number must be between 1 and 50 characters.");

        RuleFor(sale => sale.Customer)
            .NotEmpty().WithMessage("Customer is required.")
            .Length(3, 100).WithMessage("Customer name must be between 3 and 100 characters.");

        RuleFor(sale => sale.Branch)
            .NotEmpty().WithMessage("Branch is required.")
            .Length(3, 50).WithMessage("Branch name must be between 3 and 50 characters.");

        RuleFor(sale => sale.Items)
            .NotEmpty().WithMessage("At least one sale item is required.")
            .ForEach(item => item.SetValidator(new SaleItemRequestValidator()));
    }
}