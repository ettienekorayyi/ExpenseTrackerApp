using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace Persistence
{
    public class Seed
    {
        public static void SeedData(ExpenseTrackerDbContext context)
        {
            if (!context.Expenses.Any())
            {
                var expenses = new List<Expense>
                {
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Dined in at Tanomi",
                        Category = "Leisure",
                        Date = DateTime.Now,
                        Shop = "",
                        Amount = 15
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Topped up Opal card",
                        Category = "Transport",
                        Date = DateTime.Now,
                        Shop = "Lidcombe Station",
                        Amount = 20
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Purchased Milk Tea",
                        Category = "Food and Drink",
                        Date = DateTime.Now,
                        Shop = "T.Come",
                        Amount = 12
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Purchased Vodafone credit",
                        Category = "Load",
                        Date = DateTime.Now,
                        Shop = "Lidcombe Station",
                        Amount = 35
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Booked a room for our Anniversary",
                        Category = "Holiday",
                        Date = DateTime.Now,
                        Shop = "Lidcombe Station",
                        Amount = 35
                    }
                };
                context.Expenses.AddRange(expenses);
                context.SaveChangesAsync();
            }
        }
    }
}