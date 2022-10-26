using Integral.CRM.Data.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using CSD.Util.Data.Repository.Extensions;

using static CSD.Util.Async.TaskUtil;

namespace Integral.CRM.Data.Repository;

class CustomerInfoRepository : ICustomerInfoRepository
{
    private readonly IntegralCrmdbContext m_context;

    #region callback methods
    private IEnumerable<CustomerInfo> findCustomerInfoByNameCallback(string name) 
        => m_context.LoadProcedure("sp_get_customerinfo_by_name").SetParameters(("@name", name)).ExecuteProcedure<CustomerInfo>();    

    #endregion

    public CustomerInfoRepository(IntegralCrmdbContext context)
    {
        m_context = context;
    }

    #region implemented methods
    public Task<IEnumerable<CustomerInfo>> FindByNameAsync(string name) => CreateTaskAsync(() => findCustomerInfoByNameCallback(name));   

    #endregion
    
}
