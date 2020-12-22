using System.Linq;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.DTOs;
using AutoMapper;
using MediatR;
using Persistence;
using System.Collections.Generic;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Expenses
{
    public class List
    {

        public class Query : IRequest<IEnumerable<ExpenseDTO>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<ExpenseDTO>>
        {
            private readonly ExpenseTrackerDbContext _context;
            private readonly IMapper _mapper;

            public Handler(ExpenseTrackerDbContext context, IMapper mapper)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<IEnumerable<ExpenseDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var expenses = await _context.Expenses.ToListAsync();

                if(expenses == null)
                    throw new Exception("Rest Exception...");

                return _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
            }
        }
    }
}