using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.FileReaders;
using GNB_EduardoMenaCiudad.Serializers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public class TransactionFileRepository : IRepository<Transaction>
    {
        private readonly ISerializer<IEnumerable<Transaction>, string> _Serializer;
        private readonly IFileReader _FileReader;
        private readonly IConfigurationGetter _Configuration;

        public TransactionFileRepository(ISerializer<IEnumerable<Transaction>, string> Serializer, IFileReader FileReader, IConfigurationGetter Configuration)
        {
            _Serializer = Serializer;
            _FileReader = FileReader;
            _Configuration = Configuration;
        }

        public async Task<IEnumerable<Transaction>> GetAsync()
        {
            var filePath = GetPath();
            var stringFile = await _FileReader.ReadFileAsync(filePath);

            var result = _Serializer.Serialize(stringFile);

            return result;
        }

        public async Task<Transaction> GetAsync(string id)
        {
            var result = await GetAsync();
            return result.FirstOrDefault(x => x.Sku == id); 
        }

        public async Task SaveAsync(IEnumerable<Transaction> toSave)
        {
            var filePath = GetPath();
            var serialized = _Serializer.Serialize(toSave);

            await _FileReader.WriteFileAsync(filePath, serialized);
        }

        private string GetPath()
        {
            var filePath = _Configuration.GetCurrentPath() + "\\Transactions.json";
            return filePath;
        }
    }
}
