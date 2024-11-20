using Ambev.DeveloperEvaluation.Domain.Entities;
using FluentValidation;

namespace Ambev.DeveloperEvaluation.Domain.Validation;

/// <summary>
/// Validates a Sale entity to ensure it adheres to business rules.
/// </summary>
public class SaleValidator : AbstractValidator<Sale>
{
    public SaleValidator()
    {
        RuleFor(sale => sale.SaleNumber)
            .NotEmpty().WithMessage("Sale number is required.")
            .MaximumLength(50).WithMessage("Sale number cannot exceed 50 characters.");

        RuleFor(sale => sale.Customer)
            .NotEmpty().WithMessage("Customer is required.")
            .MaximumLength(100).WithMessage("Customer name cannot exceed 100 characters.");

        RuleFor(sale => sale.Branch)
            .NotEmpty().WithMessage("Branch is required.")
            .MaximumLength(50).WithMessage("Branch name cannot exceed 50 characters.");

        RuleFor(sale => sale.CreatedBy)
            .NotEmpty().WithMessage("CreatedBy is required.")
            .MaximumLength(100).WithMessage("CreatedBy cannot exceed 100 characters.");

        RuleFor(sale => sale.CreatedAt)
            .NotEmpty().WithMessage("CreatedAt is required.")
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("CreatedAt cannot be in the future.");

        RuleFor(sale => sale.UpdatedBy)
            .MaximumLength(100).WithMessage("UpdatedBy cannot exceed 100 characters.");

        RuleFor(sale => sale.UpdatedAt)
            .LessThanOrEqualTo(DateTime.UtcNow).WithMessage("UpdatedAt cannot be in the future.");
    }
}

