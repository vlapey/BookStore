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
        
        public bool DeleteAuthor(int authorId)
        {
            Author author = new Author()
            {
                Id = authorId
            };
            return _database.DeleteItemById(author);
        }
        
        public bool EditAuthor(int authorId, string authorName)
        {
            Author author = new Author()
            {
                Id = authorId,
                Name = authorName,
            };
            return _database.EditItem(author);
        }
        
        public bool CreateAuthor(string authorName)
        {
            Author author = new Author()
            {
                Name = authorName
            };
           return _database.CreateItem(author);
        }
        
        public int GetAuthorIdByName(string name)
        {
            return _database.GetAuthorIdByName(name);
        }
    }
}