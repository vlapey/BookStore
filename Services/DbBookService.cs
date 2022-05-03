using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService:IBookService
    {
        private static IApplicationContext _database;

        public DbBookService(IApplicationContext applicationContext)
        {
            _database = applicationContext;
        }
        public bool CreateBook(Book book)
        {
            var authordata = _database.ToList
            ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            if (authordata.Count == 0)
            {
                return false;
            }
            var result = _database.Execute($"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                                           $"VALUES ('{book.Name}', '{book.Price}', '{authordata[0][0]}')");
            return result > 0;
        } 
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            var bookdata = _database.ToList
                ("SELECT books.id, books.name, books.price, authors.name" + 
                 " FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            if (bookdata.Count == 0)
            {
                return null;
            }
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
            var bookdata = _database.ToList
            ($"SELECT books.id, books.name, books.price, authors.name" + 
             $" FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            if (bookdata[0][1] != name)
            {
                return null;
            }
            Book book = new Book()
            {
                Id = Convert.ToUInt32(bookdata[0][0]),
                Name = name,
                Price = Convert.ToInt32(bookdata[0][2]),
                Author = bookdata[0][3]
            };
            return book;
        }

        public bool DeleteBookById(uint id)
        {
            var result = _database.Execute($"DELETE FROM books WHERE books.id = {id}");
            return result > 0;
        }

        public bool EditBook(Book book)
        {
            var authordata = _database.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            var result = _database.Execute($"UPDATE books SET books.name = '{book.Name}', books.price = {book.Price}, " 
                                           + $"books.authors_id = {authordata[0][0]} WHERE books.id = {book.Id}");
            return result > 0;
        }
        
    }
}