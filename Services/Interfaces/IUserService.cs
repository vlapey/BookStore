using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public bool DeleteUserById(int id);
        public bool EditUser(User user);
        public bool CreateUser(User user);
    }
}