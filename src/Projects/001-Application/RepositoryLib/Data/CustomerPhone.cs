using System;
using System.Collections.Generic;

namespace Integral.CRM.Data.Repository.Entity;

public partial class CustomerPhone
{
    public int CustomerPhoneId { get; set; }
    public int CustomerId { get; set; }
    public string? Phone { get; set; }    
}
