using System;
using System.Collections.Generic;

namespace TailorSoft_Models;

    public partial class Customer
{
    public int Id { get; set; }

    public int PersonId { get; set; }

    public DateTime CreatedDate { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
