using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public interface IReadController<T>
    {
        Task<IActionResult> Get();
        Task<IActionResult> Get(string id);
    }
}