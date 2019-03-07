using DFSLibrary.Algorithms;
using DFSLibrary.Algorithms.Factories;
using GNB_EduardoMenaCiudad.ConfigurationRetriever;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Controllers
{
    [Route("api/exchange")]
    public class ConversionController :  BasicConversionController<ExchangeRate, Transaction, IBaseService<ExchangeRate>, IBaseService<Transaction>, IConfigurationGetter>, IConversionController
    {
        private readonly string _Currency; 
        private /*readonly*/ IDepthFirstSearch<ExchangeRate> _ConversionStrategy;
        private readonly IFactoryDFS<ExchangeRate> _FactoryDFS;

        public ConversionController(IBaseService<ExchangeRate> ServiceRates, IBaseService<Transaction> ServiceTransactions, IConfigurationGetter ConfigurationGetter, IFactoryDFS<ExchangeRate> FactoryDFS) : base(ServiceRates, ServiceTransactions, ConfigurationGetter)
        {
            _Currency = _ConfigurationGetter.GetValue(ControllerConfigurationKeys.CURRENCY);
            _FactoryDFS = FactoryDFS;
        }

        [HttpGet("{sku}")]
        public override async Task<IActionResult> Get(string sku)
        {
            if(sku == null)
            {
                return BadRequest("sku can't be null");
            }

            var rates = await GetRates();
            
            if(rates.Count() < 1)
            {
                return StatusCode(500, "There's no rates to calculate exchange");
            }

            _ConversionStrategy = _FactoryDFS.Create(rates);

            var transacs = await GetTransacs();

            var transacsBySku = transacs.Where(t => t.Sku.Equals(sku)).ToList();

            var exchangedTransacs = ConvertTransacs(transacsBySku);

            var total = exchangedTransacs.Sum(x => x.Amount);

            var response = new
            {
                Date = DateTime.Now,
                Sku = sku,
                Currency = _Currency,
                Total = total,
                Transactions = exchangedTransacs
            };

            return Ok(response);
        }

        private IEnumerable<Transaction> ConvertTransacs(IEnumerable<Transaction> transactions)
        {
            var convertedTransactions = new List<Transaction>();

            foreach (var transac in transactions)
            {
                if(!string.Equals(transac.Currency, _Currency))
                {
                    var exchangedAmount = CalculateConversion(transac.Currency, transac.Amount);
                    transac.Amount = ApplyBankersRounding(exchangedAmount);
                }

                convertedTransactions.Add(transac);
            }

            return convertedTransactions;
        }

        private decimal CalculateConversion(string fromCurrency, decimal amount)
        {
            return _ConversionStrategy.ConvertFrom(fromCurrency, amount, _Currency);
        }

        private decimal ApplyBankersRounding(decimal number)
        {
            return Math.Round(number, 2, MidpointRounding.ToEven);
        }
    }
}
