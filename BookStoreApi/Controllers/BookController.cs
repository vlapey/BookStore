using BookStoreApi.DtoWithId;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using BookStoreApi.Dto;
using AutoMapper;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    
    public BookController(IBookService bookService, IAuthorService authorService, IMapper mapper)
    {
        _bookService = bookService;
        _authorService = authorService;
        _mapper = mapper;
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
        var book = _mapper.Map<Book>(bookData);
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
        var book = _mapper.Map<Book>(bookData);
        return _bookService.EditBook(book);
    }
    
    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}