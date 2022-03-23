using System.Collections.Generic;
using BookStore;

namespace Services.Interfaces
{
    public interface IUserService
    {
        public List<User> GetUsers();
        public User GetUserById(uint id);
        public void DeleteUserById(uint id);
        public void EditUser(User user);
    }
}