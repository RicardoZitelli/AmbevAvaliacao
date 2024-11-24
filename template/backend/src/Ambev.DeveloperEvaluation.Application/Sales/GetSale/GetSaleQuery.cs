using Ambev.DeveloperEvaluation.Application.Sales.GetSale;
using MediatR;

public class GetSaleQuery : IRequest<GetSaleResult>
{
    public Guid SaleId { get; set; }

    public GetSaleQuery(Guid saleId)
    {
        SaleId = saleId;
    }
}
