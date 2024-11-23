namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.ListSales;

/// <summary>
/// Request model for listing sales with optional filters.
/// </summary>
public class ListSalesRequest
{
    /// <summary>
    /// Gets or sets the optional filter for customer name.
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Gets or sets the optional filter for branch.
    /// </summary>
    public string? Branch { get; set; }
}
