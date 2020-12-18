using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace ExpenseTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController
    {
        // GET api/expenses
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "test1", "test2" };
        }

        // GET api/expenses/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/expenses
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/expenses/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/expenses/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        
    }
}