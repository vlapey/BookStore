using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IAuthorService
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(int id);
        public int GetAuthorIdByName(string name);
        public bool CreateAuthor(string authorName);
        public bool EditAuthor(int authorId, string authorName);
        public bool DeleteAuthor(int id);
    }
}