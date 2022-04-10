using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool DeleteBookById(uint id);
        public bool EditBook(Book book);
        public bool CreateBook(Book book);
    }
}