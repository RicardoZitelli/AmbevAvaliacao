using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.GetSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Profile for mapping GetSale feature.
/// </summary>
public class GetSaleProfile : Profile
{
    public GetSaleProfile()
    {
        CreateMap<GetSaleRequest, GetSaleQuery>();
        CreateMap<Application.Sales.GetSale.GetSaleResult, GetSaleResponse>();
        CreateMap<GetSaleItemResponse, SaleItemResponse>();
    }
}
