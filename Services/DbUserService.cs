using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;


namespace Services
{
    public class DbUserService : IUserService
    {
        private static IApplicationContext _database;

        public DbUserService(IApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        //проверка есть
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var userdata = _database.ToList($"SELECT * FROM users");
            if (userdata.Count == 0)
            {
                return null;
            }

            foreach (var user in userdata)
            {
                users.Add(new User()
                {
                    Id = uint.Parse(user[0]),
                    Login = user[1],
                    Password = user[2]
                });
            }

            return users;
        }

        //прроверка есть
        public User GetUserById(uint id)
        {
            var userdata = _database.ToList($"SELECT * FROM users WHERE users.id = {id}");
            if (userdata.Count == 0)
            {
                return null;
            }
            User user = new User()
            {
                Id = id,
                Login = userdata[0][1],
                Password = userdata[0][2]
            };
            return user;
        }

        //проверка есть
        public bool DeleteUserById(uint id)
        {
            var result = _database.Execute($"DELETE FROM users WHERE users.id = {id}");
            return result > 0;
        }

        //проверка есть
        public bool EditUser(User user)
        {
            int userId = _database.Execute($"SELECT users.id FROM users WHERE users.id = '{user.Id}'");
            if (userId == -1)
            {
                return false;
            }
            var result = _database.Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                           $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
            return result > 0;
        }
        
        //проверка есть
        public bool CreateUser(User user)
        {
            var result = _database.Execute($"INSERT INTO `users` (`login`, `password`) " +
                                           $"VALUES ('{user.Login}', '{user.Password}')");
            return result > 0;
        }

        //проверка есть
        public List<Book> GetUsersBooks(uint id)
        {
            int userId = _database.Execute($"SELECT users.id FROM users WHERE users.id = '{id}'");
            if (userId == -1)
                return null;
            var usersbooks = new List<Book>();
            
            var booksDataFromDatabase = _database
                .ToList($"SELECT books.id, books.name," +
                        $" books.price, authors.name FROM users_to_books" +
                        $" LEFT JOIN books ON users_to_books.books_id = books.id" +
                        $" LEFT JOIN authors ON books.authors_id = authors.id WHERE users_id = {id}");

            foreach (var bookAsStringsArray in booksDataFromDatabase)
            {
                usersbooks.Add(new Book()
                {
                    Id = Convert.ToUInt32(bookAsStringsArray[0]),
                    Name = bookAsStringsArray[1],
                    Price = Convert.ToInt32(bookAsStringsArray[2]),
                    Author = bookAsStringsArray[3]
                });
            }
            return usersbooks;
        }
    }
}