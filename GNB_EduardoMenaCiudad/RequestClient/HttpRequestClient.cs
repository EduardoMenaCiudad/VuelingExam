using System.Net.Http;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.RequestClient
{
    public class HttpRequestClient : IRequestClient
    {
        private readonly HttpClient _Client;

        public HttpRequestClient(HttpClient httpClient)
        {
            _Client = httpClient;
        }

        public async Task<string> GetAsync(string url)
        {
            var response = await _Client.GetStringAsync(url);

            return response;
        }
    }
}
