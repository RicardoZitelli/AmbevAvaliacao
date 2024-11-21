namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Response model for SaleList operation
/// </summary>
public record SaleListResponse(List<SaleListItemDto> Sales);

/// <summary>
/// DTO for a single sale in the list
/// </summary>
public record SaleListItemDto(
    Guid SaleId,
    string SaleNumber,
    DateTime SaleDate,
    string Customer,
    string Branch,
    decimal TotalAmount,
    bool IsCancelled);
