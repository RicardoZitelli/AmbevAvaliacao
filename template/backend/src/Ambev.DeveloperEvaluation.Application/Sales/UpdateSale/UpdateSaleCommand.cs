using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

public record UpdateSaleCommand(Guid SaleId, string Customer, string Branch, string UpdatedBy) : IRequest<bool>;
