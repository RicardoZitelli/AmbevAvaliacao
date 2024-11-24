using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.ListSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

/// <summary>
/// Profile for mapping ListSales feature.
/// </summary>
public class ListSalesProfile : Profile
{
    public ListSalesProfile()
    {
        CreateMap<ListSaleQuery, ListSalesRequest>();
        CreateMap<ListSalesResult, ListSaleResponse>();        
    }
}
