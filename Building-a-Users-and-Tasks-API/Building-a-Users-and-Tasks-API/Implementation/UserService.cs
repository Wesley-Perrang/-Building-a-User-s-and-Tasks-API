using Building_a_User_s_and_Tasks_API.Models;
using Building_a_User_s_and_Tasks_API.Interface;
namespace Building_a_User_s_and_Tasks_API.Implementation;

public class UserService : IUserService
{
    private readonly List<User> _users; // In a real-world scenario, you'd use a database or some storage mechanism.

    public UserService()
    {
        // Initialize with some sample data. In a real scenario, you might fetch this from a database.
        _users = new List<User>
        {
            new User { ID = 1, Username = "JohnDoe", Email = "john.doe@example.com", Password = "password123" },
            new User { ID = 2, Username = "JaneSmith", Email = "jane.smith@example.com", Password = "letmein" }
        };
    }

    public IEnumerable<User> GetAllUsers()
    {
        return _users;
    }

    public User GetUserById(int userId)
    {
        return _users.Find(user => user.ID == userId);
    }

    public User CreateUser(User newUser)
    {
        // In a real scenario, you'd handle creating a new user in your database.
        newUser.ID = _users.Count + 1; // Simulating auto-incrementing ID.
        _users.Add(newUser);
        return newUser;
    }

    public void UpdateUser(User updatedUser)
    {
        // In a real scenario, you'd handle updating a user in your database.
        var existingUser = _users.Find(user => user.ID == updatedUser.ID);

        if (existingUser != null)
        {
            existingUser.Username = updatedUser.Username;
            existingUser.Email = updatedUser.Email;
            existingUser.Password = updatedUser.Password;
        }
    }

    public void DeleteUser(int userId)
    {
        // In a real scenario, you'd handle deleting a user from your database.
        var userToDelete = _users.Find(user => user.ID == userId);

        if (userToDelete != null)
        {
            _users.Remove(userToDelete);
        }
    }
}
