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
                                  "3 - Показать книги пользователя\n" +
                                  "4 - Создать пользователя\n" +
                                  "5 - Редактировать пользователя\n" +
                                  "6 - Удалить пользователя\n" +
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
        
        
        public void ShowAll()
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
        
        
        public void ShowUserById()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите вывести");
            uint userId = Convert.ToUInt32(Console.ReadLine());
            User user = _userService.GetUserById(userId);
            if (user == null)
            {
                Console.WriteLine("Такого id не существует");
                return;
            }
            Console.WriteLine(user);
        }
        
       
        public void ShowBooksOfUser()
        {
            Console.WriteLine("Введите Id пользователя, книги которого хотите вывести");
            uint userId = Convert.ToUInt32(Console.ReadLine());
            var result = _userService.GetUsersBooks(userId);
            if (result == null)
            {
                Console.WriteLine("Ошибка, данного пользователя не существует");
                return;
            }
            foreach (var book in result)
            {
                Console.WriteLine(book);
            }
        }
        
        
        public void Create()
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
        
        
        public void Edit()
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
            bool result = _userService.EditUser(user);
            if (result)
            {
                Console.WriteLine("Пользователь изменен");
            }
            else Console.WriteLine("Ошибка, пользователь не изменен");
        }

        
        public void Delete()
        {
            Console.WriteLine("Введите Id пользователя, которого хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            bool result = _userService.DeleteUserById(id);
            if (result)
            {
                Console.WriteLine("Пользователь удален");
            }
            else Console.WriteLine("Такого пользователя не существует");
        }
    }
}