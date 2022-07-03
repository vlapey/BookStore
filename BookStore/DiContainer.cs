using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static readonly IAuthorRepository AuthorRepository = new AuthorRepository();
        private static readonly IBookRepository BookRepository = new BookRepository();
        private static readonly IUserRepository UserRepository = new UserRepository();
        public static IBookService BookService => new DbBookService(BookRepository);
        public static IAuthorService AuthorService => new DbAuthorService(AuthorRepository);
        public static IUserService UserService => new DbUserService(UserRepository);
    }
}