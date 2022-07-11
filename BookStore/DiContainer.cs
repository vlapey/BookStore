using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static  IAuthorRepository AuthorRepository => new EfAuthorRepository();
        private static  IBookRepository BookRepository => new EfBookRepository();
        private static  IUserRepository UserRepository => new EfUserRepository();
        public static IBookService BookService => new DbBookService(BookRepository);
        public static IAuthorService AuthorService => new DbAuthorService(AuthorRepository);
        public static IUserService UserService => new DbUserService(UserRepository);
    }
}