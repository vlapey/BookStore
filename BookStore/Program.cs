
/*
 Чтобы функционал был следующий: 
 case 1: просмотр списка книг, 
 case 2: добавление определённых в корзину, 
 case 3:просмотр корзины, 
 case 4 and 5: сортировка по цене вверх и вниз, 
 case 6: поиск по названию
 создать отдельную функцию на вывод
 
 */

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
                Console.WriteLine("\nChoose action:\n" +
                                  "1 - Look at the list of books\n" +
                                  "2 - Add a book to cart\n" +
                                  "3 - Look at the list of books in cart\n" +
                                  "4 - Sorting up by price\n" +
                                  "5 - Sorting down by price\n" +
                                  "6 - Find book by name");
                var selector = int.Parse(Console.ReadLine());

                switch (selector)
                {
                    case 1:
                        PrintBookList(books);
                        break;
                    
                    case 2:
                        PrintBookList(books);
                        AddBook(books);
                        break;
                    
                    case 3: 
                        PrintCartList(books);
                        break;
                    
                    case 4: AscendingSort(books);
                        break;
                    
                    case 5: DescendingSort(books);
                        break;
                    
                    case 6:  FindBook(books);
                        break;
                    
                    default: Console.WriteLine("You've chosen wrong action");
                        break;
                }
            }
        }

        private static void PrintBookList(List<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        private static void PrintCartList(List<Book> bookList)
        {
            if (Cart.bookList.Count == 0)
                Console.WriteLine("Cart is empty");
            else 
            {
                foreach (var book in Cart.bookList)
                {
                    Console.WriteLine(book);
                }
            }
        }
        private static void AddBook(List<Book> books)
        {
            Console.WriteLine("Type the name of the book that you want to add to cart");
            string bookNameForAdd = Console.ReadLine();
            try
            {
                Book bookToAdd = books.First(book => book.Name == bookNameForAdd);
                Cart.bookList.Add(bookToAdd);
                Console.WriteLine("Book added");
            }
            catch (Exception e)
            {
                Console.WriteLine("Book was not added");
            }
        }
        private static void AscendingSort(List<Book> books)
        {
            books.Sort((book1, book2) => book1.Price - book2.Price);
            Console.WriteLine("Sorted up by price");
        }
        private static void DescendingSort(List<Book> books)
        {
            books.Sort((book1, book2) => book2.Price - book1.Price);
            Console.WriteLine("Sorted up by price");
        }
        private static void FindBook(List<Book> books)
        {
            Console.WriteLine("Type the name of the book that you want to find in the store");
            string bookNameForFindAll = Console.ReadLine();
            Book foundedBook = books.Find(book => bookNameForFindAll == book.Name);
            if (foundedBook == null)
                Console.WriteLine("Book is not found");
            else Console.WriteLine(foundedBook);
        }
    }
}
    
