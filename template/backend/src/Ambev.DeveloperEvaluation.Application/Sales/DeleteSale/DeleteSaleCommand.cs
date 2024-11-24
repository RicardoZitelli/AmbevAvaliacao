using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Command for deleting a sale.
/// </summary>
/// <remarks>
/// This command is used to capture the required data for deleting a sale, 
/// specifically the unique identifier of the sale. It implements 
/// <see cref="IRequest{TResponse}"/> to initiate the request that returns a 
/// <see cref="DeleteSaleResponse"/>.
/// 
/// The data provided in this command is validated using the 
/// <see cref="DeleteSaleCommandValidator"/> to ensure the fields are correctly populated.
/// </remarks>
public class DeleteSaleCommand : IRequest<DeleteSaleResponse>
{
    /// <summary>
    /// Gets or sets the unique identifier of the sale to delete.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Initializes a new instance of the DeleteSaleCommand class.
    /// </summary>
    /// <param name="saleId">The ID of the sale to delete.</param>
    public DeleteSaleCommand(Guid saleId)
    {
        Id = saleId;
    }
}