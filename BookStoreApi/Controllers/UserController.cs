using BookStoreApi.Dto;
using BookStoreApi.DtoWithId;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using AutoMapper;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IMapper _mapper;
    
    public UserController(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
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
        var user = _mapper.Map<User>(userData);
        return _userService.CreateUser(user);
    }
    
    [HttpPost]
    public bool EditUser(UserDtoWithId userData)
    {
        var user = _mapper.Map<User>(userData);
        return _userService.EditUser(user);
    }
    
    [HttpDelete]
    public bool DeleteUser(int id)
    {
        return _userService.DeleteUser(id);
    }
}