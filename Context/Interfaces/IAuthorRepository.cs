using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public bool DeleteAuthorById(int id);
        public bool EditAuthor(Author author);
        public bool CreateAuthor(Author author);
        public int GetAuthorIdByName(string name);
    }
}