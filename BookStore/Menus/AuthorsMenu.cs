using System;
using Models;
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
                Console.WriteLine("Вы выбрали авторский сервис\n" +
                                  "Выберите, что хотитет выполнить?\n" +
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

        private void ShowAll()
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

        private void ShowAuthorById()
        {
            Console.WriteLine("Введите Id автора, которого хотите вывести");
            int authorId = Convert.ToInt32(Console.ReadLine());
            Author author = _authorService.GetAuthorById(authorId);
            if (author == null)
            {
                Console.WriteLine("Такого id не существует");
                return;
            }
            Console.WriteLine(author);
        }

        private void ShowAuthorIdByName()
        {
            Console.WriteLine("Введите имя автора, чтобы получить его Id");
            string name = Console.ReadLine();
            int result = _authorService.GetAuthorIdByName(name);
            if (result == 0)
            {
                Console.WriteLine("Такого автора не существует");
            }
            else Console.WriteLine(result);
        }

        private void Create()
        {
            Console.WriteLine("Введите Имя");
            string authorName = Console.ReadLine();
            Author author = new Author()
            {
                Name = authorName,
            };
            var result = _authorService.CreateAuthor(author);
            if (result)
            {
                Console.WriteLine("Автор добавлен");
            }
            else Console.WriteLine("Автор не добавлен");
        }

        private void Edit()
        {
            Console.WriteLine("Введите Id автора, которого хотите поменять");
            int userId = Convert.ToInt32(Console.ReadLine());
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
                Console.WriteLine("Автор изменен");
            }
            else Console.WriteLine("Ошибка, автор не изменен");
        }

        private void Delete()
        {
            Console.WriteLine("Введите Id автора, которого хотите удалить");
            int.TryParse(Console.ReadLine(), out int id);
            if (id == 0)
            {
                Console.WriteLine("Ошибка, айди должен быть числом и максимум 10 символов");
                return;
            }
            Author author = new Author()
            {
                Id = id
            };
            bool result = _authorService.DeleteAuthorById(author);
            if (result)
            {
                Console.WriteLine("Автор удален");
            }
            else Console.WriteLine("Такого автора не существует");
        }
    }
}