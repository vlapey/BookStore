using BookStoreApi.Dto;
using BookStoreApi.DtoWithId;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services.Interfaces;
using AutoMapper;

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
    public bool CreateAuthor(AuthorDto authorData)
    {
        var author = _mapper.Map<Author>(authorData);
        return _authorService.CreateAuthor(author);
    }
    
    [HttpPost]
    public bool EditAuthor(AuthorDtoWithId authorData)
    {
        var author = _mapper.Map<Author>(authorData);
        return _authorService.EditAuthor(author);
    }
    
    [HttpDelete]
    public bool DeleteAuthor(int id)
    {
        return _authorService.DeleteAuthor(id);
    }
}