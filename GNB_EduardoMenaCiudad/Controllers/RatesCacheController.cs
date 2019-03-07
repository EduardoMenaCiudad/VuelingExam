using System.Threading.Tasks;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNB_EduardoMenaCiudad.Controllers
{
    [Route("api/rates")]
    public class RatesCacheController : BasicCacheController<ExchangeRate, RatesService, RatesCacheService>
    {
        public RatesCacheController(IReadService<ExchangeRate> Service, IBaseService<ExchangeRate> localService) : base(Service, localService)
        {

        }

        public async override Task<IActionResult> Get(string id)
        {
            var response = await Task.FromResult(BadRequest());
            return response;
        }
    }
}
