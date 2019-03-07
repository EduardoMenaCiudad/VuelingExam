using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.RequestClient;
using GNB_EduardoMenaCiudad.Serializers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public class ExchangeRateRemoteRepository : IReadRepository<ExchangeRate>
    {
        private readonly IRequestClient _Client;
        private readonly ISerializer<IEnumerable<ExchangeRate>, string> _Serializer;
        private readonly IConfigurationGetter _ConfigGetter;

        public ExchangeRateRemoteRepository(IRequestClient Client, IConfigurationGetter configGetter, ISerializer<IEnumerable<ExchangeRate>, string> serializer)
        {
            _Client = Client;
            _ConfigGetter = configGetter;
            _Serializer = serializer;
        }

        public async Task<IEnumerable<ExchangeRate>> GetAsync()
        {
            var url = _ConfigGetter.GetConnectionString(ConfigurationKeys.EXCHANGERATES);

            var response = await _Client.GetAsync(url);

            var serialized = _Serializer.Serialize(response);

            return serialized;
        }

        public Task<ExchangeRate> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
