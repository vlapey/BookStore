using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public void DeleteBookById(uint id);
        public void EditBook();
        public void CreateBook(Book book);
    }
}