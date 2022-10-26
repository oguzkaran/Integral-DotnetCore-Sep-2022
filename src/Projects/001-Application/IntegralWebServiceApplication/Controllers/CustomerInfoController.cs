using Microsoft.AspNetCore.Mvc;

using Integral.CRM.Data.Service;
using Integral.CRM.Data.Service.DTO;

namespace IntegralWebServiceApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerInfoController : ControllerBase
{
    private readonly IntegralCrmDbAppService m_service;
    private readonly ILogger<CustomerController> m_logger;

    public CustomerInfoController(IntegralCrmDbAppService service, ILogger<CustomerController> logger)
    {
        m_service = service;
        m_logger = logger;
    }

    [HttpGet("find/name")]
    public async Task<IEnumerable<CustomerInfoDTO>> FindsByNameAsync(string name)
    {
        return await m_service.FindCustomerInfoByNameAsync(name);
    }    
}