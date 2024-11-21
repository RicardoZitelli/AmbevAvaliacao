using Ambev.DeveloperEvaluation.Application.Sales.ListSale;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.SaleList;

/// <summary>
/// Handler for processing SaleListQuery requests
/// </summary>
public class SaleListHandler : IRequestHandler<SaleListQuery, SaleListResponse>
{
    private readonly ISaleRepository _saleRepository;

    public SaleListHandler(ISaleRepository saleRepository)
    {
        _saleRepository = saleRepository;
    }

    public async Task<SaleListResponse> Handle(SaleListQuery request, CancellationToken cancellationToken)
    {        
        var sales = await _saleRepository.GetAllAsync(cancellationToken);
                
        var response = new SaleListResponse(
            Sales: sales.Select(sale => new SaleListItemDto(
                sale.Id,
                sale.SaleNumber,
                sale.SaleDate,
                sale.Customer,
                sale.Branch,
                sale.TotalAmount,
                sale.IsCancelled
            )).ToList()
        );

        return response;
    }
}
