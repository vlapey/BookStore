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
    public bool DeleteUser(int id)
    {
        return _userService.DeleteUser(id);
    }
    
    [HttpPost]
    public bool EditUser(int userId, string login, string password)
    {
        return _userService.EditUser(userId, login, password);
    }
    
    [HttpPost]
    public bool CreateUser(string login, string password)
    {
        return _userService.CreateUser(login, password);
    }
}