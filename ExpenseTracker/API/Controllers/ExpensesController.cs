using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Application.Expenses;
using Application.DTOs;
using ExpenseTracker.Application.Expenses;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseTrackerDbContext _dbContext;
        private readonly IMediator _mediator;
        public ExpensesController(ExpenseTrackerDbContext dbContext, IMediator mediator)
        {
            _mediator = mediator;
            _dbContext = dbContext;
        }

        // GET api/expenses
        [HttpGet]
        public async Task<IEnumerable<ExpenseDTO>> Get()
        {
            return await _mediator.Send(new List.Query());
        }

        // GET api/expenses/5
        [HttpGet("{id}")]
        public async Task<ExpenseDTO> Get(Guid id)
        {
            return await _mediator.Send(new Details.Query { Id = id });
        }

        // POST api/expenses
        [HttpPost]
        public async Task<ActionResult<Unit>> Post([FromBody] ExpenseDTO expense)
        {
            if (!ModelState.IsValid) BadRequest();
            
            return await _mediator.Send(new Create.Command { Expense = expense });
        }

        // PUT api/expenses/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Unit>> Put(Guid id, [FromBody] ExpenseDTO expense)
        {
            if (!ModelState.IsValid) BadRequest();

            return await _mediator.Send(new Edit.Command { Id = id, Expense = expense  });
        }

        // DELETE api/expenses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Unit>> Delete(Guid id)
        {
            return await _mediator.Send(new Delete.Command { Id = id });
        }

    }
}