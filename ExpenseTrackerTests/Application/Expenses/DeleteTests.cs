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
using Newtonsoft.Json;
using Xunit.Abstractions;
using MediatR;
using static Application.Expenses.Delete;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class DeleteTests
    {
        private DbContextOptions<ExpenseTrackerDbContext> _options;
        private ExpenseTrackerDbContext _context;
        private Command _deleteCommand;
        private IRequestHandler<Command> _deleteHandler;
        private Mock<IRequestHandler<Command>> _moq;

        public DeleteTests()
        {
            _options = Helper.CreateOptions<ExpenseTrackerDbContext>();
            _deleteCommand = new Command();
            _moq = new Mock<IRequestHandler<Command>>();
        }

        [Fact]
        public void DeleteHandle_DeleteExpense_ShouldDeleteTheRecord()
        {
            var token = new CancellationTokenSource().Token;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                _deleteCommand.Id = new Guid("359c4f66-22f3-45ff-baf4-a33c3fa11a82");

                _deleteHandler = new Delete.Handler(context);
                _deleteHandler.Handle(_deleteCommand, token);

                var actual = context.Expenses.Count();
                var expected = 5;
                
                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public void DeleteHandle_IdIsNull_ThrowsNullReferenceException()
        {
            var token = new CancellationTokenSource().Token;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                _deleteHandler = new Delete.Handler(context);

                var action = _deleteHandler.Handle(_deleteCommand, token);
                var expected = "Cannot find expense to the database.";

                Assert.ThrowsAsync<NullReferenceException>(() => action);
                Assert.Equal(expected, action.Exception.InnerException.Message);
            }
        }

        [Fact]
        public void DeleteHandle_UpdateFailed_ThrowsDbUpdateException()
        {
            var token = new CancellationTokenSource().Token;

            using (var context = new ExpenseTrackerDbContext(_options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                Seed.SeedData(context);

                _deleteCommand.Id = new Guid("359c4f66-22f3-45ff-baf4-a33c3fa11a82");
                _deleteHandler = new Delete.Handler(context);

                var action = _deleteHandler.Handle(_deleteCommand, token);
                _moq
                    .Setup(x => x.Handle(_deleteCommand, token))
                    .Throws(It.IsAny<DbUpdateException>());

                Assert.ThrowsAsync<DbUpdateException>(() => action);
            }
        }

    }
}