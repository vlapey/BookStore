using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static IAuthorRepository AuthorRepository => new EfAuthorRepository();
        private static IBookRepository BookRepository => new EfBookRepository();
        private static IUserRepository UserRepository => new EfUserRepository();
        private static IUnitOfWork UnitOfWork => new UnitOfWork(AuthorRepository, BookRepository, UserRepository);
        public static IBookService BookService => new DbBookService(UnitOfWork);
        public static IAuthorService AuthorService => new DbAuthorService(UnitOfWork);
        public static IUserService UserService => new DbUserService(UnitOfWork);
    }
}