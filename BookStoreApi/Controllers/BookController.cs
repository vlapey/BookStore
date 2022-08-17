using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using AutoMapper;
using BookStoreApi.CreateDto;
using BookStoreApi.EditDto;

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
    public bool CreateBook(CreateBookDto createBookData)
    {
        var authorId = _authorService.GetAuthorIdByName(createBookData.AuthorName);
        if (authorId == 0)
        {
            return false;
        }
        var book = _mapper.Map<Book>(createBookData);
        book.AuthorId = authorId;
        return _bookService.CreateBook(book);
    }
    
    [HttpPost]
    public bool EditBook(EditBookDto editBookData)
    {
        var authorId = _authorService.GetAuthorIdByName(editBookData.AuthorName);
        if (authorId == 0)
        {
            return false;
        }
        var book = _mapper.Map<Book>(editBookData);
        book.AuthorId = authorId;
        return _bookService.EditBook(book);
    }
    
    [HttpDelete]
    public bool DeleteBook(int id)
    {
        return _bookService.DeleteBook(id);
    }
}