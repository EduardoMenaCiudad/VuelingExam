using DFSLibrary.Algorithms.Factories;
using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public abstract class BasicConversionController<Rate, Transac, RService, TService, ConfGetter> : ControllerBase
        where Transac : class
        where Rate : class
        where RService : IBaseService<Rate>
        where TService : IBaseService<Transac>
        where ConfGetter : IConfigurationGetter
    {
        protected readonly IBaseService<Rate> _ServiceRates;
        protected readonly IBaseService<Transac> _ServiceTransactions;
        protected readonly IFactoryDFS<Rate> _AlgorithmFactory;
        protected readonly IConfigurationGetter _ConfigurationGetter;

        protected BasicConversionController(RService ServiceRates, TService ServiceTransactions, ConfGetter ConfigurationGetter)
        {
            _ServiceRates = ServiceRates;
            _ServiceTransactions = ServiceTransactions;
            _ConfigurationGetter = ConfigurationGetter;
        }

        [HttpGet]
        public abstract Task<IActionResult> Get(string sku);
        
        

        protected async virtual Task<IEnumerable<Rate>> GetRates()
        {
            var rates = await _ServiceRates.GetAsync();
            return rates; 
        } 

        protected async virtual Task<IEnumerable<Transac>> GetTransacs()
        {
            var transactions = await _ServiceTransactions.GetAsync();
            return transactions;
        }


    }
}
