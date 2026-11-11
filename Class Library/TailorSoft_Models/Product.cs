using System;
using System.Collections.Generic;

namespace TailorSoft_Models;

public partial class Product
{
    public int Id { get; set; }

    public byte TypeId { get; set; }

    public string Category { get; set; } = null!;

    public string Color { get; set; } = null!;

    public string Dimensions { get; set; } = null!;

    public int Quantity { get; set; }

    public double Price { get; set; }

    public string ImagePath { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public DateTime LastUpdate { get; set; }

    public int CreatedByUserId { get; set; }

    public bool IsActive { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

    public virtual ProductsType Type { get; set; } = null!;
}
