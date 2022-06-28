using System;
using System.Collections.Generic;
using Models;

namespace Context
{
    public class UserRepository : IUserRepository
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var userdata = MySqlContext.ToList($"SELECT * FROM users");
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

        public User GetUserById(uint id)
        {
            var userdata = MySqlContext.ToList($"SELECT * FROM users WHERE users.id = {id}");
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

        public bool DeleteUserById(uint id)
        {
            var result = MySqlContext.Execute($"DELETE FROM users WHERE users.id = {id}");
            return result > 0;
        }

        public bool EditUser(User user)
        {
            int userId = MySqlContext.Execute($"SELECT users.id FROM users WHERE users.id = '{user.Id}'");
            if (userId == -1)
            {
                return false;
            }
            var result = MySqlContext.Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                              $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
            return result > 0;
        }

        public bool CreateUser(User user)
        {
            var result = MySqlContext.Execute($"INSERT INTO `users` (`login`, `password`) " +
                                              $"VALUES ('{user.Login}', '{user.Password}')");
            return result > 0;
        }

        public List<Book> GetUsersBooks(uint id)
        {
            int userId = MySqlContext.Execute($"SELECT users.id FROM users WHERE users.id = '{id}'");
            if (userId == -1)
                return null;
            var usersbooks = new List<Book>();
            
            var booksDataFromDatabase = 
                MySqlContext.ToList($"SELECT books.id, books.name," +
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