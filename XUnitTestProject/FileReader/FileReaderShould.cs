using GNB_EduardoMenaCiudad.FileReaders;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject.FileReader
{
    public class FileReaderShould
    {
        [Fact]
        public void ReadFromFile_Ok()
        {
            var validPath = Environment.CurrentDirectory + "\\Rates.json";

            IFileReader fileReader = new GNB_EduardoMenaCiudad.FileReaders.FileReader();
            var result = fileReader.ReadFileAsync(validPath);
           
        }

        [Fact]
        public void ReadFromFile_Fail()
        {
            var notExistentPath = "";

            IFileReader fileReader = new GNB_EduardoMenaCiudad.FileReaders.FileReader();
            
            Assert.ThrowsAsync<System.IO.FileNotFoundException>(() => fileReader.ReadFileAsync(notExistentPath));
        }

        [Fact]
        public async void WriteFile_Ok()
        {
            var validPath = "C:\\Users\\CTA\\Desktop\\GNB\\GNB_EduardoMenaCiudad\\GNB_EduardoMenaCiudad\\Rates.json";

            IFileReader fileReader = new GNB_EduardoMenaCiudad.FileReaders.FileReader();

            var content = System.IO.File.ReadAllText(validPath);

            await fileReader.WriteFileAsync(validPath, content);

            var retrievedContent = System.IO.File.ReadAllText(validPath);

            Assert.Equal(content, retrievedContent);
        }
    }
}
