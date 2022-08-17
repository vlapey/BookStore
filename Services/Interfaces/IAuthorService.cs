using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public int GetAuthorIdByName(string name);
        public bool CreateAuthor(Author author);
        public bool EditAuthor(Author author);
        public bool DeleteAuthor(int id);
    }
}