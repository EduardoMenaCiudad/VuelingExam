using DFSLibrary.AdjacencyLists;
using DFSLibrary.AdjacencyLists.Factories;
using GNB_EduardoMenaCiudad.Entities;
using System.Collections.Generic;

namespace GNB_EduardoMenaCiudad.ExchangeAlgorithm.AdjacencyLists.Factories
{
    public class ExchangeRateAdjacencyListFactory : IAdjacencyListFactory<ExchangeRate>
    {
        public IAdjacencyList<ExchangeRate> CreateList(IEnumerable<ExchangeRate> list)
        {
            return new ExchangeRateAdjacencyList(list);
        }
    }
}
