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
            return _database.GetUsers();
        }

        public User GetUserById(int id)
        {
            return _database.GetUserById(id);
        }

        public bool DeleteUserById(int id)
        {
           return _database.DeleteUserById(id);
        }

        public bool EditUser(User user)
        {
            return _database.EditUser(user);
        }
        
        public bool CreateUser(User user)
        {
           return _database.CreateUser(user);
        }
    }
}