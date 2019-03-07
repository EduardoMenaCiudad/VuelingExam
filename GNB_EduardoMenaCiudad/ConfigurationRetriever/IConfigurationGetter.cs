using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.ConfigurationRetriever
{
    public interface IConfigurationGetter
    {
        string GetConnectionString(string key);
        string GetValue(string key);
        string GetCurrentPath();
    }
}
