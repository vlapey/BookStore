using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;


namespace Services
{
    public class DbUserService:IUserService
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var usersdata = ApplicationContext.ToList($"SELECT * FROM users");
            foreach (var user in usersdata)
            {
                users.Add(new User(){
                    Id = uint.Parse(user[0]),
                    Login = user[1],
                    Password = user[2]
                });
            }
            return users;
        }

        public User GetUserById(uint id)
        {
            var userdata = ApplicationContext.ToList($"SELECT * FROM users WHERE users.id = {id}");
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
            var result = ApplicationContext.Execute($"DELETE FROM users WHERE users.id = {id}");
            return result > 0;
        }

        public bool EditUser(User user)
        {
            var result = ApplicationContext.Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                       $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
            return result > 0;
        }

        public bool CreateUser(User user)
        {
           var result = ApplicationContext.Execute($"INSERT INTO `users` (`login`, `password`) " + 
                                       $"VALUES ('{user.Login}', '{user.Password}')");
           return result > 0;
        }

        public List<Book> GetUsersBooks(uint id)
        {
            List<Book> usersbooks = new List<Book>();
            
            var booksDataFromDatabase = ApplicationContext.ToList($"SELECT books.id, books.name," + 
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