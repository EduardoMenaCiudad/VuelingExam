using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Services
{
    public interface IReadService<T>
    {
        Task<T> GetAsync(string id);
        Task<IEnumerable<T>> GetAsync();
    }
}
