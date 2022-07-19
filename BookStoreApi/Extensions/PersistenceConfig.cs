using Context;

namespace BookStoreApi.Extensions;

public static class PersistenceConfig
{
    public static void ConfigurePersistence(this IServiceCollection services)
    {
        services.AddScoped<IAuthorRepository, EfAuthorRepository>();
        services.AddScoped<IBookRepository, EfBookRepository>();
        services.AddScoped<IUserRepository, EfUserRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}