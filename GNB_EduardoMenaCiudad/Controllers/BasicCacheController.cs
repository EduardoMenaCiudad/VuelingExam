using System.Collections.Generic;
using System.Threading.Tasks;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public abstract class BasicCacheController<T, TService, ZService> : ControllerBase, IReadController<T> where T : class 
        where TService : IReadService<T>
        where ZService : IBaseService<T>
    {
        private readonly IReadService<T> _Service;
        private readonly IBaseService<T> _LocalService;

        public BasicCacheController(IReadService<T> Service, IBaseService<T> localService) 
        {
            _Service = Service; 
            _LocalService = localService;
        }

        [HttpGet]
        public virtual async Task<IActionResult> Get()
        {
            var result = await GetContent();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public abstract Task<IActionResult> Get(string id);


        protected virtual async Task<IEnumerable<T>> GetContent()
        {
            var remoteResult = await _Service.GetAsync();

            if (remoteResult != null)
            {
                await _LocalService.SaveAsync(remoteResult);
                return remoteResult;
            }

            var localResult = await _LocalService.GetAsync();
            return localResult;
        }

    }
}
