using System;
using System.Collections.Generic;
using Models;

namespace Context
{
    public class BookRepository : IBookRepository
    {
        public bool CreateBook(Book book)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            var authordata = authorRepository.GetAuthorIdByName(book.Author);
            if (authordata == 0)
            {
                return false;
            }
            var result = MySqlContext.Execute(
                $"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                $"VALUES ('{book.Name}', '{book.Price}', '{authordata}')");
            return result > 0;
        }

        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            var bookdata = MySqlContext.ToList(
                "SELECT books.id, books.name, books.price, authors.name" +
                " FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            if (bookdata.Count == 0)
            {
                return null;
            }
            foreach (var book in bookdata)
            {
                books.Add(new Book()
                {
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
            var bookdata = MySqlContext.ToList(
                $"SELECT books.id, books.name, books.price, authors.name" +
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
            var result = MySqlContext.Execute($"DELETE FROM books WHERE books.id = {id}");
            return result > 0;
        }

        public bool EditBook(Book book, uint authordata)
        {
            List<string[]> bookId = MySqlContext.ToList($"SELECT books.id FROM books WHERE books.id = {book.Id}");
            if (bookId.Count == 0)
            {
                return false;
            }
            var result = MySqlContext.Execute(
                $"UPDATE books SET books.name = '{book.Name}', books.price = {book.Price}, "
                + $"books.authors_id = {authordata} WHERE books.id = {book.Id}");
            return result > 0;
        }
    }
}