using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Channels;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase.OpenConnection();
            DataBase.CloseConnection();
            /*foreach (var user in DataBase.GetUsers())
            {
                Console.WriteLine($"Userlogin is {user[1]} and password is {user[2]}");
            }*/
        }

    }
}
