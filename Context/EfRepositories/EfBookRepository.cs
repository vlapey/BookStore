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

        public Book GetBookByName(string name)
        {
            var book = _dataBase.Books.FirstOrDefault(book => book.Name == name);
            return book;
        }
    }
}