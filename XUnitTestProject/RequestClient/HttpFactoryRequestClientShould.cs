using GNB_EduardoMenaCiudad.RequestClient;
using Moq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTestProject.RequestClient
{
    public class HttpFactoryRequestClientShould
    {
        [Fact]
        public void RetrieveString_Ok()
        {
            // Unable to mock HttpClient 
            // GetAsync is a non virtual method
        }
    }
}
