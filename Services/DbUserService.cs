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

        public bool DeleteUserById(User user)
        {
           return _database.DeleteItemById(user);
        }

        public bool EditUser(User user)
        {
            return _database.EditItem(user);
        }
        
        public bool CreateUser(User user)
        {
           return _database.CreateItem(user);
        }
    }
}