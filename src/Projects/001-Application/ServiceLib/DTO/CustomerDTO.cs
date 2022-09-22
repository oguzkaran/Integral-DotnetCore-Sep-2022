using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integral.CRM.Data.Service.DTO;

public class CustomerDTO
{
    public string? CustomerName { get; set; }
    public string CustomerAddress { get; set; } = null!;
}
