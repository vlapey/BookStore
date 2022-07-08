using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public bool DeleteAuthorById(Author author);
        public bool EditAuthor(Author author);
        public bool CreateAuthor(Author author);
        public int GetAuthorIdByName(string name);
    }
}