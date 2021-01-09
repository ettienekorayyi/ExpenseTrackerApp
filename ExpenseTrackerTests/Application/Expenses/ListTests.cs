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
using static Application.Expenses.List;

namespace ExpenseTrackerTests.Application.Expenses
{
    public class ListTests
    {
        private Mock<IRepository> _mockRepository;
        private Mock<IMapper> _mockMapper;
        private Mock<IRequestHandler<Query, IEnumerable<ExpenseDTO>>> _mockHandler;
        private IRequestHandler<Query, IEnumerable<ExpenseDTO>> _handler;

        public ListTests()
        {
            // Arrange            
            _mockRepository = new Mock<IRepository>();
            _mockMapper = new Mock<IMapper>();
            _mockHandler = new Mock<IRequestHandler<Query, IEnumerable<ExpenseDTO>>>();
            _handler = new List.Handler(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void ListHandler_Verify_GetExpenseIsInvoked()
        {
            var token = new CancellationTokenSource().Token;
            var query = new List.Query();

            _mockHandler.Setup(s => s.Handle(query, token));
            
            _handler.Handle(query, token);

            _mockRepository.Verify(r => r.GetExpenses(), Times.Once());
        }

        [Fact]
        public void ListHandler_WhenCalled_ShouldThrowException()
        {
            var token = new CancellationTokenSource().Token;
            var query = new List.Query();

            _mockHandler
                .Setup(s => s.Handle(query, token))
                .Throws<NullReferenceException>();

            var action = _handler.Handle(query, token);
            
            Assert.ThrowsAsync<NullReferenceException>(() => action);
            Assert.Equal("Expenses table is empty", 
                action.Exception.InnerException.Message);
        }

    }
}