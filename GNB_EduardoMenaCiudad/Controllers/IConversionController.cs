using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public interface IConversionController
    {
        Task<IActionResult> Get(string sku);
    }
}