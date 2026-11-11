using System;
using System.Collections.Generic;

namespace TailorSoft_Models;

public partial class User
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string? Email { get; set; }

    public string City { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Status { get; set; }

    public int Permissions { get; set; }

    public string? Address { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
