using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Repositories
{
    public interface IWriteRepository <T>
    {
        Task SaveAsync(IEnumerable<T> toSave);
    }
}
