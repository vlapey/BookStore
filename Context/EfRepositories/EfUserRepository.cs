using Models;

namespace Context
{
    public class EfUserRepository : GenericRepository<User>, IUserRepository
    {
        public EfUserRepository(MsSqlContext context) : base(context) {}
    }
}