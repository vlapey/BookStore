using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            foreach (var user in DataBase.GetUsers())
            {
                Console.WriteLine($"{user[1]} your password is {user[2]}");
            }
        }
    }
}