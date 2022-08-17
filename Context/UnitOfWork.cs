namespace Context
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(IAuthorRepository authorRepository, IBookRepository bookRepository, 
            IUserRepository userRepository)
        {
            AuthorRepository = authorRepository;
            BookRepository = bookRepository;
            UserRepository = userRepository;
        }
        
        public IAuthorRepository AuthorRepository { get; }
        public IBookRepository BookRepository { get; }
        public IUserRepository UserRepository { get; }
    }
}