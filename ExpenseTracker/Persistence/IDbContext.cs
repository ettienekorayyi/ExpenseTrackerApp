using Domain;
using Microsoft.EntityFrameworkCore;

namespace ExpenseTracker.Persistence
{
    public interface IDbContext
    {
        DbSet<Expense> Expenses { get; set; }
    }
}