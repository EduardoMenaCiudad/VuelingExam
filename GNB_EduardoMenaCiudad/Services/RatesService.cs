using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;

namespace GNB_EduardoMenaCiudad.Services
{
    public class RatesService : BaseReadService<ExchangeRate>
    {
        public RatesService(IReadRepository<ExchangeRate> Repo) : base(Repo)
        {
        }
    }
}
