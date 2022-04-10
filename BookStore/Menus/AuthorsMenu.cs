using System;
using Models;
using Services;

namespace BookStore.Menus
{
    public class AuthorsMenu
    {
        private static DbAuthorService _authorService = new DbAuthorService();
        public static void Display()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Вы выбрали авторский сервис");
                Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех авторов\n" +
                                  "2 - Показать автора по Id\n" +
                                  "3 - Показать Id автора по имени\n" +
                                  "4 - Создать автора\n" +
                                  "5 - Редактировать автора\n" +
                                  "6 - Удалить автора\n" +
                                  "Другое - Выйти\n");
                
                int selector = int.Parse(Console.ReadLine());
                switch (selector)
                {
                    case 1:
                        ShowAll();
                        break;
                    case 2:
                        ShowAuthorById();
                        break;
                    case 3:
                        ShowAuthorIdByName();
                        break;
                    case 4:
                        Create();
                        break;
                    case 5:
                        Edit();
                        break;
                    case 6:
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
            DbAuthorService authorService = new DbAuthorService();
            foreach (var author in authorService.GetAuthors())
            {
                Console.WriteLine(author);
            }
        }

        public static void ShowAuthorById()
        {
            Console.WriteLine("Введите Id автора, которого хотите вывести");
            uint authorId = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine(_authorService.GetAuthorById(authorId));
        }

        public static void ShowAuthorIdByName()
        {
            Console.WriteLine("Введите имя автора, чтобы получить его Id");
            string name = Console.ReadLine();
            Console.WriteLine(_authorService.GetAuthorIdByName(name));
        }
        public static void Create()
        {
            Console.WriteLine("Введите Имя");
            string authorName = Console.ReadLine();
            Author author = new Author()
            {
                Name = authorName,
            };
            _authorService.CreateAuthor(author);
        }

        public static void Edit()
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

        public static void Delete()
        {
            Console.WriteLine("Введите Id автора, которого хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            _authorService.DeleteAuthorById(id);
        }
    }
}