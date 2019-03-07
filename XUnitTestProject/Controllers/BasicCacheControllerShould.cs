using GNB_EduardoMenaCiudad.Controllers;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using XUnitTestProject.DataHelper;

namespace XUnitTestProject.Controllers
{
    public class BasicCacheControllerShould
    {
        [Fact]
        public void GetAsync_Ok()
        {

        }

        [Fact]
        public void GetAsyncId_Fail()
        {

        }

        private void PrepareMockRemoteWorks()
        {
            var mockService = new Mock<IReadService<ExchangeRate>>();
            mockService.Setup(serv => serv.GetAsync()).ReturnsAsync(ExchangeRateListGetter.GetList());
            var mockCacheService = new Mock<IBaseService<ExchangeRate>>();
            
            BasicCacheController<ExchangeRate, RatesService, RatesCacheService> controller = new RatesCacheController(mockService.Object, mockCacheService.Object);
        }

        private void PrepareMockRemoteFails()
        {
            var mockService = new Mock<IReadService<ExchangeRate>>();
            //mockService.Setup(serv => serv.GetAsync()).ReturnsAsync(await Task.FromResult<>(null));
            var mockCacheService = new Mock<IBaseService<ExchangeRate>>();

            BasicCacheController<ExchangeRate, RatesService, RatesCacheService> controller = new RatesCacheController(mockService.Object, mockCacheService.Object);
        }
    }
}
