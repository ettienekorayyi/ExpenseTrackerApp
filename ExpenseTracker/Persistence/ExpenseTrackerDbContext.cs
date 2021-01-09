using System;
using Domain;
using ExpenseTracker.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

    }
}
