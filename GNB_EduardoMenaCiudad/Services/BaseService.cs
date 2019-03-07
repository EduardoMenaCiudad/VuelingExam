using GNB_EduardoMenaCiudad.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GNB_EduardoMenaCiudad.Services
{
    public abstract class BaseService <T> : IBaseService<T>
    {
        private readonly IRepository<T> _Repo;

        protected BaseService(IRepository<T> Repo)
        {
            _Repo = Repo;
        }

        public async virtual Task<IEnumerable<T>> GetAsync()
        {
            var result = await _Repo.GetAsync();

            return result;            
        }

        public async virtual Task<T> GetAsync(string id)
        {
            return await _Repo.GetAsync(id);
        }

        public async virtual Task SaveAsync(IEnumerable<T> toSave)
        {
            await _Repo.SaveAsync(toSave);
        }
    }
}
