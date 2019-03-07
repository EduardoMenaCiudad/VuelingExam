using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public class RatesController : BasicController<ExchangeRate, RatesService> , IReadController<ExchangeRate>
    {
        public RatesController(IReadService<ExchangeRate> Service) : base(Service)
        {
        }

        public async override Task<IActionResult> Get(string id)
        {
            return await Task.FromResult<IActionResult>(BadRequest());
        }
    }
}
