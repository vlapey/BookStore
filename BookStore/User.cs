using System.Linq;
using System;
using System.Collections.Generic;

namespace BookStore
{
    public class User
    {
        public string Login;
        public string Password;
        public static List<User> users = new()
        {
            new User(){Login = "alekseyleonov", Password = "5963"},
            new User(){Login = "vlapey", Password = "2563"},
            new User(){Login = "vkondrashkov", Password = "1452"},
            new User(){Login = "armatura", Password = "8569"},
        };
    }
}