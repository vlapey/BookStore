using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using AutoMapper;
using BookStoreApi.CreateDto;
using BookStoreApi.EditDto;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    private readonly IMapper _mapper;
    
    public AuthorController(IAuthorService authorService, IMapper mapper)
    {
        _authorService = authorService;
        _mapper = mapper;
    }

    [HttpGet]
    public IEnumerable<Author> GetAllAuthors()
    {
        return _authorService.GetAuthors();
    }
    
    [HttpGet]
    public Author GetAuthorById(int id)
    {
        return _authorService.GetAuthorById(id);
    }
    
    [HttpGet]
    public int GetAuthorIdByName(string name)
    {
        return _authorService.GetAuthorIdByName(name);
    }
    
    [HttpPost]
    public bool CreateAuthor(CreateAuthorDto createAuthorData)
    {
        var author = _mapper.Map<Author>(createAuthorData);
        return _authorService.CreateAuthor(author);
    }
    
    [HttpPost]
    public bool EditAuthor(EditAuthorDto editAuthorData)
    {
        var author = _mapper.Map<Author>(editAuthorData);
        return _authorService.EditAuthor(author);
    }
    
    [HttpDelete]
    public bool DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);
    }
}