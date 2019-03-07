using System.Net.Http;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.RequestClient
{
    public class HttpFactoryRequestClient : IRequestClient
    {
        private readonly IHttpClientFactory _ClientFactory;

        public HttpFactoryRequestClient(IHttpClientFactory ClientFactory)
        {
            _ClientFactory = ClientFactory;
        }

        public async Task<string> GetAsync(string url)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);

            var client = _ClientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }

            return string.Empty; 
        }
    }
}
