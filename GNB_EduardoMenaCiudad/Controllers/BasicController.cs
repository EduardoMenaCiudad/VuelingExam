using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public abstract class BasicController<T, TService> : ControllerBase, IReadController<T> where T : class
        where TService : IReadService<T>
    {
        protected readonly IReadService<T> _Service;

        protected BasicController(IReadService<T> Service)
        {
            _Service = Service;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var serviceResponse = await _Service.GetAsync();

            return Ok(serviceResponse);
        }

        [HttpGet("{id}")]
        public virtual async Task<IActionResult> Get(string id)
        {
            var serviceResponse = await _Service.GetAsync();

            if(serviceResponse == null)
            {
                return NotFound();
            }

            return Ok(serviceResponse);
        }
    }
}
