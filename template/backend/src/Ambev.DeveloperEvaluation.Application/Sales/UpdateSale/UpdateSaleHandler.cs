using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests.
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, UpdateSaleResult>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of the UpdateSaleHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    public UpdateSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the UpdateSaleCommand request.
    /// </summary>
    /// <param name="request">The UpdateSaleCommand request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>True if the update was successful.</returns>
    public async Task<UpdateSaleResult> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateSaleValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }

        var sale = await _saleRepository.GetByIdAsync(request.Id, cancellationToken) 
            ?? throw new KeyNotFoundException($"Sale with ID {request.Id} not found");

        sale.SaleNumber = request.SaleNumber;
        sale.Customer = request.Customer;
        sale.Branch = request.Branch;
        sale.CancelSale(request.UpdatedBy, request.IsCancelled);        

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return new UpdateSaleResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            SaleDate = sale.SaleDate,
            Customer = sale.Customer,
            Branch = sale.Branch,
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
                IsCancelled = item.IsCancelled,
                SaleId = item.SaleId
                
            }).ToList()
        };        
    }
}
