using DFSLibrary;
using DFSLibrary.AdjacencyLists.Factories;
using DFSLibrary.Algorithms;
using DFSLibrary.Algorithms.Factories;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.ExchangeAlgorithm.AdjacencyLists.Factories;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProject.DataHelper;

namespace XUnitTestProject.AlgorithmStrategy
{
    public class DfsShould
    {
        [Fact]
        public void CalculateExchange()
        {
            var dfs = PrepareMock();

            var result = dfs.ConvertFrom("CAD", 1, "EUR");
            var rounded = Math.Round(result, 2, MidpointRounding.ToEven);

            Assert.NotEqual(0, result);
            Assert.Equal((decimal) 0.95, rounded);
        }

        [Fact]
        public void CalculateExchangeMissingCurrency()
        {
            var dfs = PrepareMock();

            Assert.Throws<NotFoundCurrencyException>(() => dfs.ConvertFrom("RAD", 1, "EUR"));
        }

        private IDepthFirstSearch<ExchangeRate> PrepareMock()
        {
            IAdjacencyListFactory<ExchangeRate> listFactory = new ExchangeRateAdjacencyListFactory();
            var rateList = ExchangeRateListGetter.GetList();

            IFactoryDFS<ExchangeRate> dfsFactory = new FactoryExchangeRateDFS(listFactory);
            return dfsFactory.Create(rateList);
        }
    }
}
