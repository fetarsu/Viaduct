using Microsoft.AspNetCore.Mvc;
using ViaductBackendAPI.Models;

namespace ViaductBackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly ViaductDbContext _dbContext;


        public ReportController(ViaductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllReports()
        {
            return Ok(_dbContext.Report);
        }

        [HttpGet]
        [Route("id/{id}")]
        public OkObjectResult GetReportById(int Id)
        {
            return Ok(_dbContext.Report.Where(x => x.ReportId == Id).SingleOrDefault());
        }

        [HttpGet]
        [Route("date/{date}")]
        public OkObjectResult GetReporByDate(DateTime date)
        {
            return Ok(_dbContext.Report.Where(x => x.Date.Day == date.Day && x.Date.Month == date.Month && x.Date.Year == date.Year).SingleOrDefault());
        }


        [HttpPost]
        public IActionResult PostReport([FromBody] Report item)
        {
            _dbContext.Report.Add(item);
            _dbContext.SaveChanges();
            return Ok(item);
        }
    }
}
