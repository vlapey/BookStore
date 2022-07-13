namespace Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public IAuthorRepository AuthorRepository => new EfAuthorRepository();
        public IBookRepository BookRepository => new EfBookRepository();
        public IUserRepository UserRepository => new EfUserRepository();
    }
}