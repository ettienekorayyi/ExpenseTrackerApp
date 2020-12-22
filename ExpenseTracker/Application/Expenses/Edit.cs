using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;

namespace Application.Expenses
{
    public class Edit
    {
        public class Command : IRequest<Unit>
        {
            public Guid Id { get; set; }
            public ExpenseDTO Expense { get; set; }
        }

        public class Handler : IRequestHandler<Command, Unit>
        {
            private readonly ExpenseTrackerDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ExpenseTrackerDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var currentExpense = await _context.Expenses.FindAsync(request.Id);

                if(currentExpense == null) throw new NullReferenceException();

               request.Expense.Id = currentExpense.Id;

                _mapper.Map(request.Expense, currentExpense);

                var success = await _context.SaveChangesAsync() > 0;
                if(success) return Unit.Value;

                throw new Exception("Problem saving changes.");
            }
        }

    }
}