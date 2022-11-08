using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.String;
using static CSD.PostalCodeApp.Geonames.Global;

namespace CSD.PostalCodeApp.Geonames
{
    public class PostalCodeGeonamesClient
    {
        private readonly HttpClient m_httpClient;

        public PostalCodeGeonamesClient(HttpClient httpClient) => m_httpClient = httpClient;

        public async Task<IEnumerable<PostalCodeInfo>> FindPostalCode(int postalCode)
        {
            var response = await m_httpClient.GetStringAsync(Format(PostalCodeUrlTemplate, postalCode));
            var geo = JsonConvert.DeserializeObject<PostalCodesInfo>(response);

            return geo.PostalCodes;
        }
    }
}
