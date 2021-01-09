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
using MediatR;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Xunit;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class CreateTests
    {
        private DbContextOptions<ExpenseTrackerDbContext> _options;
        private Mock<IMapper> _mockMapper;
        private Mock<IRepository> _mockRepository;
        private Mock<IRequestHandler<Create.Command>> _mockCreateHandler;
        private Mock<IDbContext> _dBcontext;
        private Create.Handler _createHandler;

        private ExpensesRepository _expensesRepository;
        private Create.Command _createCommand;

        private Expense _expense;

        public CreateTests()
        {
            _mockRepository = new Mock<IRepository>();
            _mockMapper = new Mock<IMapper>();
            _dBcontext = new Mock<IDbContext>();
            _mockCreateHandler = new Mock<IRequestHandler<Create.Command>>();

            _options = Helper.CreateOptions<ExpenseTrackerDbContext>(); //

            _createCommand = new Create.Command
            {
                Expense = new ExpenseDTO
                {
                    Description = "Description Test",
                    Category = "Category Test",
                    Shop = "Shop Test",
                    Quantity = 1,
                    Amount = 100,
                    Date = DateTime.Now
                }
            };

            _expense = new Expense
            {
                Description = "Description Test",
                Category = "Category Test",
                Shop = "Shop Test",
                Quantity = 1,
                Amount = 100,
                Date = DateTime.Now
            };
        }

        [Fact]
        public void CreateHandler_CreateExpense_VerifyAddExpense()
        {
            var token = new CancellationTokenSource().Token;

            _mockCreateHandler
                .Setup(c => c.Handle(_createCommand, token))
                .Returns(It.IsAny<Task<Unit>>());

            _mockRepository
                .Setup(r => r.AddExpense(_expense))
                .Returns(It.IsAny<Task<bool>>());

            _mockMapper
                .Setup(m => m.Map<ExpenseDTO, Expense>(_createCommand.Expense))
                .Returns(_expense);


            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _createHandler = new Create.Handler(context, _mockMapper.Object);

                _createHandler.Handle(_createCommand, token).Wait();
                var actual = context.Expenses.CountAsync().Result;

                Assert.Equal(1, actual);
            }
        }

        [Fact]
        public void CreateHandler_CreateExpenseArgsNull_ThrowsArgumentNullException()
        {
            var command = new Create.Command { Expense = null };
            var token = new CancellationTokenSource().Token;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _createHandler = new Create.Handler(context, _mockMapper.Object);
                
                _mockCreateHandler
                    .Setup(c => c.Handle(command, token))
                    .Throws<ArgumentNullException>();

                Assert.ThrowsAsync<ArgumentNullException>(() =>
                    _createHandler.Handle(command, token));
            }
        }

        [Fact]
        public void CreateHandler_CreateExpense_ThrowsException()
        {
            var command = new Create.Command { Expense = null };
            var token = new CancellationTokenSource().Token;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                _createHandler = new Create.Handler(context, _mockMapper.Object);
                
                _mockCreateHandler
                    .Setup(c => c.Handle(command, token))
                    .Throws<Exception>();

                var action = _createHandler.Handle(command, token);

                Assert.ThrowsAsync<NullReferenceException>(() => action);
                
            }
        }

    }
}