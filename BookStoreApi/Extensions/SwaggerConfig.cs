namespace BookStoreApi.Extensions;

public static class SwaggerConfig
{
    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void ConfigureSwaggerWebApplication(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }
    }
}