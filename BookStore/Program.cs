using System;
using Services;
using Services.Interfaces;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            DbUserService service = new DbUserService();
            foreach (var book in service.GetUsersBooks(3))
            {
                Console.WriteLine(book);
            }
        }
    }
}