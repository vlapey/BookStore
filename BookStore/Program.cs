using System;
using Models;
using Services;
using Services.Interfaces;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new DbUserService();
            User user = new User()
            {
                Id = 3,
                Login = "Funduk",
                Password = "3456"
            };
            userService.EditUser(user);
        }
    }
}