using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class EfBookRepository : IBookRepository
    {
        private MsSqlContext _dataBase;
        
        public EfBookRepository()
        {
            _dataBase = new MsSqlContext();
        }
        
        public bool CreateBook(Book book)
        {
            var result = _dataBase.Books.Add(book) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public List<Book> GetBooks()
        {
            return _dataBase.Books.ToList();
        }

        public Book GetBookByName(string name)
        {
            var book = _dataBase.Books.FirstOrDefault(book => book.Name == name);
            return book;
        }

        public bool DeleteBookById(int id)
        {
            Book book = new Book()
            {
                Id = id
            };
            var result = _dataBase.Books.Remove(book) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditBook(Book book)
        {
            var result = _dataBase.Books.Update(book) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}