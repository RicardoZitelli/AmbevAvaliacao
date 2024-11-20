using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sale in the system with details about the transaction, items, and customer information.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the sale number, which uniquely identifies the sale in the system.
    /// </summary>
    public string SaleNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets the date when the sale was created.
    /// </summary>
    public DateTime SaleDate { get; set; }

    /// <summary>
    /// Gets the customer's name associated with the sale.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Gets the total amount of the sale, calculated from its items.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets the branch where the sale occurred.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Indicates whether the sale is cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Gets the list of items included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; set; } = new();

    /// <summary>
    /// Initializes a new instance of the Sale class and sets the sale date to the current UTC time.
    /// </summary>
    public Sale()
    {
        SaleDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Cancels the sale, marking it as inactive.
    /// </summary>
    public void CancelSale()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Calculates the total amount for the sale based on the active items.
    /// </summary>
    public void CalculateTotalAmount()
    {
        TotalAmount = Items.Where(item => !item.IsCancelled)
                           .Sum(item => item.TotalAmount);
    }

    /// <summary>
    /// Adds an item to the sale and recalculates the total amount.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        CalculateTotalAmount();
    }

    /// <summary>
    /// Cancels a specific item in the sale and recalculates the total amount.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to cancel.</param>
    public void CancelItem(Guid itemId)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            item.Cancel();
            CalculateTotalAmount();
        }
    }

    /// <summary>
    /// Validates the sale entity using the SaleValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed.
    /// - Errors: Collection of validation errors if any rules failed.
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail) e)            
        };
    }
}
