using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>> GetAsync();
        Task<T> GetAsync(string id);
    }
}
