using System;
using Xunit;
using System.Linq;
using ExpenseTracker.API.Common;
using Persistence;
using Microsoft.EntityFrameworkCore;

namespace Controllers
{
    public class ExpensesControllerTests
    {
       [Fact]
       public void Get()
       {
            // Arrange
            var options = Helper.CreateOptions<ExpenseTrackerDbContext>();

            using(var context = new ExpenseTrackerDbContext(options))
            {
                // Act
                context.Database.EnsureCreated();
                Seed.SeedData(context);
                var expected = context.Expenses.Count();
                //var actual = 5;
                
                // Assert
                //Assert.Equal(expected, actual);
            } 
        }

    }
}
