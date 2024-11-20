using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validates a SaleItem entity to ensure it adheres to business rules.
/// </summary>
public class SaleItemValidator : AbstractValidator<SaleItem>
{
    public SaleItemValidator()
    {
        RuleFor(item => item.Product)
            .NotEmpty().WithMessage("Product name cannot be empty.")
            .MaximumLength(100).WithMessage("Product name cannot exceed 100 characters.");

        RuleFor(item => item.Quantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than 0.")
            .LessThanOrEqualTo(20).WithMessage("Quantity cannot exceed 20.");

        RuleFor(item => item.UnitPrice)
            .GreaterThan(0).WithMessage("Unit price must be greater than 0.");

        RuleFor(item => item.Discount)
            .GreaterThanOrEqualTo(0).WithMessage("Discount cannot be negative.");

        RuleFor(item => item.TotalAmount)
            .GreaterThanOrEqualTo(0).WithMessage("Total amount cannot be negative.");

        RuleFor(item => item)
            .Must(BeValidDiscount).WithMessage("Discount rules are violated.");

    }

    /// <summary>
    /// Ensures the discount rules are applied correctly for a SaleItem.
    /// </summary>
    private bool BeValidDiscount(SaleItem item)
    {
        if (item.Quantity < 4 && item.Discount > 0)
            return false;

        if (item.Quantity >= 4 && item.Quantity < 10 && item.Discount != item.Quantity * item.UnitPrice * 0.1m)
            return false;

        if (item.Quantity >= 10 && item.Quantity <= 20 && item.Discount != item.Quantity * item.UnitPrice * 0.2m)
            return false;

        return true;
    }
}
