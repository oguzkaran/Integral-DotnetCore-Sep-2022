using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CSD.Data.Repository;
using Integral.CRM.Data.Repository.Entity;

namespace Integral.CRM.Data.Repository;

public interface ICustomerRepository : ICrudRepositoryAsync<Customer, int>
{
    Task<IEnumerable<Customer>> FindByNameContainsAsync(string text);
    Task<IEnumerable<Customer>> FindByNameAsync(string name);
}
