using GNB_EduardoMenaCiudad.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XUnitTestProject.DataHelper
{
    public static class ExchangeRateListGetter
    {
        public static IEnumerable<ExchangeRate> GetList()
        {
            var path = Environment.CurrentDirectory;
            var content = System.IO.File.ReadAllText(path + "\\Rates.json");
            var list = JsonConvert.DeserializeObject<List<ExchangeRate>>(content);

            return list;
        }
    }
}
