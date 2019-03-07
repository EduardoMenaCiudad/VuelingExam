using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Services
{
    public interface IBaseService<T> : IReadService<T>
    {
        Task SaveAsync(IEnumerable<T> toSave);
    }
}