using System;
using Models;
using Services;

namespace BookStore.Menus
{
    public static class BooksMenu
    {
        private static DbBookService _bookService = new DbBookService();
        public static void Display()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Вы выбрали книжный сервис");
                Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех книг\n" +
                                  "2 - Показать книгу по имени\n" +
                                  "3 - Создать книгу\n" +
                                  "4 - Редактировать книгу\n" +
                                  "5 - Удалить книгу\n" +
                                  "Другое - Выйти\n");
                
                string selector = Console.ReadLine();
                switch (selector)
                {
                    case "1":
                        ShowAll();
                        break;
                    case "2":
                        ShowBookByName();
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

        private static void ShowAll()
        {
            DbBookService bookService = new DbBookService();
            foreach (var book in bookService.GetBooks())
            {
                Console.WriteLine(book);
            }
        }

        private static void ShowBookByName()
        {
            Console.WriteLine("Введите имя книги, которую хотите вывести");
            string bookName = Console.ReadLine();
            Console.WriteLine(_bookService.GetBookByName(bookName));
        }
        private static void Create()
        {
            Console.WriteLine("Введите название книги, которую хотите добавить");
            string bookName = Console.ReadLine();
            Console.WriteLine("Введите цену книги, которую хотите добавить");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите автора книги, которую хотите добавить");
            string authorName = Console.ReadLine();
            Book book = new Book()
            {
                Name = bookName,
                Price = price,
                Author = authorName
            };
            _bookService.CreateBook(book);
        }

        private static void Edit()
        {
            Console.WriteLine("Введите Id книги, которую хотите поменять");
            uint bookId = Convert.ToUInt32(Console.ReadLine());
            Console.WriteLine("Введите название книги, на которое хотите поменять");
            string bookName = Console.ReadLine();
            Console.WriteLine("Введите цену книги, на которую хотите поменять");
            int price = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите автора книги, на которого хотите поменять");
            string authorName = Console.ReadLine();
            Book book = new Book()
            {
                Id = bookId,
                Name = bookName,
                Price = price,
                Author = authorName
            };
            _bookService.EditBook(book);
        }

        private static void Delete()
        {
            Console.WriteLine("Введите Id книги, которую хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            _bookService.DeleteBookById(id);
        }
    }
}