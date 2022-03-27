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
            IAuthorService authorService = new DbAuthorService();
            Author author = new Author()
            {
                Name = "Вуичич"
            };
            authorService.GetAuthorIdByName(author);
        }
    }
}