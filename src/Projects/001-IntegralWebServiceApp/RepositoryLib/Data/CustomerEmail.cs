using System;
using System.Collections.Generic;

namespace Integral.CRM.Data.Repository.Entity;

public partial class CustomerEmail
{
    public int CustomerEmailId { get; set; }
    public int CustomerId { get; set; }
    public string? Email { get; set; }    
}
