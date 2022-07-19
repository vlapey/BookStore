namespace BookStoreApi.Extensions;

public static class WebApplicationExtension
{
    public static void ConfigureWebApplication(this WebApplication webApplication)
    {
        if (webApplication.Environment.IsDevelopment())
        {
            webApplication.UseSwagger();
            webApplication.UseSwaggerUI();
        }

        webApplication.UseHttpsRedirection();

        webApplication.UseAuthorization();

        webApplication.MapControllers();

        webApplication.Run();
    }
}