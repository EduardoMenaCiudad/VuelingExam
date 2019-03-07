using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Repositories;

namespace GNB_EduardoMenaCiudad.Services
{
    public class TransactionService : BaseReadService<Transaction>
    {
        public TransactionService(IReadRepository<Transaction> Repo) : base(Repo)
        {
        }
    }
}
