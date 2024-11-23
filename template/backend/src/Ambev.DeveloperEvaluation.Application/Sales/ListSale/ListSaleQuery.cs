using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.ListSale;

/// <summary>
/// Query for listing sales with optional filters.
/// </summary>
public class ListSaleQuery : IRequest<ListSaleResponse>
{
    /// <summary>
    /// Gets or sets the optional filter for customer name.
    /// </summary>
    public string? Customer { get; set; }

    /// <summary>
    /// Gets or sets the optional filter for branch.
    /// </summary>
    public string? Branch { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ListSaleQuery"/> class.
    /// </summary>
    /// <param name="customer">The optional customer filter.</param>
    /// <param name="branch">The optional branch filter.</param>
    public ListSaleQuery(string? customer = null, string? branch = null)
    {
        Customer = customer;
        Branch = branch;
    }
}