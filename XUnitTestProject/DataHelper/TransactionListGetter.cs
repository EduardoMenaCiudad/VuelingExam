using GNB_EduardoMenaCiudad.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace XUnitTestProject.DataHelper
{
    public static class TransactionListGetter
    {
        public static IEnumerable<Transaction> GetList()
        {
            var path = Environment.CurrentDirectory;
            var content = System.IO.File.ReadAllText(path + "\\Transactions.json");
            var list = JsonConvert.DeserializeObject<List<Transaction>>(content);

            return list;
        }
    }
}
