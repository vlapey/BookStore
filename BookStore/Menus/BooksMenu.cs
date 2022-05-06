using System;
using System.Threading.Channels;
using Models;
using Services;
using Services.Interfaces;

namespace BookStore.Menus
{
    public class BooksMenu
    {
        private static IBookService _bookService;
        public BooksMenu(IBookService bookService)
        {
            _bookService = bookService;
        }
        public void Display()
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
        //проверка есть
        private void ShowAll()
        {
            if (_bookService.GetBooks() == null)
            {
                Console.WriteLine("Книги еще не добавлены");
                return;
            }
            foreach (var book in _bookService.GetBooks())
            {
                Console.WriteLine(book);
            }
        }
        //проверка есть
        private void ShowBookByName()
        {
            Console.WriteLine("Введите имя книги, которую хотите вывести");
            string bookName = Console.ReadLine();
            Book book = _bookService.GetBookByName(bookName);
            if (book == null)
            {
                Console.WriteLine("Такой книги не существует\n");
            }
            else Console.WriteLine(book);
        }
        //проверка есть
        private void Create()
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
            bool result = _bookService.CreateBook(book);
            if (result)
            {
                Console.WriteLine("Книга добавлена");
            }
            else Console.WriteLine("Ошибка, книга не добавлена");
        }
        //проверка есть
        private void Edit()
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
            bool result = _bookService.EditBook(book);
            if (result)
            {
                Console.WriteLine("Книга изменена");
            }
            else Console.WriteLine("Ошибка, книга не изменена, проверьте введенные данные");
        }
        //проверка есть
        private void Delete()
        {
            Console.WriteLine("Введите Id книги, которую хотите удалить");
            uint id = Convert.ToUInt32(Console.ReadLine());
            bool result = _bookService.DeleteBookById(id);
            if (result)
            {
                Console.WriteLine("Книга успешно удалена");
            }
            else Console.WriteLine("Такой книги не существует");
        }
    }
}