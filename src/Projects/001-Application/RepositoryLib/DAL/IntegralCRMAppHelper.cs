using CSD.Util.Data.Repository;
using Integral.CRM.Data.Repository;
using Integral.CRM.Data.Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static CSD.Util.Data.DatabaseUtil;

namespace Integral.CRM.Data.DAL;

public class IntegralCRMAppHelper
{
    private readonly ICustomerRepository m_customerRepository;
    //...

    public IntegralCRMAppHelper(ICustomerRepository customerRepository)
    {
        m_customerRepository = customerRepository;
    }

    public Task<Customer> SaveCustomerAsync(Customer customer)
        => SubscribeRepositoryAsync(() => m_customerRepository.SaveAsync(customer), "IntegralCRMAppHelper.SaveCustomerAsync");

    public Task<IEnumerable<Customer>> FindCustomerByNameAsync(string text) => SubscribeRepositoryAsync(() => m_customerRepository.FindByNameAsync(text), "IntegralCRMAppHelper.FindCustomerByNameAsync");

    public Task<IEnumerable<Customer>> FindCustomerByNameContainsAsync(string text) => SubscribeRepositoryAsync(() => m_customerRepository.FindByNameContainsAsync(text), "IntegralCRMAppHelper.FindCustomerByNameContainsAsync");    
        
}
