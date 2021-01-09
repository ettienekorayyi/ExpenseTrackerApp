using System.Security.Principal;
using System.Runtime.CompilerServices;
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
using ExpenseTracker.Application.Expenses;
using Newtonsoft.Json;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class DetailsTests
    {
        private DbContextOptions<ExpenseTrackerDbContext> _options;
        private Details.Query _query;
        private Details.Handler _detailsHandler;
        private IMapper _mapper;
        private ExpenseDTO _expenseDto;

        public DetailsTests()
        {
            // Arrange            
            _options = Helper.CreateOptions<ExpenseTrackerDbContext>();
            _query = new Details.Query();

            var profile = new MappingProfile();
            var configuration = new MapperConfiguration(c => c.AddProfile(profile));
            _mapper = new Mapper(configuration);

            _expenseDto = new ExpenseDTO
            {
                Id = new Guid("d9d10414-f86a-4bba-929e-237e1f890e26"),
                Description = "Dined in at Tanomi",
                Category = "Leisure",
                Date = DateTime.Now,
                Shop = "Tanomi Lidcombe",
                Quantity = 2,
                Amount = 15
            };
        }

        [Fact]
        public void DetailsHandler_GetRecord_GetExpenseDetails()
        {
            var token = new CancellationTokenSource().Token;
            _query.Id = new Guid("d9d10414-f86a-4bba-929e-237e1f890e26");

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                SeedTest.SeedData(context);

                _detailsHandler = new Details.Handler(context, _mapper);

                var query = _detailsHandler.Handle(_query, token).Result;
                var actual = query;
                var expected = _expenseDto;

                Assert.Equal(expected.Id, actual.Id);
            }
        }

        [Fact]
        public void ListHandler_NullQuery_ShouldThrowArgumentNullException()
        {
            var token = new CancellationTokenSource().Token;
            _query.Id = new Guid("d9d10414-f86a-4bba-929e-237e1f890e26");
            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _detailsHandler = new Details.Handler(context, _mapper);

                var action = _detailsHandler.Handle(_query, token);
                
                Assert.ThrowsAsync<ArgumentNullException>(() => action);
            }
        }

    }
}