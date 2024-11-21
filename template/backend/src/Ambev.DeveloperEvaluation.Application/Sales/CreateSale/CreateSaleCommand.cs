using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.CreateSale;

/// <summary>
/// Command for creating a sale
/// </summary>
public record CreateSaleCommand : IRequest<CreateSaleResponse>
{
    public string SaleNumber { get; }
    public DateTime SaleDate { get; }
    public string Customer { get; }
    public string Branch { get; }
    public string CreatedBy { get; }
    public List<SaleItemDto> Items { get; }

    public CreateSaleCommand(string saleNumber, DateTime saleDate, string customer, string branch, string createdBy, List<SaleItemDto> items)
    {
        SaleNumber = saleNumber;
        SaleDate = saleDate;
        Customer = customer;
        Branch = branch;
        CreatedBy = createdBy;
        Items = items;
    }
}

/// <summary>
/// DTO for SaleItem in CreateSaleCommand
/// </summary>
public record SaleItemDto(string Product, int Quantity, decimal UnitPrice, decimal Discount, decimal TotalAmount);
