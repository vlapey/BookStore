using System.Collections.Generic;
using Context;
using Models;
using Services.Dto.Interfaces;

namespace Services.Dto
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

        public User GetUserById(uint id)
        {
            return _database.GetUserById(id);
        }

        public bool DeleteUserById(uint id)
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
        
        public List<Book> GetUsersBooks(uint id)
        {
            return _database.GetUsersBooks(id);
        }
    }
}