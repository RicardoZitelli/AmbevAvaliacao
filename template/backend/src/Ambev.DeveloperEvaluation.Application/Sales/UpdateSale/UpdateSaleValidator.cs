using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Validator for UpdateSaleCommand
/// </summary>
public class UpdateSaleValidator : AbstractValidator<UpdateSaleCommand>
{
    public UpdateSaleValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Sale ID is required.");

        RuleFor(x => x.SaleNumber)
            .NotEmpty()
            .WithMessage("Sale Number is required.");

        RuleFor(x => x.Customer)
            .NotEmpty()
            .WithMessage("Customer is required.");

        RuleFor(x => x.Branch)
            .NotEmpty()
            .WithMessage("Branch is required.");

        RuleFor(x => x.UpdatedBy)
            .NotEmpty()
            .WithMessage("User updating the sale is required.");

        RuleFor(x => x.IsCancelled)
            .NotNull()
            .WithMessage("IsCancelled status is required.");
    }
}
