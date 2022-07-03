using System.Collections.Generic;
using Models;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(uint id);
        public bool DeleteUserById(uint id);
        public bool EditUser(User user);
        public bool CreateUser(User user);
        public List<Book> GetUsersBooks(uint id);
    }
}