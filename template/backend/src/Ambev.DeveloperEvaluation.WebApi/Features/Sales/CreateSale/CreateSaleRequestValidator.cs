using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.CreateSale;

/// <summary>
/// Validator for CreateSaleRequest that defines validation rules for sale creation.
/// </summary>
public class CreateSaleRequestValidator : AbstractValidator<CreateSaleRequest>
{
    /// <summary>
    /// Initializes a new instance of the CreateSaleRequestValidator with defined validation rules.
    /// </summary>
    /// <remarks>
    /// Validation rules include:
    /// - SaleNumber: Required, length between 1 and 50 characters
    /// - SaleDate: Cannot be in the future
    /// - Customer: Required, length between 3 and 100 characters
    /// - Branch: Required, length between 3 and 50 characters
    /// - Items: Must contain at least one item
    /// </remarks>
    public CreateSaleRequestValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required.")
            .Length(1, 50).WithMessage("Sale number must be between 1 and 50 characters.");

        RuleFor(sale => sale.SaleDate)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("Sale date cannot be in the future.");

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