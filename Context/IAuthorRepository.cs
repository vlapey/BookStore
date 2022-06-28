using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IAuthorRepository
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(uint id);
        public bool DeleteAuthorById(uint id);
        public bool EditAuthor(Author author);
        public bool CreateAuthor(Author author);
        public uint GetAuthorIdByName(string name);
    }
}