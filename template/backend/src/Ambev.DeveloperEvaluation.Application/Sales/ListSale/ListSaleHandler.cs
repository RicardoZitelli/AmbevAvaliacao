using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Handler for processing SaleListQuery requests.
/// </summary>
public class ListSaleHandler : IRequestHandler<ListSaleQuery, List<ListSalesResult>>
{
    private readonly ISaleRepository _saleRepository;

    /// <summary>
    /// Initializes a new instance of SaleListHandler.
    /// </summary>
    /// <param name="saleRepository">The sale repository.</param>
    public ListSaleHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    /// <summary>
    /// Handles the SaleListQuery request and returns a SaleListResponse.
    /// </summary>
    /// <param name="request">The SaleListQuery request.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>A SaleListResponse containing the list of sales.</returns>
    public async Task<List<ListSalesResult>> Handle(ListSaleQuery request, CancellationToken cancellationToken)
    {
        var sales = await _saleRepository.GetAllAsync(cancellationToken);

        var response = sales.Select(sale => new ListSalesResult
        {
            Id = sale.Id,
            SaleNumber = sale.SaleNumber,
            SaleDate = sale.SaleDate,
            Customer = sale.Customer,
            Branch = sale.Branch,
            TotalAmount = sale.TotalAmount,
            IsCancelled = sale.IsCancelled,            
            Items = sale.Items?.Select(item => new ListSaleItemResult
            {
                Id = item.Id,
                Product = item.Product,
                Quantity = item.Quantity,
                UnitPrice = item.UnitPrice,
                Discount = item.Discount,
                TotalAmount = item.TotalAmount,
                IsCancelled = item.IsCancelled,
                SaleId = item.SaleId
            }).ToList() ?? []
        }).ToList();

        return response;
    }
}
