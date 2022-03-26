using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(uint id);
        public void DeleteAuthorById(uint id);
        public void EditAuthor();
        public void CreateAuthor(Author author);
    }
}