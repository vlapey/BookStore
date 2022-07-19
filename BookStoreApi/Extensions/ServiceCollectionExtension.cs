using AutoMapper;
using Context;
using Services;
using Services.Interfaces;

namespace BookStoreApi.Extensions;

public static class ServiceCollectionExtension
{
    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        });
        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }

    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, DbBookService>();
        services.AddScoped<IUserService, DbUserService>();
        services.AddScoped<IAuthorService, DbAuthorService>();
    }

    public static void ConfigurePersistence(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}