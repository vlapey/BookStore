using System;
using Services;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите сервис:\n" +
                              "1 - Книжный сервис\n" +
                              "2 - Пользовательский сервис\n" +
                              "3 - Авторский сервис\n");
            int selector = int.Parse(Console.ReadLine());
            switch (selector)
                {
                    case 1:
                    {
                        Console.WriteLine("Вы выбрали книжный сервис");
                        Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                          "1 - Показать список всех книг\n" +
                                          "2 - Показать книгу по имени\n" +
                                          "3 - Создать книгу\n" +
                                          "4 - Редактировать книгу\n" +
                                          "5 - Удалить книгу\n");
                        DbBookService bookManager = new DbBookService();
                        bookManager.BookManager();
                        break;
                    }
                    
                    case 2:
                    {
                        Console.WriteLine("Вы выбрали пользовательский сервис");
                        Console.WriteLine("Выберите, что хотитет выполнить?" +
                                          "1 - Показать список всех книг\n" +
                                          "2 - Показать книгу по имени" +
                                          "3 - Создать книгу\n" +
                                          "4 - Редактировать книгу\n" +
                                          "5 - Удалить книгу\n");
                        break;
                    }
                    
                    case 3: 
                    {
                        Console.WriteLine("Вы выбрали авторский сервис");
                        Console.WriteLine("Выберите, что хотитет выполнить?" +
                                          "1 - Показать список всех книг\n" +
                                          "2 - Показать книгу по имени" +
                                          "3 - Создать книгу\n" +
                                          "4 - Редактировать книгу\n" +
                                          "5 - Удалить книгу\n");
                        break;
                    }
                    
                    default: Console.WriteLine("Вы ввели неверное число, попробуйте снова");
                        break;
                }
            // DbUserService service = new DbUserService();
            // foreach (var book in service.GetUsersBooks(3))
            // {
            //     Console.WriteLine(book);
            // }
            //todo: сделать меню на каждую функцию
        }
        
    }
}