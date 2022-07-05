using System.Collections.Generic;
using Models;
using Services.Dto;

namespace Services.Interfaces
{
    public interface IBookService
    {
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool DeleteBookById(int id);
        public bool EditBook(BookDto bookData, int bookId);
        public bool CreateBook(BookDto bookData);
    }
}