using System.Collections.Generic;
using System.Linq;
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
        public List<User> GetItems()
        {
            return _dataBase.Set<User>().ToList();
        }

        public User GetItemById(int id)
        {
            return _dataBase.Set<User>().Find(id);
        }
        
        public bool CreateItem(User item)
        {
            var result = _dataBase.Set<User>().Add(item) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditItem(User item)
        {
            var result = _dataBase.Set<User>().Update(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
        
        public bool DeleteItemById(User item)
        {
            var result = _dataBase.Set<User>().Remove(item) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}