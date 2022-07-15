using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool DeleteBook(int id);
        public bool EditBook(string bookName, string authorName, int price, int bookId);
        public bool CreateBook(string bookName, int price, string authorName);
    }
}