using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;


namespace Services
{
    public class DbUserService : IUserService
    {
        private static IMsSqlContext _database;

        public DbUserService(IMsSqlContext applicationContext)
        {
            _database = applicationContext;
        }

        public List<User> GetUsers()
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetUsers();
        }

        public User GetUserById(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetUserById(id);
        }

        public bool DeleteUserById(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.DeleteUserById(id);
        }

        public bool EditUser(User user)
        {
            MsSqlContext context = new MsSqlContext();
            return context.EditUser(user);
        }
        
        public bool CreateUser(User user)
        {
            MsSqlContext context = new MsSqlContext();
            return context.CreateUser(user);
        }
        
        public List<Book> GetUsersBooks(uint id)
        {
            MsSqlContext context = new MsSqlContext();
            return context.GetUsersBooks(id);
        }
    }
}