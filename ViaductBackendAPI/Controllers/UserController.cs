using Microsoft.AspNetCore.Mvc;
using ViaductBackendAPI.Models;

namespace ViaductBackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ViaductDbContext _dbContext;


        public UserController(ViaductDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(_dbContext.User);
        }

        [HttpGet]
        [Route("id/{id}")]
        public OkObjectResult GetUserById(int Id)
        {
            return Ok(_dbContext.User.Where(x => x.UserId == Id).SingleOrDefault());
        }

        [HttpGet]
        [Route("login/{login}")]
        public OkObjectResult GetUserByLogin(string login)
        {
            return Ok(_dbContext.User.Where(x => x.Name.Equals(login)).SingleOrDefault());
        }


        [HttpPost]
        public IActionResult PostUser([FromBody] User item)
        {
            _dbContext.User.Add(item);
            _dbContext.SaveChanges();
            return Ok(item);
        }
    }

}
