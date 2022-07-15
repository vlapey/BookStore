using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool CreateBook(string bookName, int price, string authorName);
        public bool EditBook(int bookId, string bookName, int price, string authorName);
        public bool DeleteBook(int id);
    }
}