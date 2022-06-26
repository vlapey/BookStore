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
            MsSqlContext context = new MsSqlContext();
            return context.CreateBook(book);
        }

        
        public List<Book> GetBooks()
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetBooks();
        }

       
        public Book GetBookByName(string name)
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetBookByName(name);
        }

        
        public bool DeleteBookById(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.DeleteBookById(id);
        }

        
        public bool EditBook(Book book)
        {
            MsSqlContext context = new MsSqlContext();
            return context.EditBook(book);
        }
    }
}