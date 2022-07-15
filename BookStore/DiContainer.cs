using Context;
using Services;
using Services.Interfaces;

namespace BookStore
{
    public static class DiContainer
    {
        private static IUnitOfWork UnitOfWork => new UnitOfWork();
        public static IBookService BookService => new DbBookService(UnitOfWork);
        public static IAuthorService AuthorService => new DbAuthorService(UnitOfWork);
        public static IUserService UserService => new DbUserService(UnitOfWork);
    }
}