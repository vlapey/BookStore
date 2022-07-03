using System;
using Models;
using Services.Interfaces;

namespace BookStore.Menus
{
    public class UsersMenu
    {
        private static IUserService _userService;
        public UsersMenu(IUserService userService)
        {
            _userService = userService;
        }
        public void Display()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Вы выбрали пользовательский сервис\n" +
                                  "Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех пользователей\n" +
                                  "2 - Показать пользователя по Id\n" +
                                  "3 - Создать пользователя\n" +
                                  "4 - Редактировать пользователя\n" +
                                  "5 - Удалить пользователя\n" +
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
                        Create();
                        break;
                    case "4":
                        Edit();
                        break;
                    case "5":
                        Delete();
                        break;
                    default:
                        exit = true;
                        break;
                }   
            }
        }

        private void ShowAll()
        {
            if (_userService.GetUsers() == null)
            {
                Console.WriteLine("Пользователи еще не добавлены");
                return;
            }
            foreach (var user in _userService.GetUsers())
            {
                Console.WriteLine(user);
            }
        }

        private void ShowUserById()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите вывести");
            int userId = Convert.ToInt32(Console.ReadLine());
            User user = _userService.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("Такого id не существует");
                return;
            }
            Console.WriteLine(user);
        }

        private void Create()
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
            bool result = _userService.CreateUser(user);
            if (result)
            {
                Console.WriteLine("Пользователь добавлен");
            }
            else Console.WriteLine("Ошибка, пользователь не добавлен");
        }

        private void Edit()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите поменять");
            int userId = Convert.ToInt32(Console.ReadLine());
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
            bool result = _userService.EditUser(user);
            if (result)
            {
                Console.WriteLine("Пользователь изменен");
            }
            else Console.WriteLine("Ошибка, пользователь не изменен");
        }

        private void Delete()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите удалить");
            int id = Convert.ToInt32(Console.ReadLine());
            bool result = _userService.DeleteUserById(id);
            if (result)
            {
                Console.WriteLine("Пользователь удален");
            }
            else Console.WriteLine("Такого пользователя не существует");
        }
    }
}