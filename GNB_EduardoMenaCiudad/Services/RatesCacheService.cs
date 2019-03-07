using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;

namespace GNB_EduardoMenaCiudad.Services
{
    public class RatesCacheService : BaseService<ExchangeRate>, IBaseService<ExchangeRate>
    {
        public RatesCacheService(IRepository<ExchangeRate> Repo) : base(Repo)
        {
        }
    }
}
