using System;
using System.Collections.Generic;
using System.Threading.Channels;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService : IBookService
    {
        private static IMsSqlContext _database;

        public DbBookService(IMsSqlContext applicationContext)
        {
            _database = applicationContext;
        }

        
        public bool CreateBook(Book book)
        {
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

        
        public bool EditBook(Book book)
        {
            return _database.EditBook(book);
        }
    }
}