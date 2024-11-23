using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

public record GetSaleQuery(Guid SaleId) : IRequest<GetSaleResult>;