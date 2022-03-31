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
                        Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                          "1 - Показать список всех пользователей\n" +
                                          "2 - Показать пользователя по Id\n" +
                                          "3 - Показать книги пользователя\n" +
                                          "4 - Создать пользователя\n" +  
                                          "5 - Редактировать пользователя\n" +
                                          "6 - Удалить пользователя");
                        DbUserService userManager = new DbUserService();
                        userManager.UserManager();
                        break;
                    }
                    
                    case 3: 
                    {
                        Console.WriteLine("Вы выбрали авторский сервис");
                        Console.WriteLine("Выберите, что хотитет выполнить?\n" +
                                          "1 - Показать список всех авторов\n" +
                                          "2 - Показать автора по Id\n" +
                                          "3 - Показать Id автора по имени\n" +
                                          "4 - Создать автора\n" +
                                          "5 - Редактировать автора\n" +
                                          "6 - Удалить автора\n");
                        DbAuthorService authorManager = new DbAuthorService();
                        authorManager.AuthorManager();
                        break;
                    }
                    
                    default: Console.WriteLine("Вы ввели неверное число, попробуйте снова");
                        break;
                }
        }
        
    }
}