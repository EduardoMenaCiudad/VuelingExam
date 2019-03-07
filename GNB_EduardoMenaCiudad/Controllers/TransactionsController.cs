using GNB_EduardoMenaCiudad.Entities;
using GNB_EduardoMenaCiudad.Services;
using Microsoft.AspNetCore.Mvc;

namespace GNB_EduardoMenaCiudad.Controllers
{
    public class TransactionsController : BasicController<Transaction, TransactionService>, IReadController<Transaction>
    {
        public TransactionsController(IReadService<Transaction> Service) : base(Service)
        {
        }
    }
}
