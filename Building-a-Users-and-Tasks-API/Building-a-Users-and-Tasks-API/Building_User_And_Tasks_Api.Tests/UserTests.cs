namespace Building_a_Users_and_Tasks_API.Building_User_And_Tasks_Api.Tests
{ 
using System.Collections.Generic;
using Building_a_User_s_and_Tasks_API.Controllers;
using Building_a_User_s_and_Tasks_API.Interface;
using Building_a_User_s_and_Tasks_API.Models;
using Moq;
using Xunit;

public class UserTests
{
    [Fact]
    public void GetAllUsers_ShouldReturnAllUsers()
    {

        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(repo => repo.GetAllUsers()).Returns(new List<User>
        {
            new User { ID = 1, Username = "JohnDoe", Email = "john.doe@example.com", Password = "password123" },
            new User { ID = 2, Username = "JaneSmith", Email = "jane.smith@example.com", Password = "letmein" }
        });

        var controller = new UserController(userServiceMock.Object);

        var result = controller.GetAllUsers();

        var users = Assert.IsType<List<User>>(result.Value);
        Assert.Equal(2, users.Count);
    }

    [Fact]
    public void GetUserById_ShouldReturnUserIfExists()
    {
        // Arrange
        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(repo => repo.GetUserById(It.IsAny<int>())).Returns((int userId) =>
        {
            if (userId == 1)
            {
                return new User { ID = 1, Username = "JohnDoe", Email = "john.doe@example.com", Password = "password123" };
            }
            return null;
        });

        var controller = new UserController(userServiceMock.Object);

        var result = controller.GetUserById(1);

        var user = Assert.IsType<User>(result.Value);
        Assert.Equal(1, user.ID);
        Assert.Equal("JohnDoe", user.Username);
    }

    [Fact]
    public void CreateUser_ShouldReturnCreatedUser()
    {
        var newUser = new User { ID = 3, Username = "NewUser", Email = "new.user@example.com", Password = "newpassword" };
        var userServiceMock = new Mock<IUserService>();
        userServiceMock.Setup(repo => repo.CreateUser(It.IsAny<User>())).Returns(newUser);

        var controller = new UserController(userServiceMock.Object);

        var result = controller.CreateUser(newUser);

        var createdUser = Assert.IsType<User>(result.Value);
        Assert.Equal(newUser.ID, createdUser.ID);
        Assert.Equal(newUser.Username, createdUser.Username);
    }

} }

