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
            return _database.GetItems();
        }
        
        public Author GetAuthorById(int id)
        {
           return _database.GetItemById(id);
        }
        
        public bool DeleteAuthorById(Author author)
        {
            return _database.DeleteItemById(author);
        }
        
        public bool EditAuthor(Author item)
        {
            return _database.EditItem(item);
        }
        
        public bool CreateAuthor(Author item)
        {
           return _database.CreateItem(item);
        }
        
        public int GetAuthorIdByName(string name)
        {
            return _database.GetAuthorIdByName(name);
        }
    }
}