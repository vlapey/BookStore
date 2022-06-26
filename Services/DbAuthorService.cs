using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbAuthorService : IAuthorService
    {
        private static IMsSqlContext _database;

        public DbAuthorService(IMsSqlContext applicationContext)
        {
            _database = applicationContext;
        }
        
        //из-за ошибки: Cannot access non-static method 'GetAuthors' in static context 
        //приходится вызывать через объект класса
        public List<Author> GetAuthors()
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetAuthors();
        }
        
        //проверка есть
        public Author GetAuthorById(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetAuthorById(id);
        }
        
        //проверка есть
        public bool DeleteAuthorById(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.DeleteAuthorById(id);
        }
        
        //проверка есть
        public bool EditAuthor(Author author)
        {
            MsSqlContext context = new MsSqlContext();
            return context.EditAuthor(author);
        }
        
        //проверка есть
        public bool CreateAuthor(Author author)
        {
            MsSqlContext context = new MsSqlContext();
            return context.CreateAuthor(author);
        }
        
        //проверка есть
        public uint GetAuthorIdByName(string name)
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetAuthorIdByName(name);
        }
    }
}