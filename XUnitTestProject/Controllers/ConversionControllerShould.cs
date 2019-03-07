using DFSLibrary.AdjacencyLists.Factories;
using DFSLibrary.Algorithms.Factories;
using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Controllers;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.ExchangeAlgorithm.AdjacencyLists.Factories;
using GNB_EduardoMenaCiudad.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using XUnitTestProject.DataHelper;

namespace XUnitTestProject.Controllers
{
    public class ConversionControllerShould
    {
        
        public void GetExchangedRates()
        {

        }

        private void PrepareMock()
        {
            IFactoryDFS<ExchangeRate> factory = PrepareFactory();
            IBaseService<ExchangeRate> serviceRate = PrepareMockBaseExchangeRateWorks();
            IBaseService<Transaction> ServiceTransac = PrepareMockBaseTransactionWorks();
            IConfigurationGetter config = PrepareMockConfig();

            //IConversionController controller = new ConversionController(serviceRate, ServiceTransac,  config, factory);
        }

        private IFactoryDFS<ExchangeRate> PrepareFactory()
        {
            IAdjacencyListFactory<ExchangeRate> listFactory = new ExchangeRateAdjacencyListFactory();
            var rateList = ExchangeRateListGetter.GetList();

            return new FactoryExchangeRateDFS(listFactory);
        }

        private void PrepareMockRemoteExchangeRateWorks()
        {
            var mockService = new Mock<IReadService<ExchangeRate>>();
            mockService.Setup(serv => serv.GetAsync()).ReturnsAsync(ExchangeRateListGetter.GetList());
            var mockCacheService = new Mock<IBaseService<ExchangeRate>>();

            BasicCacheController<ExchangeRate, RatesService, RatesCacheService> controller = new RatesCacheController(mockService.Object, mockCacheService.Object);
        }

        private IBaseService<ExchangeRate> PrepareMockBaseExchangeRateWorks()
        {
            var mock = new Mock<IBaseService<ExchangeRate>>();
            mock.Setup(s => s.GetAsync()).ReturnsAsync(ExchangeRateListGetter.GetList());
            return mock.Object;
        }

        private IBaseService<Transaction>  PrepareMockBaseTransactionWorks()
        {
            var mock = new Mock<IBaseService<Transaction>>();
            mock.Setup(s => s.GetAsync()).ReturnsAsync(TransactionListGetter.GetList());
            return mock.Object;
        }

        private IConfigurationGetter PrepareMockConfig()
        {
            var mock = new Mock<IConfigurationGetter>();
            mock.Setup(c => c.GetValue("")).Returns("");
            return mock.Object;
        }
    }
}
