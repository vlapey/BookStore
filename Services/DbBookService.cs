using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;
using Services.Dto;

namespace Services
{
    public class DbBookService : IBookService
    {
        private static IBookRepository _database;

        public DbBookService(IBookRepository applicationContext)
        {
            _database = applicationContext;
        }
        
        public bool CreateBook(string bookName, int price, string authorName)
        {
            BookDto bookData = new BookDto()
            {
                BookName = bookName,
                BookPrice = price,
                AuthorName = authorName
            };
            EfAuthorRepository authorRepository = new EfAuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(bookData.AuthorName);
            if (authorId == 0)
            {
                return false;
            }
            Book book = new Book()
            {
                Name = bookData.BookName,
                Price = bookData.BookPrice,
                Author = new Author()
                {
                    Id = authorId,
                    Name = bookData.AuthorName
                }
            };
            return _database.CreateItem(book);
        }
        
        public List<Book> GetBooks()
        {
            return _database.GetItems();
        }
       
        public Book GetBookByName(string name)
        {
            return _database.GetBookByName(name);
        }
        
        public bool DeleteBook(int id)
        {
            Book book = new Book()
            {
                Id = id
            };
            return _database.DeleteItemById(book);
        }
        
        public bool EditBook(string bookName, string authorName, int price, int bookId)
        {
            BookDto bookData = new BookDto()
            {
                BookName = bookName,
                BookPrice = price,
                AuthorName = authorName
            };
            EfAuthorRepository authorRepository = new EfAuthorRepository();
            var authorId = authorRepository.GetAuthorIdByName(bookData.AuthorName);
            if (authorId == 0)
            {
                return false;
            }
            Book book = new Book()
            {
                Id = bookId,
                Name = bookData.BookName,
                Price = bookData.BookPrice,
                Author = new Author()
                {
                    Id = authorId,
                    Name = bookData.AuthorName
                }
            };
            return _database.EditItem(book);
        }
    }
}