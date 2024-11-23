﻿using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Validator for GetSaleRequest.
/// </summary>
public class GetSaleRequestValidator : AbstractValidator<GetSaleRequest>
{
    /// <summary>
    /// Initializes validation rules for GetSaleRequest.
    /// </summary>
    public GetSaleRequestValidator()
    {
        RuleFor(request => request.SaleId)
            .NotEmpty()
            .WithMessage("Sale ID is required.");
    }
}
