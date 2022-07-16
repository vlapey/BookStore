using BookStoreApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    
    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    public IEnumerable<Book> GetAllBooks()
    {
        return _bookService.GetBooks();
    }
    
    [HttpGet]
    public Book GetBookByName(string name)
    {
        return _bookService.GetBookByName(name);
    }
    
    [HttpPost]
    public bool CreateBook(BookDto book)
    {
        return _bookService.CreateBook(book.BookName, book.BookPrice, book.AuthorName);
    }
    
    [HttpPost]
    public bool EditBook(BookDto book)
    {
        return _bookService.EditBook(book.BookId, book.BookName, book.BookPrice, book.AuthorName);
    }
    
    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}