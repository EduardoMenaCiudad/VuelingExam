using GNB_EduardoMenaCiudad.Entities;
using System;
using System.Collections.Generic;

namespace DFSLibrary.AdjacencyLists
{
    public class ExchangeRateAdjacencyList : IAdjacencyList<ExchangeRate>
    {
        public Dictionary<string, Dictionary<string, decimal>> _List { get; }
        private readonly IEnumerable<ExchangeRate> _Rates;

        public ExchangeRateAdjacencyList(IEnumerable<ExchangeRate> listToLoad)
        {
            _Rates = listToLoad ?? throw new ArgumentNullException(); 
            _List = new Dictionary<string, Dictionary<string, decimal>>();
            LoadRates();
        }

        public void LoadRates()
        {
            foreach (var rate in _Rates)
            {
                if (!IsInList(rate))
                {
                    _List.Add(rate.From, new Dictionary<string, decimal>() { { rate.To, rate.Rate } });
                }
                else
                {
                    _List.TryGetValue(rate.From, out Dictionary <string, decimal > dict);
                    dict.Add(rate.To, rate.Rate);
                }
            }
        }

        public bool IsInList(ExchangeRate toCheck)
        {
            return _List.ContainsKey(toCheck.From);
        }

        public Dictionary<string, decimal> GetAdjacentNodes(string key)
        {
            _List.TryGetValue(key, out Dictionary<string, decimal> result);
            return result;
        }
    }
}
