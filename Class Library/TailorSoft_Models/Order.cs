using System;
using System.Collections.Generic;

namespace TailorSoft_Models;

public partial class Order
{
    public int Id { get; set; }

    public int CustomerId { get; set; }

    public int UserId { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime? DeliveryDate { get; set; }

    /// <summary>
    /// (0, &apos;Pending&apos;),
    /// (1, &apos;Measuring&apos;),
    /// (2, &apos;In Progress&apos;),
    /// (3, &apos;Ready for Delivery&apos;),
    /// (4, &apos;Delivered&apos;),
    /// (5, &apos;DeliveredAndPaid&apos;),
    /// (6, &apos;Cancelled&apos;);
    /// </summary>
    public byte Status { get; set; }

    public decimal TotalAmount { get; set; }

    public decimal InitialAmount { get; set; }

    public decimal RemainingAmount { get; set; }

    public DateTime? PaymentDate { get; set; }

    public string? Notes { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual User User { get; set; } = null!;
}
