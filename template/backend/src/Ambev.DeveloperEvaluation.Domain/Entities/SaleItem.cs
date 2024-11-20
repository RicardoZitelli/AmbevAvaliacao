using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sale, including product details, quantity, pricing, and discount rules.
/// </summary>
public class SaleItem : BaseEntity
{
    /// <summary>
    /// Gets the product name or identifier for the item.
    /// </summary>
    public string Product { get; set; } = string.Empty;

    /// <summary>
    /// Gets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the discount applied to the item.
    /// </summary>
    public decimal Discount { get; private set; }

    /// <summary>
    /// Gets the total amount for the item after applying the discount.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Indicates whether the item is cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// The unique identifier of the sale to which this item belongs.
    /// </summary>
    public Guid SaleId { get; set; }

    /// <summary>
    /// Applies discount rules to the item based on the quantity purchased.
    /// </summary>
    public void ApplyDiscount()
    {
        if (Quantity < 4)
        {
            Discount = 0;
        }
        else if (Quantity >= 4 && Quantity < 10)
        {
            Discount = Quantity * UnitPrice * 0.1m;
        }
        else if (Quantity >= 10 && Quantity <= 20)
        {
            Discount = Quantity * UnitPrice * 0.2m;
        }
        else
        {
            throw new InvalidOperationException("Cannot sell more than 20 identical items.");
        }

        TotalAmount = (Quantity * UnitPrice) - Discount;
    }

    /// <summary>
    /// Cancels the item, marking it as inactive.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Validates the sale item entity using the SaleItemValidator rules.
    /// </summary>
    /// <returns>
    /// A <see cref="ValidationResultDetail"/> containing:
    /// - IsValid: Indicates whether all validation rules passed.
    /// - Errors: Collection of validation errors if any rules failed.
    /// </returns>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);

        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(e => (ValidationErrorDetail)e)
        };
    }

}
