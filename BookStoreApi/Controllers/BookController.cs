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
    public bool CreateBook(string bookName, int price, string authorName)
    {
        return _bookService.CreateBook(bookName, price, authorName);
    }
    
    [HttpPost]
    public bool EditBook(int bookId, string bookName,int price, string authorName)
    {
        return _bookService.EditBook(bookId, bookName, price, authorName);
    }
    
    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}