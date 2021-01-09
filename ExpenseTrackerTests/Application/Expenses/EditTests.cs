using System;
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
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;
using static Application.Expenses.Create;
using Newtonsoft.Json;
using Xunit.Abstractions;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class EditTests
    {
        private DbContextOptions<ExpenseTrackerDbContext> _options;
        private Edit.Handler _editHandler;
        private readonly IMapper _mapper;
        private Guid _id;
        private Edit.Command _editCommand;
        private ExpenseDTO _expenseDTO;
        public EditTests()
        {
            var profile = new MappingProfile(); //
            var configuration = new MapperConfiguration(c => c.AddProfile(profile));
            _mapper = new Mapper(configuration); //

            _options = Helper.CreateOptions<ExpenseTrackerDbContext>();

            _expenseDTO = new ExpenseDTO
            {
                Description = "Booked a room for our Anniversary Test",
                Category = "Holiday Test",
                Shop = "Meriton Chatswood Test",
                Quantity = 2,
                Amount = 350,
                Date = DateTime.Now
            };
        }

        [Fact]
        public void Handle_EditExpense_ShouldUpdateTheRecord()
        {
            var token = new CancellationTokenSource().Token;
            _id = new Guid("fc0d6a3f-1a7e-4c5a-aa2f-2d952c4c8712");

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                // Setup
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                var currentExpense = context.Expenses.FindAsync(_id);
                _editCommand = new Edit.Command
                {
                    Id = _id,
                    Expense = _expenseDTO
                };
                _editHandler = new Edit.Handler(context, _mapper);

                // Attempt
                _editHandler.Handle(_editCommand, token).Wait();

                var actual = JsonConvert.SerializeObject(currentExpense.Result);
                var expected = JsonConvert.SerializeObject(_expenseDTO);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void Handle_IdIsNull_ThrowsNullReferenceException()
        {
            var token = new CancellationTokenSource().Token;
            _id = Guid.Empty;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                // Setup
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                _editCommand = new Edit.Command
                {
                    Id = _id,
                    Expense = _expenseDTO
                };
                _editHandler = new Edit.Handler(context, _mapper);

                // Attempt
                var action = _editHandler.Handle(_editCommand, token);

                Assert.ThrowsAsync<NullReferenceException>(() => action);
                Assert.Equal("Can't find the expense record.",
                    action.Exception.InnerException.Message);
            }
        }

        [Fact]
        public void Handle_UpdateFailed_ThrowsDbUpdateException()
        {
            var token = new CancellationTokenSource().Token;
            _id = new Guid("fc0d6a3f-1a7e-4c5a-aa2f-2d952c4c8712");

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                // Setup
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                _editCommand = new Edit.Command{ Id = _id, Expense = _expenseDTO };
                _editHandler = new Edit.Handler(context, _mapper);

                // Attempt
                var action = _editHandler.Handle(_editCommand, token);

                // Assert
                Assert.ThrowsAsync<DbUpdateException>(() => action);
                Assert.Equal("Problem saving changes.",
                    action.Exception.InnerException.Message);
            }
        }

    }
}