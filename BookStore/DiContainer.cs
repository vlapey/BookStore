using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        public static IBookService BookService => new DbBookService();
        public static IAuthorService AuthorService => new DbAuthorService();
        public static IUserService UserService => new DbUserService();
    }
}