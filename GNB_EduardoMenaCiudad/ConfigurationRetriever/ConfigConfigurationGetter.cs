using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace GNB_EduardoMenaCiudad.ConfigurationRetriever
{
    public class ConfigConfigurationGetter : IConfigurationGetter
    {
        private readonly IConfiguration _Configuration;

        public ConfigConfigurationGetter(IConfiguration Configuration)
        {
            _Configuration = Configuration;
        }

        public string GetConnectionString(string key)
        {
            return _Configuration.GetConnectionString(key); 
        }

        public string GetValue(string key)
        {
            return _Configuration.GetValue<string>(key);
        }

        public string GetCurrentPath()
        {
            return _Configuration.GetValue<string>(WebHostDefaults.ContentRootKey);
        }
    }
}
