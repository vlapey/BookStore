
using System;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DataBase.GetUserById(2));
        }
    }
}