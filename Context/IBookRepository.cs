using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IBookRepository
    {
        public bool CreateBook(Book book);
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool DeleteBookById(uint id);
        public bool EditBook(Book book);
    }
}