using Microsoft.AspNetCore.Mvc;

using Integral.CRM.Data.Service;
using Integral.CRM.Data.Service.DTO;
using CSD.Util.Data.Service;

using static CSD.Util.Error.ExceptionUtil;

namespace IntegralWebServiceApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IntegralCrmDbAppService m_service;
    private readonly ILogger<CustomerController> m_logger;    

    public CustomerController(IntegralCrmDbAppService service, ILogger<CustomerController> logger)
    {
        m_service = service;
        m_logger = logger;
    }

    [HttpGet("find/name")]
    public async Task<IActionResult> FindsByNameAsync(string name)
    {
        try
        {
            return new ObjectResult(await m_service.FindCustomerByNameAsync(name));
        }
        catch (DataServiceException ex) {
            return BadRequest(ex.Message);
        }
    }

    [HttpPost("save")]
    public async Task<IActionResult> SaveAsync([FromBody] CustomerDTO customerDTO)
    {
        try
        {
            return new ObjectResult(await m_service.SaveCustomerAsync(customerDTO));
        }
        catch (DataServiceException ex)
        {
            return BadRequest(ex.Message);
        }
    }   
}