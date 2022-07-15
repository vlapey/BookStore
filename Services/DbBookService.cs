using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;
using Services.Dto;

namespace Services
{
    public class DbBookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public bool CreateBook(string bookName, int price, string authorName)
        {
            BookDto bookData = new BookDto()
            {
                BookName = bookName,
                BookPrice = price,
                AuthorName = authorName
            };
            var authorId = _unitOfWork.AuthorRepository.GetAuthorIdByName(bookData.AuthorName);
            if (authorId == 0)
            {
                return false;
            }
            Book book = new Book()
            {
                Name = bookData.BookName,
                Price = bookData.BookPrice,
                AuthorId = authorId,
            };
            return _unitOfWork.BookRepository.CreateItem(book);
        }
        
        public List<Book> GetBooks()
        {
            return _unitOfWork.BookRepository.GetItems();
        }
       
        public Book GetBookByName(string name)
        {
            return _unitOfWork.BookRepository.GetBookByName(name);
        }
        
        public bool DeleteBook(int id)
        {
            return _unitOfWork.BookRepository.DeleteItemById(id);
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
                AuthorId = authorId
            };
            return _unitOfWork.BookRepository.EditItem(book);
        }
    }
}