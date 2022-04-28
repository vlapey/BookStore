using System;

namespace BookStore.Menus
{
    public class MainMenu
    {
        public void Display()
        {
            BooksMenu booksMenu = new BooksMenu(DiContainer.BookService);
            AuthorsMenu authorsMenu = new AuthorsMenu(DiContainer.AuthorService);
            UsersMenu usersMenu = new UsersMenu(DiContainer.UserService);
            
            while (true)
            {
                Console.WriteLine("Выберите сервис:\n" +
                                  "1 - Книжный сервис\n" +
                                  "2 - Пользовательский сервис\n" +
                                  "3 - Авторский сервис\n" +
                                  "Другое - Выйти\n");

                string selector = Console.ReadLine();
                switch (selector)
                {
                    case "1":
                        booksMenu.Display();
                        break;

                    case "2":
                        usersMenu.Display();
                        break;
                    case "3":
                        authorsMenu.Display();
                        break;
                    default:
                        Console.WriteLine("Вы вышли из программы");
                        return;
                }
            }
        }
    }
}