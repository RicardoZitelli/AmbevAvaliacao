namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.UpdateSale;

public class UpdateSaleRequest
{
    public Guid Id { get; set; }
    public required string SaleNumber { get; set; }
    public required string Customer { get; set; }
    public required string Branch { get; set; }
    public bool IsCancelled { get; set; }
    public required string UpdatedBy { get; set; }
}
