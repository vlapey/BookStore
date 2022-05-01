using System;
using Models;
using Services;
using Services.Interfaces;

namespace BookStore.Menus
{
    public class AuthorsMenu
    {
        private static IAuthorService _authorService;

        public AuthorsMenu(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public void Display()
        {
            while (true)
            {
                Console.WriteLine("\nВы выбрали авторский сервис");
                Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех авторов\n" +
                                  "2 - Показать автора по Id\n" +
                                  "3 - Показать Id автора по имени\n" +
                                  "4 - Создать автора\n" +
                                  "5 - Редактировать автора\n" +
                                  "6 - Удалить автора\n" +
                                  "Другое - Вернуться в главное меню\n");

                string selector = Console.ReadLine();
                switch (selector)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowAuthorById();
                        break;
                    case "3":
                        ShowAuthorIdByName();
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
                        return;
                }
            }
        }
        //проверка есть
        public void ShowAll()
        {
            if (_authorService.GetAuthors() == null)
            {
                Console.WriteLine("Авторы еще не добавлены");
                return;
            }
            foreach (var author in _authorService.GetAuthors())
            {
                Console.WriteLine(author);
            }
            
        }
        // проверка есть 
        public void ShowAuthorById()
        {
            Console.WriteLine("Введите Id автора, которого хотите вывести");
            uint authorId = Convert.ToUInt32(Console.ReadLine());
            Author author = _authorService.GetAuthorById(authorId);
            if (author == null)
            {
                Console.WriteLine("Такого id не существует");
                return;
            }
            Console.WriteLine(author);
        }
        //todo: доделать проверку return 
        public void ShowAuthorIdByName()
        {
            Console.WriteLine("Введите имя автора, чтобы получить его Id");
            string name = Console.ReadLine();
            uint result = _authorService.GetAuthorIdByName(name);
            if (result == 0)
            {
                Console.WriteLine("Такого автора не существует");
            }
            else Console.WriteLine(result);
        }
        //проверка есть
        public void Create()
        {
            Console.WriteLine("Введите Имя");
            string authorName = Console.ReadLine();
            Author author = new Author()
            {
                Name = authorName,
            };
            bool result = _authorService.CreateAuthor(author);
            if (result)
            {
                Console.WriteLine("Автор успешно добавлен");
            }
            else Console.WriteLine("Автор не добавлен");
        }
        //проверка есть
        public void Edit()
        {
            Console.WriteLine("Введите Id автора, которого хотите поменять");
            uint userId = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Введите Имя автора, на которое хотите поменять");
            string authorName = Console.ReadLine();
            Author author = new Author()
            {
                Id = userId,
                Name = authorName,
            };
            bool result = _authorService.EditAuthor(author);
            if (result)
            {
                Console.WriteLine("Автор успешно изменен");
            }
            else Console.WriteLine("Такого автора не существует");
        }
        //проверка есть 
        public void Delete()
        {
            Console.WriteLine("Введите Id автора, которого хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            bool result = _authorService.DeleteAuthorById(id);
            if (result)
            {
                Console.WriteLine("Автор успешно удален");
            }
            else Console.WriteLine("Такого автора не существует");
        }
    }
}