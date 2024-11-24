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
        
        var sale = new Sale()
        {
            Id = Guid.NewGuid(),
            SaleNumber = request.SaleNumber,            
            Customer = request.Customer,
            Branch = request.Branch,            
            SaleDate = DateTime.UtcNow,
            CreatedBy = request.CreatedBy,                
            Items = request.Items.Select(i => new SaleItem
            {
                Id = Guid.NewGuid(),
                Product = i.Product,
                Quantity = i.Quantity,
                UnitPrice = i.UnitPrice,                
            }).ToList()
        };

        sale.CreateSaleDate();                
        sale.Items.ForEach(item => item.ApplyDiscount());
        sale.CalculateTotalAmount();
                
        await _saleRepository.CreateAsync(sale, cancellationToken);

        return new CreateSaleResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,            
            Customer = sale.Customer,
            Branch = sale.Branch,
            SaleDate = sale.SaleDate,
            TotalAmount = sale.TotalAmount,
            IsCancelled = sale.IsCancelled,
            Items = sale.Items.Select(item => new SaleItemResult
            {
                Id = item.Id,
                Product = item.Product,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Discount = item.Discount,
                TotalAmount = item.TotalAmount,
                SaleId = item.SaleId
            }).ToList()
        };

    }
}
