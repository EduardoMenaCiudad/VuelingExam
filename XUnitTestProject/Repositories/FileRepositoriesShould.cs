using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.FileReaders;
using GNB_EduardoMenaCiudad.Repositories;
using GNB_EduardoMenaCiudad.Serializers;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;
using System.Linq;
using XUnitTestProject.DataHelper;
using System;

namespace XUnitTestProject.Repositories
{
    public class FileRepositoriesShould
    {
        [Fact]
        public async void GetListOfRates()
        {

            var repo = PrepareReadMock();
            var result = await repo.GetAsync();
            

            Assert.NotNull(result);
            Assert.Equal(6, result.Count());
        }

        [Fact]
        public void SaveFile_Ok()
        {
            var repo = PrepareWriteMock();

            var path = Environment.CurrentDirectory;
            var content = System.IO.File.ReadAllText(path + "\\Rates.json");
            var list = ExchangeRateListGetter.GetList();

            repo.SaveAsync(list);

            var retrievedContet = System.IO.File.ReadAllText(path + "\\Rates.json");

            Assert.Equal(content, retrievedContet);
        }

        private IRepository<ExchangeRate> PrepareReadMock()
        {
            var mockSerializer = new Mock<ISerializer<IEnumerable<ExchangeRate>, string>>(MockBehavior.Strict);
            var mockFileReader = new Mock<IFileReader>(MockBehavior.Strict);

            var mockConfGetter = new Mock<IConfigurationGetter>(MockBehavior.Strict);

            var path = Environment.CurrentDirectory;
            var content = System.IO.File.ReadAllText(path + "\\Rates.json");
            var list = ExchangeRateListGetter.GetList();

            mockConfGetter.Setup(conf => conf.GetCurrentPath()).Returns(path);
            mockFileReader.Setup(fr => fr.ReadFileAsync(path + "\\Rates.json")).Returns(Task.FromResult(content));

            mockSerializer.Setup(ser => ser.Serialize(content)).Returns(list);

            IRepository<ExchangeRate> repo = new ExchangeRateFileRepository(mockSerializer.Object, mockFileReader.Object, mockConfGetter.Object);

            return repo;
        }

        private IRepository<ExchangeRate> PrepareWriteMock()
        {
            var mockSerializer = new Mock<ISerializer<IEnumerable<ExchangeRate>, string>>(MockBehavior.Strict);

            var mockConfGetter = new Mock<IConfigurationGetter>(MockBehavior.Strict);

            var path = Environment.CurrentDirectory;
            var content = System.IO.File.ReadAllText(path + "\\Rates.json");
            var list = ExchangeRateListGetter.GetList();

            mockConfGetter.Setup(conf => conf.GetCurrentPath()).Returns(path);
            

            mockSerializer.Setup(ser => ser.Serialize(content)).Returns(list);

            IRepository<ExchangeRate> repo = new ExchangeRateFileRepository(mockSerializer.Object, new GNB_EduardoMenaCiudad.FileReaders.FileReader(), mockConfGetter.Object);

            return repo;
        }


    }
}
