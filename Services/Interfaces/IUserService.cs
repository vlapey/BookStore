using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public bool CreateUser(string login, string password);
        public bool EditUser(int userId, string login, string password);
        public bool DeleteUser(int id);
    }
}