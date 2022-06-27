using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static readonly IRepository Database = new MySqlRepository();
        public static IBookService BookService => new DbBookService(Database);
        public static IAuthorService AuthorService => new DbAuthorService(Database);
        public static IUserService UserService => new DbUserService(Database);
        
    }
}