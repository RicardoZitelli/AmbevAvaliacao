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
    public List<SaleItem> Items { get; set; } = [];

    /// <summary>
    /// Gets the date and time when the sale was created.
    /// </summary>
    public DateTime CreatedAt { get; private set; }

    /// <summary>
    /// Gets the user who created the sale.
    /// </summary>
    public string CreatedBy { get; private set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the sale was last updated.
    /// </summary>
    public DateTime? UpdatedAt { get; private set; }

    /// <summary>
    /// Gets or sets the user who last updated the sale.
    /// </summary>
    public string? UpdatedBy { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Sale class and sets the creation metadata.
    /// </summary>
    /// <param name="createdBy">The user who created the sale.</param>
    public Sale(string createdBy)
    {
        SaleDate = DateTime.UtcNow;
        CreatedAt = DateTime.UtcNow;
        CreatedBy = !string.IsNullOrWhiteSpace(createdBy) ? createdBy : throw new ArgumentNullException(nameof(createdBy), "CreatedBy cannot be null or empty.");
    }

    /// <summary>
    /// Updates the sale metadata.
    /// </summary>
    /// <param name="updatedBy">The user who updated the sale.</param>
    public void UpdateSale(string updatedBy)
    {
        UpdatedAt = DateTime.UtcNow;
        UpdatedBy = !string.IsNullOrWhiteSpace(updatedBy) ? updatedBy : throw new ArgumentNullException(nameof(updatedBy), "UpdatedBy cannot be null or empty.");
    }

    /// <summary>
    /// Cancels the sale, marking it as inactive.
    /// </summary>
    public void CancelSale(string updatedBy)
    {
        IsCancelled = true;
        UpdateSale(updatedBy);
    }

    /// <summary>
    /// Calculates the total amount for the sale based on the active items.
    /// Ensures that each item's discount and total are recalculated before summing.
    /// </summary>
    public void CalculateTotalAmount()
    {
        Items.ForEach(x => x.ApplyDiscount());        
        TotalAmount = Items.Where(item => !item.IsCancelled)
                           .Sum(item => item.TotalAmount);
    }

    /// <summary>
    /// Adds an item to the sale and recalculates the total amount.
    /// </summary>
    /// <param name="item">The item to add.</param>
    public void AddItem(SaleItem item, string updatedBy)
    {
        Items.Add(item);
        CalculateTotalAmount();
        UpdateSale(updatedBy);
    }

    /// <summary>
    /// Cancels a specific item in the sale and recalculates the total amount.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to cancel.</param>
    public void CancelItem(Guid itemId, string updatedBy)
    {
        var item = Items.FirstOrDefault(i => i.Id == itemId);
        if (item != null)
        {
            item.Cancel();
            CalculateTotalAmount();
            UpdateSale(updatedBy);
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
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }
}
