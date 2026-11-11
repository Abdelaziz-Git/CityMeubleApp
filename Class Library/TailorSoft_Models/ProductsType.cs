using System;
using System.Collections.Generic;

namespace TailorSoft_Models;

public partial class ProductsType
{
    public byte Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
