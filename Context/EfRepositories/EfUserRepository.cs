using Models;

namespace Context
{
    public class EfUserRepository : GenericRepository<User>, IUserRepository
    {
        private MsSqlContext _dataBase;
        
        public EfUserRepository()
        {
            _dataBase = new MsSqlContext();
        }
    }
}