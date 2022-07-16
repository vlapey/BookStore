using BookStoreApi.Dto;
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
    public bool CreateUser(UserDto user)
    {
        return _userService.CreateUser(user.Login, user.Password);
    }
    
    [HttpPost]
    public bool EditUser(UserDto user)
    {
        return _userService.EditUser(user.UserId, user.Login, user.Password);
    }
    
    [HttpDelete]
    public bool DeleteUser(int id)
    {
        return _userService.DeleteUser(id);
    }
}