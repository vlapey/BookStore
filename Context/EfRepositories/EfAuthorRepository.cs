using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class EfAuthorRepository : GenericRepository<Author>, IAuthorRepository
    {
        private MsSqlContext _dataBase;
        
        public EfAuthorRepository()
        {
            _dataBase = new MsSqlContext();
        }
        
        public List<Author> GetItems()
        {
            return _dataBase.Set<Author>().ToList();
        }

        public int GetAuthorIdByName(string name)
        {
            var author = _dataBase.Authors.FirstOrDefault(author => author.Name == name);
            return author.Id;
        }
        
        public Author GetItemById(int id)
        {
            return _dataBase.Set<Author>().Find(id);
        }
        
        public bool CreateItem(Author item)
        {
            var result = _dataBase.Set<Author>().Add(item) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditItem(Author item)
        {
            var result = _dataBase.Set<Author>().Update(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
        
        public bool DeleteItemById(Author item)
        {
            var result = _dataBase.Set<Author>().Remove(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}