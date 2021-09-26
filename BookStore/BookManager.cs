using System.Collections.Generic;
using System.Linq;
using System;

namespace BookStore
{
    public static class BookManager
    {
        private static List<Book> books = new ()
        {
            new Book() {Price = 30, Name = "Game of thrones"},
            new Book() {Price = 13, Name = "Jack of all trades"},
            new Book() {Price = 20, Name = "Alice in the wonderland"},
            new Book() {Price = 15, Name = "Through the eyes of the victim"},
            new Book() {Price = 22, Name = "1984"}
        };
        public static void PrintBookList()
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }
        public static void PrintCartList()
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
        public static void AddBook()
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
        public static void AscendingSort()
        {
            books.Sort((book1, book2) => book1.Price - book2.Price);
            Console.WriteLine("Sorted up by price");
        }
        public static void DescendingSort()
        {
            books.Sort((book1, book2) => book2.Price - book1.Price);
            Console.WriteLine("Sorted up by price");
        }
        public static void FindBook()
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