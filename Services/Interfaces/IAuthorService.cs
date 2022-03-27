using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(uint id);
        public void DeleteAuthorById(uint id);
        public void EditAuthor(Author author);
        public void CreateAuthor(Author author);
        public Author GetAuthorIdByName(Author author);
    }
}