using Building_a_User_s_and_Tasks_API.Models;
using Building_a_User_s_and_Tasks_API.Interface;
namespace Building_a_User_s_and_Tasks_API.Implementation;

public class UserService : IUserService
{
    private readonly List<User> _users;

    public UserService()
    {
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
        newUser.ID = _users.Count + 1;
        _users.Add(newUser);
        return newUser;
    }

    public void UpdateUser(User updatedUser)
    {
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
        var userToDelete = _users.Find(user => user.ID == userId);

        if (userToDelete != null)
        {
            _users.Remove(userToDelete);
        }
    }
}
