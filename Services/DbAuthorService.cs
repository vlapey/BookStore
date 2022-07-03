using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbAuthorService : IAuthorService
    {
        private static IAuthorRepository _database;

        public DbAuthorService(IAuthorRepository applicationContext)
        {
            _database = applicationContext;
        }
        
        public List<Author> GetAuthors()
        {
            return _database.GetAuthors();
        }
        
        public Author GetAuthorById(int id)
        {
           return _database.GetAuthorById(id);
        }
        
        public bool DeleteAuthorById(int id)
        {
            return _database.DeleteAuthorById(id);
        }
        
        public bool EditAuthor(Author author)
        {
            return _database.EditAuthor(author);
        }
        
        public bool CreateAuthor(Author author)
        {
           return _database.CreateAuthor(author);
        }
        
        public int GetAuthorIdByName(string name)
        {
            return _database.GetAuthorIdByName(name);
        }
    }
}