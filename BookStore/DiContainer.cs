using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static readonly IMsSqlContext Database = new MsSqlContext();
        public static IBookService BookService => new DbBookService(Database);
        public static IAuthorService AuthorService => new DbAuthorService(Database);
        public static IUserService UserService => new DbUserService(Database);
        
    }
}