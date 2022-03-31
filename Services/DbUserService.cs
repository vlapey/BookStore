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

        public void DeleteUserById(uint id)
        {
            ApplicationContext.Execute($"DELETE FROM users WHERE users.id = {id}");
        }

        public void EditUser(User user)
        {
            ApplicationContext.Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                       $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
        }

        public void CreateUser(User user)
        {
            ApplicationContext.Execute($"INSERT INTO `users` (`login`, `password`) " + 
                                       $"VALUES ('{user.Login}', '{user.Password}')");
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

        public void UserManager()
        {
            int selector = int.Parse(Console.ReadLine());
            switch (selector)
            {
                case 1:
                {
                    DbUserService userService = new DbUserService();
                    foreach (var user in userService.GetUsers())
                    {
                        Console.WriteLine(user);
                    }
                    break;
                }
                
                case 2:
                {
                    Console.WriteLine("Введите Id пользователя, которого хотите вывести");
                    uint userId = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine(GetUserById(userId));
                    break;
                }

                case 3:
                {
                    Console.WriteLine("Введите Id пользователя, книги которого хотите вывести");
                    uint userId = Convert.ToUInt32(Console.ReadLine());
                    foreach (var book in GetUsersBooks(userId))
                    {
                        Console.WriteLine(book);
                    }
                    break;
                }
                
                case 4:
                {
                    Console.WriteLine("Введите Login");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль");
                    string password = Console.ReadLine();
                    User user = new User()
                    {
                        Login = login,
                        Password = password,
                    };
                    CreateUser(user);
                    break;
                }

                case 5:
                {
                    Console.WriteLine("Введите Id пользователя, которого хотите поменять");
                    uint userId = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Введите Login пользователя, на который хотите поменять");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль пользователя, на который хотите поменять");
                    string password = Console.ReadLine();
                    User user = new User()
                    {
                        Id = userId,
                        Login = login,
                        Password = password,
                    };
                    EditUser(user);
                    break;
                }
                
                case 6:
                {
                    Console.WriteLine("Введите Id пользователя, которого хотите удалить");
                    uint id = Convert.ToUInt32(Console.ReadLine());
                    DeleteUserById(id);
                    break;
                }
            }
        }
    }
}