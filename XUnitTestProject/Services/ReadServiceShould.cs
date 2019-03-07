using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Newtonsoft.Json;
using GNB_EduardoMenaCiudad.Services;
using System;
using XUnitTestProject.DataHelper;

namespace XUnitTestProject.Services
{
    public class ReadServiceShould
    {
        [Fact]
        public async void GetAsync_Ok()
        {
            var service = PrepareMock();

            var result = await service.GetAsync();

            Assert.Equal(ExchangeRateListGetter.GetList().Count(), result.Count());
        }

        [Fact]
        public void GetAsyncId_Ok()
        {
            var service = PrepareMock();

            Assert.ThrowsAsync<NotImplementedException>(() => service.GetAsync("id")); 
        }

        private IReadService<ExchangeRate> PrepareMock()
        {
            var mockRepository = new Mock<IRepository<ExchangeRate>>();
            mockRepository.Setup(rep => rep.GetAsync()).ReturnsAsync(ExchangeRateListGetter.GetList());
            mockRepository.Setup(rep => rep.GetAsync("id")).ReturnsAsync(ExchangeRateListGetter.GetList().FirstOrDefault());

            IReadService<ExchangeRate> service = new RatesCacheService(mockRepository.Object);

            return service;
        }
    }
}
