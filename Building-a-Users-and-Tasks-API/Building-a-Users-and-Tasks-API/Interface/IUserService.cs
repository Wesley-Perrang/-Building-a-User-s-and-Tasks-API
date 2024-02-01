using Building_a_User_s_and_Tasks_API.Models;
namespace Building_a_User_s_and_Tasks_API.Interface;

public interface IUserService
{
    IEnumerable<User> GetAllUsers();
    User GetUserById(int userId);
    User CreateUser(User newUser);
    void UpdateUser(User updatedUser);
    void DeleteUser(int userId);
}
