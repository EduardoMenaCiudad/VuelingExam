using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;

namespace GNB_EduardoMenaCiudad.Services
{
    public class TransactionCacheService : BaseService<Transaction>, IBaseService<Transaction>
    {
        public TransactionCacheService(IRepository<Transaction> Repo) : base(Repo)
        {
        }
    }
}
