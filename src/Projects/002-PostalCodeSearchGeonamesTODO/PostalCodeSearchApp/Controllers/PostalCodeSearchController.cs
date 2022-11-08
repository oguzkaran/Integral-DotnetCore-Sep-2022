using CSD.PostalCodeApp.Geonames;
using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks;

namespace PostalCodeSearchApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostalCodeSearchController : ControllerBase
    {   
        private readonly ILogger<PostalCodeSearchController> m_logger;
        private readonly PostalCodeGeonamesClient m_postalCodeGeonamesClient;

        public PostalCodeSearchController(ILogger<PostalCodeSearchController> logger, PostalCodeGeonamesClient postalCodeGeonamesClient)
        {
            m_logger = logger;
            m_postalCodeGeonamesClient = postalCodeGeonamesClient;
        }

        [HttpGet(Name = "postalcode")]
        public async Task<IEnumerable<PostalCodeInfo>> FindPostalCode(int code)
        {
            return await m_postalCodeGeonamesClient.FindPostalCode(code);
        }
    }
}