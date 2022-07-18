using BookStoreApi.DtoWithId;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using BookStoreApi.Dto;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    
    public BookController(IBookService bookService, IAuthorService authorService)
    {
        _bookService = bookService;
        _authorService = authorService;
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
    public bool CreateBook(BookDto bookData)
    {
        var authorId = _authorService.GetAuthorIdByName(bookData.AuthorName);
        if (authorId == 0)
        {
            return false;
        }
        Book book = new Book()
        {
            Name = bookData.BookName,
            Price = bookData.BookPrice,
            AuthorId = authorId
        };
        return _bookService.CreateBook(book);
    }
    
    [HttpPost]
    public bool EditBook(BookDtoWithId bookData)
    {
        var authorId = _authorService.GetAuthorIdByName(bookData.AuthorName);
        if (authorId == 0)
        {
            return false;
        }
        Book book = new Book()
        {
            Id = bookData.BookId,
            Name = bookData.BookName,
            Price = bookData.BookPrice,
            AuthorId = authorId
        };
        return _bookService.EditBook(book);
    }
    
    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}