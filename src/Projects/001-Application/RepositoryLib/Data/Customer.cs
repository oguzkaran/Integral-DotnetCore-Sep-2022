using System;
using System.Collections.Generic;

namespace Integral.CRM.Data.Repository.Entity;

public partial class Customer
{
    public int CustomerId { get; set; }
    public string? CustomerName { get; set; }
    public string? CustomerAddress { get; set; }
    public DateTime RegistrationDate { get; set; }
    public bool IsActive { get; set; }
}
