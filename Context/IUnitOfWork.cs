namespace Context
{
    public interface IUnitOfWork
    {
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}