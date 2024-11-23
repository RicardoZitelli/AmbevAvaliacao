using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Handler for processing UpdateSaleCommand requests.
/// </summary>
public class UpdateSaleHandler : IRequestHandler<UpdateSaleCommand, bool>
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
    public async Task<bool> Handle(UpdateSaleCommand request, CancellationToken cancellationToken)
    {
        var sale = await _saleRepository.GetByIdAsync(request.SaleId, cancellationToken);
        if (sale == null)
            throw new KeyNotFoundException($"Sale with ID {request.SaleId} not found");

        sale.Customer = request.Customer;
        sale.Branch = request.Branch;
        sale.UpdateSale(request.UpdatedBy);

        await _saleRepository.UpdateAsync(sale, cancellationToken);

        return true;
    }
}
