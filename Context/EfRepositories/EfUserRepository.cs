using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class EfUserRepository : IUserRepository
    {
        private MsSqlContext _dataBase;
        
        public EfUserRepository()
        {
            _dataBase = new MsSqlContext();
        }
        public List<User> GetUsers()
        {
            return _dataBase.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _dataBase.Users.FirstOrDefault(user => user.Id == id);
        }

        public bool DeleteUserById(int id)
        {
            User user = new User()
            {
                Id = id
            };
            var result = _dataBase.Users.Remove(user) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool EditUser(User user)
        {
            var result = _dataBase.Users.Update(user) != null;
            _dataBase.SaveChanges();
            return result;
        }

        public bool CreateUser(User user)
        {
            var result = _dataBase.Users.Add(user) != null;
            _dataBase.SaveChanges();
            return result;
        }
    }
}