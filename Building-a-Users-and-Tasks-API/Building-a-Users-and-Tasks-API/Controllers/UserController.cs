using Microsoft.AspNetCore.Mvc;
using Building_a_User_s_and_Tasks_API.Models;
using Building_a_User_s_and_Tasks_API.Interface;

namespace Building_a_User_s_and_Tasks_API.Controllers
{
    /// <summary>
    /// Manages operations related to users.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserController"/> class.
        /// </summary>
        /// <param name="userService">The user service.</param>
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var users = _userService.GetAllUsers();
            return users;
        }

        /// <summary>
        /// Retrieves a user by ID.
        /// </summary>
        /// <param name="id">The user ID.</param>
        /// <returns>The user with the specified ID.</returns>
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

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="newUser">The new user data.</param>
        /// <returns>The newly created user.</returns>
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

        /// <summary>
        /// Updates an existing user.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updatedUser">The updated user data.</param>
        /// <returns>No content if successful, bad request or not found otherwise.</returns>
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

        /// <summary>
        /// Deletes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>No content if successful, not found otherwise.</returns>
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
}
