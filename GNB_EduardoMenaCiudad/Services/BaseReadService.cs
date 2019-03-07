using GNB_EduardoMenaCiudad.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Services
{
    public abstract class BaseReadService<T> : IReadService<T>
    {
        protected IReadRepository<T> _ReadRepo;

        protected BaseReadService(IReadRepository<T> Repo)
        {
            _ReadRepo = Repo;
        }

        public async virtual Task<IEnumerable<T>> GetAsync()
        {
            var result = await _ReadRepo.GetAsync();

            if(result != null)
            {
                return result;
            }

            return result; 
        }

        public async virtual Task<T> GetAsync(string id)
        {
            return await _ReadRepo.GetAsync(id);
        }
    }
}
