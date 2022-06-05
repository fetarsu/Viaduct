using Microsoft.AspNetCore.Datasync;
using Microsoft.AspNetCore.Datasync.EFCore;
using Microsoft.AspNetCore.Mvc;
using ViaductBackend.Models;
using ViaductBackend.Services;

namespace ViaductBackend.Controllers
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
    [Route("tables/[controller]")]
    public class UsersController : TableController<User>
    {
        private readonly IUserService _userService;

        public UsersController(ViaductDbContext context, IUserService userService) : base()
        {
            Repository = new EntityTableRepository<User>(context);
            _userService = userService;
        }
        #endregion

        #region snippet
        [HttpGet]
        public IActionResult List()
        {
            return Ok(_userService.GetAllUsers());
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
                var itemExists = _userService.GetUser(item.Id).Result.FirstOrDefault();
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
                var existingItem = _userService.GetUser(item.Id);
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
        public IActionResult Delete(string id)
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
