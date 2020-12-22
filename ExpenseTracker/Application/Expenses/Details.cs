using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace ExpenseTracker.Application.Expenses
{
    public class Details
    {
        public class Query : IRequest<ExpenseDTO>
        {
            public Guid Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ExpenseDTO>
        {
            private readonly ExpenseTrackerDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ExpenseTrackerDbContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ExpenseDTO> Handle(Query request, CancellationToken cancellationToken)
            {
                var expense = await _context.Expenses.FindAsync(request.Id);

                if(expense == null) throw new Exception("Read failed: Cannot find expense...");

                return _mapper.Map<Expense, ExpenseDTO>(expense);
            }
        }
    }
}