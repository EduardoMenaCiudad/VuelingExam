using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.RequestClient;
using GNB_EduardoMenaCiudad.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public class TransactionRemoteRepository : IReadRepository<Transaction>
    {
        private readonly IRequestClient _Client;
        private readonly ISerializer<IEnumerable<Transaction>, string> _Serializer;
        private readonly IConfigurationGetter _ConfigGetter;

        public TransactionRemoteRepository(IRequestClient Client, IConfigurationGetter configGetter, ISerializer< IEnumerable<Transaction>, string> serializer)
        {
            _Client = Client;
            _ConfigGetter = configGetter;
            _Serializer = serializer;
        }

        public async Task<IEnumerable<Transaction>> GetAsync()
        {
            var url = _ConfigGetter.GetConnectionString(ConfigurationKeys.TRANSACTIONS);
            
            var response = await _Client.GetAsync(url);
            var serialized = _Serializer.Serialize(response);
            return serialized; 
        }

        public async Task<Transaction> GetAsync(string id)
        {
            var response = await GetAsync();

            return response.FirstOrDefault(x => x.Sku == id);
        }
    }
}
