using Models;

namespace Context
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        public Book GetBookByName(string name);
    }
}