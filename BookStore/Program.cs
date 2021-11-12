using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            var user1 = DataBase.GetUserById(1);
            Console.WriteLine($"User1 login is {user1.Login} and password is {user1.Password}");
        }
    }
}