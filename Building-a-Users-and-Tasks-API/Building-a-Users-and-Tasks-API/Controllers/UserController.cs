using Microsoft.AspNetCore.Mvc;
using Building_a_User_s_and_Tasks_API.Models;
using Building_a_User_s_and_Tasks_API.Interface;
namespace Building_a_User_s_and_Tasks_API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/user
    [HttpGet]
    public IEnumerable<User> GetAllUsers()
    {
        var users = _userService.GetAllUsers();
        return users;
    }

    // GET: api/user/{id}
    [HttpGet("{id}")]
    public ActionResult<User> GetUserById(int id)
    {
        var user = _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // POST: api/user
    [HttpPost]
    public ActionResult<User> CreateUser([FromBody] User newUser)
    {
        if (newUser == null)
        {
            return BadRequest("Invalid user data");
        }

        var createdUser = _userService.CreateUser(newUser);
        return CreatedAtAction(nameof(GetUserById), new { id = createdUser.ID }, createdUser);
    }

    // PUT: api/user/{id}
    [HttpPut("{id}")]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        if (updatedUser == null || id != updatedUser.ID)
        {
            return BadRequest("Invalid user data");
        }

        var existingUser = _userService.GetUserById(id);

        if (existingUser == null)
        {
            return NotFound();
        }

        _userService.UpdateUser(updatedUser);
        return NoContent();
    }

    // DELETE: api/user/{id}
    [HttpDelete("{id}")]
    public IActionResult DeleteUser(int id)
    {
        var userToDelete = _userService.GetUserById(id);

        if (userToDelete == null)
        {
            return NotFound();
        }

        _userService.DeleteUser(id);
        return NoContent();
    }
}
