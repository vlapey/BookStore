using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class EfBookRepository : GenericRepository<Book>, IBookRepository
    {
        private MsSqlContext _dataBase;
        
        public EfBookRepository()
        {
            _dataBase = new MsSqlContext();
        }
        
        public List<Book> GetItems()
        {
            return _dataBase.Set<Book>().ToList();
        }
        
        public Book GetBookByName(string name)
        {
            var book = _dataBase.Books.FirstOrDefault(book => book.Name == name);
            return book;
        }
        
        public bool CreateItem(Book item)
        {
            var result = _dataBase.Set<Book>().Add(item) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditItem(Book item)
        {
            var result = _dataBase.Set<Book>().Update(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
        
        public bool DeleteItemById(Book item)
        {
            var result = _dataBase.Set<Book>().Remove(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}