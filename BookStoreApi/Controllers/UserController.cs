using BookStoreApi.Dto;
using BookStoreApi.DtoWithId;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public IEnumerable<User> GetAllUsers()
    {
        return _userService.GetUsers();
    }

    [HttpGet]
    public User GetUserById(int id)
    {
        return _userService.GetUserById(id);
    }
    
    [HttpPost]
    public bool CreateUser(UserDto userData)
    {
        User user = new User()
        {
            Login = userData.Login,
            Password = userData.Password
        };
        return _userService.CreateUser(user);
    }
    
    [HttpPost]
    public bool EditUser(UserDtoWithId userData)
    {
        User user = new User()
        {
            Id = userData.UserId,
            Login = userData.Login,
            Password = userData.Password
        };
        return _userService.EditUser(user);
    }
    
    [HttpDelete]
    public bool DeleteUser(int id)
    {
        return _userService.DeleteUser(id);
    }
}