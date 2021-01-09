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
using ExpenseTracker.Application.Classes;
using ExpenseTracker.Application.Interfaces;

namespace Application.Expenses
{
    public class List
    {

        public class Query : IRequest<IEnumerable<ExpenseDTO>>
        {
        }

        public class Handler : IRequestHandler<Query, IEnumerable<ExpenseDTO>>
        {
            private readonly IRepository _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            public async Task<IEnumerable<ExpenseDTO>> Handle(Query request, CancellationToken cancellationToken)
            {
                var expenses = await _repository.GetExpenses();

                if(expenses == null || expenses.Count() == 0)
                    throw new ArgumentNullException("Expenses table is empty");

                return _mapper.Map<IEnumerable<Expense>, IEnumerable<ExpenseDTO>>(expenses);
            }
            
        }
    }
}