using BookStoreApi.Dto;
using BookStoreApi.DtoWithId;
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
    public bool CreateAuthor(AuthorDto authorData)
    {
        Author author = new Author()
        {
            Name = authorData.AuthorName
        };
        return _authorService.CreateAuthor(author);
    }
    
    [HttpPost]
    public bool EditAuthor(AuthorDtoWithId authorData)
    {
        Author author = new Author()
        {
            Id = authorData.AuthorId,
            Name = authorData.AuthorName
        };
        return _authorService.EditAuthor(author);
    }
    
    [HttpDelete]
    public bool DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);
    }
}