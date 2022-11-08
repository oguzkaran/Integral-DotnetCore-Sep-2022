
using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Service.DTO;

using Integral.CRM.Data.Repository.Entity;
using CSD.Util.Mappers;

using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;

using static CSD.Util.Async.TaskUtil;

using static CSD.Util.Data.DatabaseUtil;

namespace Integral.CRM.Data.Service;

public class IntegralCrmDbAppService
{
    private readonly IntegralCRMAppHelper m_integralCRMAppHelper;
    private readonly IMapper m_mapper;

    private async Task<IEnumerable<CustomerDTO>> findCustomerByNameAsyncCallback(string name)
    {
        var customers = await m_integralCRMAppHelper.FindCustomerByNameAsync(name);
        var dtos = customers.Select(c => m_mapper.Map<CustomerDTO, Customer>(c));

        return await CreateTaskAsync(() => dtos);
    }

    private async Task<IEnumerable<CustomerInfoDTO>> findCustomerInfoByNameAsyncCallback(string name)
    {
        var customers = await m_integralCRMAppHelper.FindCustomerInfoByNameAsync(name);
        var dtos = customers.Select(c => m_mapper.Map<CustomerInfoDTO, CustomerInfo>(c));

        return await CreateTaskAsync(() => dtos);
    }

    public IntegralCrmDbAppService(IntegralCRMAppHelper integralCRMAppHelper, IMapper mapper)
    {
        m_integralCRMAppHelper = integralCRMAppHelper;
        m_mapper = mapper;
    }

    public async Task<CustomerDTO> SaveCustomerAsync(CustomerDTO customer) =>
        m_mapper.Map<CustomerDTO, Customer>(await SubscribeServiceAsync(() => m_integralCRMAppHelper.SaveCustomerAsync(m_mapper.Map<Customer, CustomerDTO>(customer)), "IntegralCrmDbAppService.SaveCustomerAsync"));

    public async Task<IEnumerable<CustomerDTO>> FindCustomerByNameAsync(string name) =>
        await SubscribeServiceAsync(() => findCustomerByNameAsyncCallback(name), "IntegralCrmDbAppService.FindCustomerByNameAsync");
    
    public async Task<IEnumerable<CustomerInfoDTO>> FindCustomerInfoByNameAsync(string name) =>
        await SubscribeServiceAsync(() => findCustomerInfoByNameAsyncCallback(name), "IntegralCrmDbAppService.FindCustomerByNameContainsAsync");

}
