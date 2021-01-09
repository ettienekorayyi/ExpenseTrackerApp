using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Persistence;

namespace Persistence
{
    public class SeedTest
    {
        public static void SeedData(ExpenseTrackerDbContext context)
        {
            if (!context.Expenses.Any())
            {
                var expenses = new List<Expense>
                {
                    new Expense {
                        Id = new Guid("d9d10414-f86a-4bba-929e-237e1f890e26"),
                        Description = "Dined in at Tanomi",
                        Category = "Leisure",
                        Date = DateTime.Now,
                        Shop = "Tanomi Lidcombe",
                        Quantity = 2,
                        Amount = 15
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Topped up Opal card",
                        Category = "Transport",
                        Date = DateTime.Now,
                        Shop = "Lidcombe Station",
                        Quantity = 2,
                        Amount = 20
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Purchased Milk Tea",
                        Category = "Food and Drink",
                        Date = DateTime.Now,
                        Shop = "T.Come",
                        Quantity = 2,
                        Amount = 12
                    },
                    new Expense {
                        Id = Guid.NewGuid(),
                        Description = "Purchased Vodafone credit",
                        Category = "Load",
                        Date = DateTime.Now,
                        Shop = "Lidcombe Station",
                        Quantity = 1,
                        Amount = 35
                    },
                    new Expense {
                        Id = new Guid("fc0d6a3f-1a7e-4c5a-aa2f-2d952c4c8712"),
                        Description = "Booked a room for our Anniversary",
                        Category = "Holiday",
                        Date = DateTime.Now,
                        Shop = "Meriton Chatswood",
                        Quantity = 2,
                        Amount = 300
                    },
                    new Expense {
                        Id = new Guid("359c4f66-22f3-45ff-baf4-a33c3fa11a82"),
                        Description = "Purchased Google Nest Hub",
                        Category = "Leisure",
                        Date = DateTime.Now,
                        Shop = "JB Hifi",
                        Quantity = 79,
                        Amount = 300
                    }
                };
                context.Expenses.AddRange(expenses);
                context.SaveChangesAsync();
            }
        }
    }
}