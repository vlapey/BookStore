using AutoMapper;
using BookStoreApi.CreateDto;
using BookStoreApi.EditDto;
using Models;

namespace BookStoreApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CreateUserDto, User>().ReverseMap();
        CreateMap<EditUserDto, User>().ReverseMap();
        CreateMap<CreateBookDto, Book>().ReverseMap();
        CreateMap<EditBookDto, Book>().ReverseMap();
        CreateMap<CreateAuthorDto, Author>().ReverseMap();
        CreateMap<EditAuthorDto, Author>().ReverseMap();
    }
}