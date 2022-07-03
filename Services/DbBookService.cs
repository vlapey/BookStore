using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService : IBookService
    {
        private static IBookRepository _database;

        public DbBookService(IBookRepository applicationContext)
        {
            _database = applicationContext;
        }
        
        public bool CreateBook(BookDto bookData)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(bookData.AuthorName);
            if (authorId == 0)
            {
                return false;
            }
            Book book = new Book()
            {
                Name = bookData.BookName,
                Price = bookData.BookPrice,
                Author = new Author()
                {
                    Id = authorId,
                    Name = bookData.AuthorName
                }
            };
            return _database.CreateBook(book);
        }
        
        public List<Book> GetBooks()
        {
            return _database.GetBooks();
        }
       
        public Book GetBookByName(string name)
        {
            return _database.GetBookByName(name);
        }
        
        public bool DeleteBookById(uint id)
        {
            return _database.DeleteBookById(id);
        }
        
        public bool EditBook(BookDto bookData, uint bookId)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(bookData.AuthorName);
            if (authorId == 0)
            {
                return false;
            }
            Book book = new Book()
            {
                Id = bookId,
                Name = bookData.BookName,
                Price = bookData.BookPrice,
                Author = new Author()
                {
                    Id = authorId,
                    Name = bookData.AuthorName
                }
            };
            return _database.EditBook(book);
        }
    }
}