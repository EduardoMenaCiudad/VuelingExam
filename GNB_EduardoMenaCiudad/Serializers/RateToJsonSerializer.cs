using GNB_EduardoMenaCiudad.Entities;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GNB_EduardoMenaCiudad.Serializers
{
    public class RateToJsonSerializer : ISerializer<IEnumerable<ExchangeRate>, string>
    {
        public string Serialize(IEnumerable<ExchangeRate> from)
        {
           if(from != null)
            {
                var result = JsonConvert.SerializeObject(from);
                return result;
            }

            return string.Empty; 
        }

        public IEnumerable<ExchangeRate> Serialize(string from)
        {
            if(from != null)
            {
                var result = JsonConvert.DeserializeObject<List<ExchangeRate>>(from);
                return result;
            }
            
            return default(List<ExchangeRate>);
        }
    }
}
