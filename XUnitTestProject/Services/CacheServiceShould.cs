using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;
using GNB_EduardoMenaCiudad.Services;
using Moq;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using System.Linq;
using XUnitTestProject.DataHelper;

namespace XUnitTestProject.Services
{
    public class CacheServiceShould
    {
        [Fact]
        public async void GetAsync_Ok()
        {
            BaseService<ExchangeRate> service = PrepareMock();

            var list = ExchangeRateListGetter.GetList();
            var retrievedList = await service.GetAsync();

            Assert.Equal(list.Count(), retrievedList.Count());
        }

        [Fact]
        public async void GetAsyncId_Fail()
        {
            BaseService<ExchangeRate> service = PrepareMock();

            var list = ExchangeRateListGetter.GetList();
            var retrievedList = await service.GetAsync();

            await Assert.ThrowsAsync<NotImplementedException>(() => service.GetAsync("id"));
        }

        [Fact]
        public async void SaveAsync()
        {
            BaseService<ExchangeRate> service = PrepareMock();

            var list = ExchangeRateListGetter.GetList();

            await service.SaveAsync(list);
        }

        private BaseService<ExchangeRate> PrepareMock()
        {
            var list = ExchangeRateListGetter.GetList();

            var mockRepository = new Mock<IRepository<ExchangeRate>>(MockBehavior.Loose);
            mockRepository.Setup(repo => repo.GetAsync()).ReturnsAsync(list);
            mockRepository.Setup(repo => repo.GetAsync("id")).ThrowsAsync(new NotImplementedException());
            mockRepository.Setup(repo => repo.SaveAsync(list));

            BaseService<ExchangeRate> cacheService = new RatesCacheService(mockRepository.Object);

            return cacheService;
        }

    }
}
