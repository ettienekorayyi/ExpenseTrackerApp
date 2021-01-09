using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain;
using ExpenseTracker.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence;
using ExpenseTracker.Persistence;

namespace ExpenseTracker.Application.Classes
{
    public class ExpensesRepository : IRepository
    {
        private ExpenseTrackerDbContext _context;
        
        public ExpensesRepository(ExpenseTrackerDbContext context) //ExpenseTrackerDbContext
        {
             _context = context;
        }
        public async Task<IEnumerable<Expense>> GetExpenses()
        {
            return await _context.Expenses.ToListAsync();
        }
        
    }
}