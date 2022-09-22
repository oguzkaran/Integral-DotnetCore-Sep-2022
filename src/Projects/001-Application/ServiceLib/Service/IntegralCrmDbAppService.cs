
using Integral.CRM.Data.DAL;
using Integral.CRM.Data.Service.DTO;

using CSD.Util.Mappers;
using CSD.Util.Data.Repository;
using CSD.Util.Data.Service;
using Integral.CRM.Data.Repository.Entity;

namespace Integral.CRM.Data.Service;

public class IntegralCrmDbAppService
{
    private readonly IntegralCRMAppHelper m_integralCRMAppHelper;
    private readonly IMapper m_mapper;

    public IntegralCrmDbAppService(IntegralCRMAppHelper integralCRMAppHelper, IMapper mapper)
    {
        m_integralCRMAppHelper = integralCRMAppHelper;
        m_mapper = mapper;
    }

    public async Task<CustomerDTO> SaveCustomerAsync(CustomerDTO customer)
    {
        try
        {
            //...
            return m_mapper.Map<CustomerDTO, Customer>(await m_integralCRMAppHelper.SaveCustomerAsync(m_mapper.Map<Customer, CustomerDTO>(customer)));
        }
        catch (RepositoryException ex)
        {
            throw new DataServiceException("IntegralCrmDbAppService.SaveCustomerAsync", ex.InnerException);
        }
        catch (Exception ex) {
            throw new DataServiceException("IntegralCrmDbAppService.SaveCustomerAsync", ex);
        }
    }

    public Task<IEnumerable<CustomerDTO>> FindCustomerByNameAsync(string name)
    {
        throw new NotImplementedException("Not implemented yet");
    }

    public Task<IEnumerable<CustomerInfoDTO>> FindCustomerByNameContainsAsync(string text)
    {
        throw new NotImplementedException("Not implemented yet");
    }
}
