namespace BookStoreApi.Extensions;

public static class WebApplicationExtension
{
    public static void ConfigureWebApplication(this WebApplication webApplication)
    {
        webApplication.UseHttpsRedirection();

        webApplication.UseAuthorization();

        webApplication.MapControllers();

        webApplication.Run();
    }
}