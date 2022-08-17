using Services;
using Services.Interfaces;

namespace BookStoreApi.Extensions;

public static class ServicesConfig
{
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, DbBookService>();
        services.AddScoped<IUserService, DbUserService>();
        services.AddScoped<IAuthorService, DbAuthorService>();
    }
}