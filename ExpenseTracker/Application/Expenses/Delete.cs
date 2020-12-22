using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Expenses
{
    public class Delete
    {
        public class Command : IRequest
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly ExpenseTrackerDbContext _context;
            private readonly IMapper _mapper;
            public Handler(ExpenseTrackerDbContext context, IMapper mapper)
            {
                this._mapper = mapper;
                this._context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var removeExpense = await _context.Expenses.FindAsync(request.Id);

                if (removeExpense == null) throw new Exception("Delete failed: Cannot find expense.");
                
                _context.Expenses.Remove(removeExpense);

                var success = await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;

                throw new Exception("Problem adding expense.");
            }

        }
    }
}