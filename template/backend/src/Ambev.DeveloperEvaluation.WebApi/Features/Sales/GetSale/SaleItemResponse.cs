namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale;

/// <summary>
/// Represents an item in a sale.
/// </summary>
public class SaleItemResponse
{
    /// <summary>
    /// The product name.
    /// </summary>
    public string Product { get; set; } = string.Empty;

    /// <summary>
    /// The quantity of the product.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// The unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// The discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// The total amount for the product.
    /// </summary>
    public decimal TotalAmount { get; set; }
}
