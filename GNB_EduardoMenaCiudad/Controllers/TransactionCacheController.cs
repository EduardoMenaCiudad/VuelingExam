using System.Threading.Tasks;
using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace GNB_EduardoMenaCiudad.Controllers
{
    [Route("api/transactions")]
    public class TransactionCacheController : BasicCacheController<Transaction, TransactionService, TransactionCacheService>
    {
        public TransactionCacheController(IReadService<Transaction> Service, IBaseService<Transaction> localService) : base(Service, localService)
        {
        }

        public async override Task<IActionResult> Get(string id)
        {
            var result = await GetContent();

            var retrieved = result.FirstOrDefault(x => x.Sku.Equals(id));

            if(retrieved == null)
            {
                return NotFound();
            }

            return Ok(retrieved);

        }
    }
}
