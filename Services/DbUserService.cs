using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbUserService : IUserService
    {
        private static IUserRepository _database;

        public DbUserService(IUserRepository applicationContext)
        {
            _database = applicationContext;
        }

        public List<User> GetUsers()
        {
            return _database.GetItems();
        }

        public User GetUserById(int id)
        {
            return _database.GetItemById(id);
        }

        public bool DeleteUser(int id)
        {
            User user = new User()
            {
                Id = id
            };
           return _database.DeleteItemById(user);
        }

        public bool EditUser(int userId, string login, string password)
        {
            User user = new User()
            {
                Id = userId,
                Login = login,
                Password = password,
            };
            return _database.EditItem(user);
        }
        
        public bool CreateUser(string login, string password)
        {
            User user = new User()
            {
                Login = login,
                Password = password,
            }; 
           return _database.CreateItem(user);
        }
    }
}