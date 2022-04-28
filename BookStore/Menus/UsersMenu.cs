using Services;
using System;
using Models;
using Services.Interfaces;

namespace BookStore.Menus
{
    public static class UsersMenu
    {
        private static IUserService _userService = DiContainer.UserService;
        public static void Display()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Вы выбрали пользовательский сервис");
                Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех пользователей\n" +
                                  "2 - Показать пользователя по Id\n" +
                                  "3 - Показать книги пользователя\n" +
                                  "4 - Создать пользователя\n" +
                                  "5 - Редактировать пользователя\n" +
                                  "6 - Удалить пользователя" +
                                  "Другое - Выйти\n");
                
                string selector = Console.ReadLine();
                switch (selector)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowUserById();
                        break;
                    case "3":
                        ShowBooksOfUser();
                        break;
                    case "4":
                        Create();
                        break;
                    case "5":
                        Edit();
                        break;
                    case "6":
                        Delete();
                        break;
                    default:
                        exit = true;
                        break;
                }   
            }
        }
        public static void ShowAll()
        {
            DbUserService userService = new DbUserService();
            foreach (var user in userService.GetUsers())
            {
                Console.WriteLine(user);
            }
        }

        public static void ShowUserById()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите вывести");
            uint userId = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(_userService.GetUserById(userId));
        }

        public static void ShowBooksOfUser()
        {
            Console.WriteLine("Введите Id пользователя, книги которого хотите вывести");
            uint userId = Convert.ToUInt32(Console.ReadLine());
            foreach (var book in _userService.GetUsersBooks(userId))
            {
                Console.WriteLine(book);
            }
        }
        public static void Create()
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
            _userService.CreateUser(user);
        }

        public static void Edit()
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
            _userService.EditUser(user);
        }

        public static void Delete()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            _userService.DeleteUserById(id);
        }
    }
}