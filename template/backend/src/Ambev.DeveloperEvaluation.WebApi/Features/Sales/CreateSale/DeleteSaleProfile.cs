﻿using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale;

/// <summary>
/// Profile for mapping DeleteSale feature.
/// </summary>
public class DeleteSaleProfile : Profile
{
    public DeleteSaleProfile()
    {
        CreateMap<DeleteSaleRequest, DeleteSaleCommand>();
    }
}
