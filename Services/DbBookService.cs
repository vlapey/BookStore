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
        
        public bool CreateBook(Book book)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(book.Author);
            if (authorId == 0)
            {
                return false;
            }
            return _database.CreateBook(book, authorId);
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
        
        public bool EditBook(Book book)
        {
            AuthorRepository authorRepository = new AuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(book.Author);
            if (authorId == 0)
            {
                return false;
            }
            return _database.EditBook(book, authorId);
        }
    }
}