using Microsoft.AspNetCore.Mvc;

namespace API_Viaduct.Controllers
{
    using API_Viaduct.Models;
    using API_Viaduct.Services;
    using Microsoft.AspNetCore.Mvc;

    namespace ViaductAPI.Controllers
    {
        #region snippetErrorCode
        public enum ErrorCode
        {
            TodoItemNameAndNotesRequired,
            TodoItemIDInUse,
            RecordNotFound,
            CouldNotCreateItem,
            CouldNotUpdateItem,
            CouldNotDeleteItem
        }
        #endregion

        #region snippetDI
        [ApiController]
        [Route("[controller]")]
        public class UsersController : ControllerBase
        {
            private readonly IUserService _userService;
            private readonly ViaductDbContext _dbContext;

            public UsersController(IUserService userService, ViaductDbContext dbContext)
            {
                _userService = userService;
                _dbContext = dbContext;
            }
            #endregion

            #region snippet
            [HttpGet]
            public IActionResult List()
            {
                return Ok(_dbContext.Users);
            }
            #endregion

            #region snippetCreate

            [HttpPost]
            public IActionResult Create([FromBody] User item)
            {
                try
                {
                    if (item == null || !ModelState.IsValid)
                    {
                        return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                    }
                    var itemExists = _userService.GetUser(item.UserId).Result.FirstOrDefault();
                    if (itemExists != null)
                    {
                        return StatusCode(StatusCodes.Status409Conflict, ErrorCode.TodoItemIDInUse.ToString());
                    }
                    _userService.AddUser(item);
                }
                catch (Exception)
                {
                    return BadRequest(ErrorCode.CouldNotCreateItem.ToString());
                }
                return Ok(item);
            }
            #endregion

            #region snippetEdit
            [HttpPut]
            public IActionResult Edit([FromBody] User item)
            {
                try
                {
                    if (item == null || !ModelState.IsValid)
                    {
                        return BadRequest(ErrorCode.TodoItemNameAndNotesRequired.ToString());
                    }
                    var existingItem = _userService.GetUser(item.UserId);
                    if (existingItem == null)
                    {
                        return NotFound(ErrorCode.RecordNotFound.ToString());
                    }
                    _userService.UpdateUser(item);
                }
                catch (Exception)
                {
                    return BadRequest(ErrorCode.CouldNotUpdateItem.ToString());
                }
                return NoContent();
            }
            #endregion

            #region snippetDelete
            [HttpDelete("{id}")]
            public IActionResult Delete(int id)
            {
                try
                {
                    var item = _userService.GetUser(id).Result.FirstOrDefault();
                    if (item == null)
                    {
                        return NotFound(ErrorCode.RecordNotFound.ToString());
                    }
                    _userService.DeleteUser(item);
                }
                catch (Exception)
                {
                    return BadRequest(ErrorCode.CouldNotDeleteItem.ToString());
                }
                return NoContent();
            }
            #endregion
        }
    }


}
