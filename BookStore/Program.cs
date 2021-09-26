﻿
/*
 Чтобы функционал был следующий: 
 case 1: просмотр списка книг, 
 case 2: добавление определённых в корзину, 
 case 3:просмотр корзины, 
 case 4 and 5: сортировка по цене вверх и вниз, 
 case 6: поиск по названию
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
            List<Book> books = new List<Book>()
            {
                new Book() {Price = 30, Name = "Game of thrones"},
                new Book() {Price = 13, Name = "Jack of all trades"},
                new Book() {Price = 20, Name = "Alice in the wonderland"},
                new Book() {Price = 15, Name = "Through the eyes of the victim"},
                new Book() {Price = 22, Name = "1984"}
                
            };
            while (true)
            {
                Console.WriteLine("Choose action:\n" +
                                  "1 - Look at the list of books\n" +
                                  "2 - Add a book to cart\n" +
                                  "3 - Look at the list of books in cart\n" +
                                  "4 - Sorting up by price\n" +
                                  "5 - Sorting down by price\n" +
                                  "6 - Find book by name\n");
                var selector = int.Parse(Console.ReadLine());

                switch (selector)
                {
                    case 1:
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }

                        break;
                    case 2:
                        foreach (var book in books)
                        {
                            Console.WriteLine(book);
                        }
                        Console.WriteLine("Type the name of the book that you want to add to cart");
                        string bookNameForAdd = Console.ReadLine();
                        Cart.bookList.Add(books.Find(book => book.Name == bookNameForAdd));
                        break;
                    case 3: 
                        foreach (var book in Cart.bookList)
                        {
                            Console.WriteLine(book);
                        }
                        break;
                    case 4: Cart.bookList.Sort((book1, book2) => book1.Price - book2.Price);
                        break;
                    case 5: Cart.bookList.Sort((book1, book2) => book2.Price - book1.Price);
                        break;
                    case 6:  Console.WriteLine("Type the name of the book that you want to find in the store");
                        string bookNameForFindAll = Console.ReadLine();
                        Book foundedBook = books.Find(book => bookNameForFindAll == book.Name);
                        Console.WriteLine(foundedBook);
                        break;
                    default: Console.WriteLine("You've chosen wrong action");
                        break;
                }
            }
        }
    }
}
    
