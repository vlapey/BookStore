using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public bool CreateUser(User user);
        public bool EditUser(User user);
        public bool DeleteUser(int id);
    }
}