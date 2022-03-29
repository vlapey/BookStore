using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService:IBookService
    {
        public void CreateBook(Book book)
        {
            var authordata = ApplicationContext.ToList
            ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            ApplicationContext.Execute($"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                $"VALUES ('{book.Name}', '{book.Price}', '{authordata[0][0]}')");
        } 
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            var bookdata = ApplicationContext.ToList
                ("SELECT books.id, books.name, books.price, authors.name" + 
                 " FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            foreach (var book in bookdata)
            {
                books.Add(new Book(){
                    Id = Convert.ToUInt32(book[0]),
                    Name = book[1],
                    Price = Convert.ToInt32(book[2]),
                    Author = book[3]
                });
            }
            return books;
        }

        public Book GetBookByName(string name)
        {
            var bookdata = ApplicationContext.ToList
            ($"SELECT books.id, books.name, books.price, authors.name" + 
             $" FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            Book book = new Book()
            {
                Id = Convert.ToUInt32(bookdata[0][0]),
                Name = name,
                Price = Convert.ToInt32(bookdata[0][2]),
                Author = bookdata[0][3]
            };
            return book;
        }

        public void DeleteBookById(uint id)
        {
            ApplicationContext.Execute($"DELETE FROM books WHERE books.id = {id}");
        }

        public void EditBook(Book book)
        {
            var authordata = ApplicationContext.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            ApplicationContext.Execute($"UPDATE books SET books.name = '{book.Name}', books.price = {book.Price}, " 
                                       + $"books.authors_id = {authordata[0][0]} WHERE books.id = {book.Id}");
        }
    }
}