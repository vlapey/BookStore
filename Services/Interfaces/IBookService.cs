using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool CreateBook(Book book);
        public bool EditBook(Book book);
        public bool DeleteBook(int id);
    }
}