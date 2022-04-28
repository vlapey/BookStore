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
        //todo: проверка через count == 0
        public void ShowAll()
        {
            foreach (var author in _authorService.GetAuthors())
            {
                Console.WriteLine(author);
            }
        }

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

        public void ShowAuthorIdByName()
        {
            Console.WriteLine("Введите имя автора, чтобы получить его Id");
            string name = Console.ReadLine();
            Console.WriteLine(_authorService.GetAuthorIdByName(name));
        }
        public void Create()
        {
            Console.WriteLine("Введите Имя");
            string authorName = Console.ReadLine();
            Author author = new Author()
            {
                Name = authorName,
            };
            _authorService.CreateAuthor(author);
        }

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
            _authorService.EditAuthor(author);
        }

        public void Delete()
        {
            Console.WriteLine("Введите Id автора, которого хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            _authorService.DeleteAuthorById(id);
        }
    }
}