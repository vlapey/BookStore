using AutoMapper;
using BookStoreApi.Dto;
using BookStoreApi.DtoWithId;
using Models;

namespace BookStoreApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
        CreateMap<UserDtoWithId, User>().ReverseMap();
        CreateMap<BookDto, Book>().ReverseMap();
        CreateMap<BookDtoWithId, Book>().ReverseMap();
        CreateMap<AuthorDto, Author>().ReverseMap();
        CreateMap<AuthorDtoWithId, Author>().ReverseMap();
    }
}