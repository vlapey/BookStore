using System.Linq;
using Models;

namespace Context
{
    public class EfBookRepository : GenericRepository<Book>, IBookRepository
    {
        public EfBookRepository(MsSqlContext context) : base(context) {}
        public Book GetBookByName(string name)
        {
            var book = _dataBase.Books.FirstOrDefault(book => book.Name == name);
            return book;
        }
    }
}