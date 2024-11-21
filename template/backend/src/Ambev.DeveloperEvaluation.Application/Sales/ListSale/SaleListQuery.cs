using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Query for listing sales with optional filters
/// </summary>
public record SaleListQuery(string? Customer = null, string? Branch = null) : IRequest<SaleListResponse>;
