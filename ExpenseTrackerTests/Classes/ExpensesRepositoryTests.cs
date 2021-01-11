using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using Application.Expenses;
using AutoMapper;
using Domain;
using ExpenseTracker.API.Common;
using ExpenseTracker.Application.Classes;
using ExpenseTracker.Application.Interfaces;
using ExpenseTracker.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class ExpensesRepositoryTests
    {
        private Mock<IRepository> _mockRepository;

        private Mock<IMapper> _mockMapper;
        private DbContextOptions<ExpenseTrackerDbContext> _options;
        
        private IEnumerable<Expense> _expected;
        private Expense _expense;
        private IRepository _expensesRepository;

        public ExpensesRepositoryTests()
        {
            // Arrange
            _mockRepository = new Mock<IRepository>();
            _mockMapper = new Mock<IMapper>();

            _options = Helper.CreateOptions<ExpenseTrackerDbContext>();
            
            _expense = new Expense
            {
                Description = "Description Test",
                Category = "Category Test",
                Shop = "Shop Test",
                Quantity = 1,
                Amount = 100,
                Date = DateTime.Now
            };
            _expected = new List<Expense>
                {
                    new Expense {
                        Id = Guid.NewGuid(),
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
                        Id = Guid.NewGuid(),
                        Description = "Booked a room for our Anniversary",
                        Category = "Holiday",
                        Date = DateTime.Now,
                        Shop = "Meriton Chatswood",
                        Quantity = 2,
                        Amount = 300
                    }
                };
        }

        [Fact]
        public void GetExpenses_WhenCalled_ShouldReturnFiveResults()
        {
            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);
                
                _expensesRepository = new ExpensesRepository(context);
                var actual = _expensesRepository.GetExpenses();
                
                Assert.Equal(_expected.Count(), actual.Result.Count());
            }
        }

    }
}