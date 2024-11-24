using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Query for listing sales with optional filters.
/// </summary>
public class ListSaleQuery : IRequest<List<ListSalesResult>>
{  
    public ListSaleQuery()
    {       
    }
}