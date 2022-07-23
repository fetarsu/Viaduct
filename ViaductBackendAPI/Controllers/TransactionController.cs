using Microsoft.AspNetCore.Mvc;
using ViaductBackendAPI.Models;

namespace ViaductBackendAPI.Controllers
{
    public class TransactionController : Controller
    {
        private readonly ViaductDbContext _dbContext;

        public TransactionController(ViaductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllTransactions()
        {
            return Ok(_dbContext.Transaction);
        }

        [HttpGet]
        [Route("id/{id}")]
        public OkObjectResult GetTransactionById(int Id)
        {
            return Ok(_dbContext.Transaction.Where(x => x.TransactionId == Id).SingleOrDefault());
        }

        [HttpGet]
        [Route("date/{date}")]
        public OkObjectResult GetTransactionsFromOneDay(DateTime date)
        {
            return Ok(_dbContext.Transaction.Where(x => x.Date.Day == date.Day && x.Date.Month == date.Month && x.Date.Year == date.Year).ToList());
        }


        [HttpPost]
        public IActionResult PostTransaction([FromBody] Transaction item)
        {
            _dbContext.Transaction.Add(item);
            _dbContext.SaveChanges();
            return Ok(item);
        }
    }
}
