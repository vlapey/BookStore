using AutoMapper;
using BookStoreApi.Dto;
using Models;

namespace BookStoreApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<UserDto, User>().ReverseMap();
    }
}