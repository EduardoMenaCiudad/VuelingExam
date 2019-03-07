using DFSLibrary.AdjacencyLists;
using DFSLibrary.AdjacencyLists.Factories;
using GNB_EduardoMenaCiudad.Entities;
using System.Collections.Generic;

namespace DFSLibrary.Algorithms.Factories
{
    public class FactoryExchangeRateDFS : IFactoryDFS<ExchangeRate>
    {
        private readonly IAdjacencyListFactory<ExchangeRate> _AdjacencyListFactory;

        public FactoryExchangeRateDFS(IAdjacencyListFactory<ExchangeRate> adjListFactory)
        {
            _AdjacencyListFactory = adjListFactory;
        }

        public IDepthFirstSearch<ExchangeRate> Create(IEnumerable<ExchangeRate> rates)
        {
            IAdjacencyList<ExchangeRate> adjlist = _AdjacencyListFactory.CreateList(rates);
            IDepthFirstSearch<ExchangeRate> DFS = new DepthFirstSearch(adjlist);

            return DFS;
        }
    }
}
