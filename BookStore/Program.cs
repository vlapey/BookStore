using System;
using Services;
using Services.Interfaces;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            IAuthorService authorService = new DbAuthorService();
            Console.WriteLine(authorService.GetAuthorIdByName("Vasya"));
        }
    }
}