using System;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class ExpenseTrackerDbContext : DbContext
    {
        public ExpenseTrackerDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<TestValue> TestValues { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<TestValue>().HasData(
                new TestValue {
                    Id = Guid.NewGuid(),
                    Title = "Test Value 1",
                    Description = "Lorem ipsum dolor1"
                },
                 new TestValue {
                    Id = Guid.NewGuid(),
                    Title = "Test Value 2",
                    Description = "Lorem ipsum dolor2"
                },
                 new TestValue {
                    Id = Guid.NewGuid(),
                    Title = "Test Value 3",
                    Description = "Lorem ipsum dolor3"
                }
            );
        }
    }
}
