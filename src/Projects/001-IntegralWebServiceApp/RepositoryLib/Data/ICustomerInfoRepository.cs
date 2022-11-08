
using CSD.Data.Repository;
using Integral.CRM.Data.Repository.Entity;

namespace Integral.CRM.Data.Repository;

public interface ICustomerInfoRepository
{    
    Task<IEnumerable<CustomerInfo>> FindByNameAsync(string name);
}
