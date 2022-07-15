using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(int id);
        public bool DeleteUser(int id);
        public bool EditUser(int userId, string login, string password);
        public bool CreateUser(string login, string password);
    }
}