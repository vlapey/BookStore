
/*
 Раз уж такая пьянка пошла, но замутим прилагу магазина книг
 Чтобы функционал был следующий: 
 просмотр списка книг, 
 добавление определённых в корзину, 
 просмотр корзины, 
 сортировка по цене вверх и вниз, 
 поиск по названию
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Threading.Channels;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose action:\n" +
                              "1 - Look at the list of books\n" +
                              "2 - Add a book to cart\n" +
                              "3 - Look at the list of books in cart\n" +
                              "4 - Sorting up by price\n" +
                              "5 - Sorting down by price\n" +
                              "6 - Find book by name");
            var selector = int.Parse(Console.ReadLine());
            List<Book> books = new List<Book>()
            {
                new Book() {Price = 30, Name = "Game of thrones"},
                new Book() {Price = 13, Name = "Jack of all trades"},
                new Book() {Price = 20, Name = "Alice in the wonderland"},
                new Book() {Price = 15, Name = "Through the eyes of the victim"},
                new Book() {Price = 22, Name = "1984"}
                
            };
            switch(selector)
            {
                case 1:
                    foreach (var book in books)
                    {
                        Console.WriteLine($"Book name = {book.Name}, and price is {book.Price}");
                    }
                    break;
            }
        }
    }
}
    
