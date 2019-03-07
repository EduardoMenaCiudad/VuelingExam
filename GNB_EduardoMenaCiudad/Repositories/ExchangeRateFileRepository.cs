using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.FileReaders;
using GNB_EduardoMenaCiudad.Serializers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public class ExchangeRateFileRepository : IRepository<ExchangeRate>
    {
        private readonly ISerializer<IEnumerable<ExchangeRate>, string> _Serializer;
        private readonly IFileReader _FileReader;
        private readonly IConfigurationGetter _Configuration; 

        public ExchangeRateFileRepository(ISerializer<IEnumerable<ExchangeRate>,string> Serializer, IFileReader FileReader, IConfigurationGetter configuration)
        {
            _Serializer = Serializer;
            _FileReader = FileReader;
            _Configuration = configuration;
        }

        public Task<ExchangeRate> GetAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ExchangeRate>> GetAsync()
        {
            var filePath = GetPath();
            var stringFile = await _FileReader.ReadFileAsync(filePath);

            var result = _Serializer.Serialize(stringFile);

            return result;
        }

        public async Task SaveAsync(IEnumerable<ExchangeRate> toSave)
        {
            var filePath = GetPath();
            var serialized = _Serializer.Serialize(toSave);

            await _FileReader.WriteFileAsync(filePath, serialized);

        }

        private string GetPath()
        {
            _Configuration.GetCurrentPath();
            var filePath = _Configuration.GetCurrentPath() + "\\Rates.json";
            return filePath;
        }
    }
}
