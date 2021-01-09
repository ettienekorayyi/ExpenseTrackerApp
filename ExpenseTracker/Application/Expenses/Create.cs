using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;
using ExpenseTracker.Application.Interfaces;

namespace Application.Expenses
{
    public class Create
    {
        public class Command : IRequest
        {
            public ExpenseDTO Expense { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IRepository _repository;
            private readonly IMapper _mapper;

            private ExpenseTrackerDbContext _context;
            
            public Handler(ExpenseTrackerDbContext context, IMapper mapper)
            {
                 _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (request.Expense == null)
                    throw new ArgumentNullException("The expense values are null.");
                
                var newExpense = _mapper.Map<ExpenseDTO, Expense>(request.Expense);
                
                await _context.Expenses.AddAsync(newExpense);

                var success = await _context.SaveChangesAsync() > 0 ; 
                if(success) return Unit.Value;
                
                throw new Exception("Problem adding expense.");
            }

        }
    }
}