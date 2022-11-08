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
    private readonly ICustomerInfoRepository m_customerInfoRepository;
    //...

    public IntegralCRMAppHelper(ICustomerRepository customerRepository, ICustomerInfoRepository customerInfoRepository)
    {
        m_customerRepository = customerRepository;
        m_customerInfoRepository = customerInfoRepository;
    }

    public Task<Customer> SaveCustomerAsync(Customer customer)
        => SubscribeRepositoryAsync(() => m_customerRepository.SaveAsync(customer), "IntegralCRMAppHelper.SaveCustomerAsync");

    public Task DeleteCustomerByKeyAsync(int id) => SubscribeRepositoryAsync(() => m_customerRepository.DeleteByKeyAsync(id), "IntegralCRMAppHelper.DeleteCustomerByKeyAsync");

    public Task DeleteAllCustomer() => SubscribeRepositoryAsync(() => m_customerRepository.DeleteAll(), "IntegralCRMAppHelper.DeleteAllCustomer");

    public Task<IEnumerable<Customer>> FindCustomerByNameAsync(string name) => SubscribeRepositoryAsync(() => m_customerRepository.FindByNameAsync(name), "IntegralCRMAppHelper.FindCustomerByNameAsync");

    public Task<IEnumerable<CustomerInfo>> FindCustomerInfoByNameAsync(string name) => SubscribeRepositoryAsync(() => m_customerInfoRepository.FindByNameAsync(name), "IntegralCRMAppHelper.FindCustomerInfoByNameAsync");

    public Task<IEnumerable<Customer>> FindCustomerByNameContainsAsync(string text) => SubscribeRepositoryAsync(() => m_customerRepository.FindByNameContainsAsync(text), "IntegralCRMAppHelper.FindCustomerByNameContainsAsync");        
}
