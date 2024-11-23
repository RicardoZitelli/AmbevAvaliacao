using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Handler for processing CreateSaleCommand requests.
/// </summary>
public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, CreateSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of the CreateSaleHandler class.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    public CreateSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the CreateSaleCommand request.
    /// </summary>
    /// <param name="request">The create sale command.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A <see cref="CreateSaleResult"/> with the ID of the created sale.</returns>
    public async Task<CreateSaleResult> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
    {        
        var validator = new CreateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var sale = new Sale(request.CreatedBy)
        {
            SaleNumber = request.SaleNumber,
            SaleDate = request.SaleDate,
            Customer = request.Customer,
            Branch = request.Branch,
            Items = request.Items.Select(i => new SaleItem
            {
                Product = i.Product,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice
            }).ToList()
        };
                
        sale.Items.ForEach(item => item.ApplyDiscount());
        sale.CalculateTotalAmount();
                
        await _saleRepository.CreateAsync(sale, cancellationToken);
                
        return new CreateSaleResult { SaleId = sale.Id };
    }
}
