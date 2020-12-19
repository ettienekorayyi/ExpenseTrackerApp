using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        private readonly ExpenseTrackerDbContext _dbContext;
        public ExpensesController(ExpenseTrackerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET api/expenses
        [HttpGet]
        public ActionResult<IEnumerable<Expense>> Get()
        {
            var results = _dbContext.Expenses.AsQueryable();

            if (results == null)
                return NotFound();

            return Ok(results);
        }

        // GET api/expenses/5
        [HttpGet("{id}")]
        public ActionResult<Expense> Get(Guid id)
        {
            var result = _dbContext.Expenses
                .FirstOrDefault(exp => exp.Id == id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        // POST api/expenses
        [HttpPost]
        public ActionResult Post([FromBody] Expense expense)
        {
            if (expense == null)
                return BadRequest();

            _dbContext.Add(expense);
            _dbContext.SaveChanges();

            return Created("/api/expenses/", 
                new { Result = "New Expense has been added." });            
        }

        // PUT api/expenses/5
        [HttpPut("{id}")]
        public ActionResult Put(Guid id, [FromBody] Expense expense)
        {
            if(id != expense.Id)
                BadRequest();

            var result = _dbContext.Expenses
                .FirstOrDefault(exp => exp.Id == id);

            if(result == null)
                NotFound();
            
            result.Description = expense.Description;
            result.Category = expense.Category;
            result.Shop = expense.Shop;
            result.Quantity = expense.Quantity;
            result.Amount = expense.Amount;
            result.Date = expense.Date;

            _dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/expenses/5
        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            var result = _dbContext.Expenses.FirstOrDefault(exp => exp.Id == id);

            if(result == null)
                NotFound();

            _dbContext.Remove(result);
            _dbContext.SaveChanges();

            return NoContent();
        }

    }
}