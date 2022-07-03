﻿using System;
using Models;
using Services.Dto;
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
                Console.WriteLine("Вы выбрали книжный сервис\n" +
                                  "Выберите, что хотитет выполнить?\n" +
                                  "1 - Показать список всех книг\n" +
                                  "2 - Показать книгу по имени\n" +
                                  "3 - Создать книгу\n" +
                                  "4 - Редактировать книгу\n" +
                                  "5 - Удалить книгу\n" +
                                  "Другое - Выйти");
                
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
        
        private void Create()
        {
            Console.WriteLine("Введите название книги, которую хотите добавить");
            string bookName = Console.ReadLine();
            Console.WriteLine("Введите цену книги, которую хотите добавить");
            int.TryParse(Console.ReadLine(), out int price);
            if (price == 0)
            {
                Console.WriteLine("Ошибка, цена должна быть числом и максимум 10 символов");
                return;
            }
            Console.WriteLine("Введите автора книги, которую хотите добавить");
            string authorName = Console.ReadLine();
            BookDto bookData = new BookDto()
            {
                BookName = bookName,
                BookPrice = price,
                AuthorName = authorName
            };
            bool result = _bookService.CreateBook(bookData);
            if (result)
            {
                Console.WriteLine("Книга добавлена");
            }
            else Console.WriteLine("Ошибка, книга не добавлена");
        }
        
        private void Edit()
        {
            Console.WriteLine("Введите Id книги, которую хотите поменять");
            uint.TryParse(Console.ReadLine(), out uint bookId);
            if (bookId == 0)
            {
                Console.WriteLine("Ошибка, айди должен быть числом и максимум 10 символов");
                return;
            }
            Console.WriteLine("Введите название книги, на которое хотите поменять");
            string bookName = Console.ReadLine();
            Console.WriteLine("Введите цену книги, на которую хотите поменять");
            int.TryParse(Console.ReadLine(), out int price);
            if (price == 0)
            {
                Console.WriteLine("Ошибка, цена должна быть числом и максимум 10 символов");
                return;
            }
            Console.WriteLine("Введите автора книги, на которого хотите поменять");
            string authorName = Console.ReadLine();
            BookDto bookData = new BookDto()
            {
                BookName = bookName,
                BookPrice = price,
                AuthorName = authorName
            };
            bool result = _bookService.EditBook(bookData, bookId);
            if (result)
            {
                Console.WriteLine("Книга изменена");
            }
            else Console.WriteLine("Ошибка, книга не изменена, проверьте введенные данные");
        }
        
        private void Delete()
        {
            Console.WriteLine("Введите Id книги, которую хотите удалить");
            uint.TryParse(Console.ReadLine(), out uint bookId);
            if (bookId == 0)
            {
                Console.WriteLine("Ошибка, айди должен быть числом и максимум 10 символов");
                return;
            }
            bool result = _bookService.DeleteBookById(bookId);
            if (result)
            {
                Console.WriteLine("Книга успешно удалена");
            }
            else Console.WriteLine("Такой книги не существует");
        }
    }
}