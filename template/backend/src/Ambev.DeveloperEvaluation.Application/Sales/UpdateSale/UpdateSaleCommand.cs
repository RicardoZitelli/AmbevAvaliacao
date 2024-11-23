using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;

/// <summary>
/// Command for updating a sale.
/// </summary>
public class UpdateSaleCommand : IRequest<bool>
{
    /// <summary>
    /// The unique identifier of the sale to update.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// The updated customer name.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// The updated branch name.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// The user who updated the sale.
    /// </summary>
    public string UpdatedBy { get; set; } = string.Empty;

    /// <summary>
    /// Initializes a new instance of the UpdateSaleCommand class.
    /// </summary>
    /// <param name="saleId">The unique identifier of the sale.</param>
    /// <param name="customer">The updated customer name.</param>
    /// <param name="branch">The updated branch name.</param>
    /// <param name="updatedBy">The user who updated the sale.</param>
    public UpdateSaleCommand(Guid saleId, string customer, string branch, string updatedBy)
    {
        SaleId = saleId;
        Customer = customer;
        Branch = branch;
        UpdatedBy = updatedBy;
    }
}
