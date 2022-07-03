using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class EfAuthorRepository : IAuthorRepository
    {
        private MsSqlContext _dataBase;
        
        public EfAuthorRepository()
        {
            _dataBase = new MsSqlContext();
        }
        
        public List<Author> GetAuthors()
        {
            return _dataBase.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _dataBase.Authors.FirstOrDefault(author => author.Id == id);
        }

        public bool DeleteAuthorById(int id)
        {
            Author author = new Author()
            {
                Id = id
            };
            var result = _dataBase.Authors.Remove(author) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditAuthor(Author author)
        {
            var result = _dataBase.Authors.Update(author) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool CreateAuthor(Author author)
        {
            var result = _dataBase.Authors.Add(author) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public int GetAuthorIdByName(string name)
        {
            var author = _dataBase.Authors.FirstOrDefault(author => author.Name == name);
            return author.Id;
        }
    }
}