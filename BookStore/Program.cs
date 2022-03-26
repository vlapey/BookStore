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
            
            IBookService bookService = new DbBookService();
            foreach (var book in bookService.GetBooks())
            {
                Console.WriteLine(book);
            }
            Book gettedBook = bookService.GetBookByName("1984");
            Console.WriteLine(gettedBook);
            gettedBook.Price++;
            bookService.EditBook(gettedBook);
            Book newGettedBook = bookService.GetBookByName("1984");
            Console.WriteLine(newGettedBook);
        }
    }
}