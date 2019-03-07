using GNB_EduardoMenaCiudad.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GNB_EduardoMenaCiudad.Serializers
{
    public class TransactionToJsonSerializer : ISerializer<IEnumerable<Transaction>, string>
    {
        public string Serialize(IEnumerable<Transaction> from)
        {
            return JsonConvert.SerializeObject(from);
        }

        public IEnumerable<Transaction> Serialize(string from)
        {
            return JsonConvert.DeserializeObject<List<Transaction>>(from);
        }
    }
}
