using BookStoreApi.Dto;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _authorService;
    
    public AuthorController(IAuthorService authorService)
    {
        _authorService = authorService;
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
    public bool CreateAuthor(AuthorDto author)
    {
        return _authorService.CreateAuthor(author.AuthorName);
    }
    
    [HttpPost]
    public bool EditAuthor(AuthorDto author)
    {
        return _authorService.EditAuthor(author.AuthorId, author.AuthorName);
    }
    
    [HttpDelete]
    public bool DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);
    }
}