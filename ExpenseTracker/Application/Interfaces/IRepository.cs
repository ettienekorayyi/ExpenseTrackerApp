using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;

namespace ExpenseTracker.Application.Interfaces
{
    public interface IRepository
    {
        Task<IEnumerable<Expense>> GetExpenses();
    }
}