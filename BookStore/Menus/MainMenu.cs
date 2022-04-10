using System;

namespace BookStore.Menus
{
    public static class MainMenu
    {
        //todo: implement this class
        public static void Display()
        {
            Console.WriteLine("Выберите сервис:\n" +
                              "1 - Книжный сервис\n" +
                              "2 - Пользовательский сервис\n" +
                              "3 - Авторский сервис\n" +
                              "Другое - Выйти");

            int selector = int.Parse(Console.ReadLine());
            switch (selector)
            {
                case 1:
                    BooksMenu.Display();
                    break;

                case 2:
                    UsersMenu.Display();
                    break;
                case 3:
                    AuthorsMenu.Display();
                    break;
                default:
                    Console.WriteLine("Вы ввели неверное число, попробуйте снова");
                    break;
            }
        }
    }
}