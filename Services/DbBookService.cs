using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService : IBookService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbBookService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public List<Book> GetBooks()
        {
            return _unitOfWork.BookRepository.GetItems();
        }
       
        public Book GetBookByName(string name)
        {
            return _unitOfWork.BookRepository.GetBookByName(name);
        }

        public bool CreateBook(Book book)
        {
            return _unitOfWork.BookRepository.CreateItem(book);
        }
        
        public bool EditBook(Book book)
        {
            return _unitOfWork.BookRepository.EditItem(book);
        }
        
        public bool DeleteBook(int id)
        {
            return _unitOfWork.BookRepository.DeleteItem(id);
        }
    }
}