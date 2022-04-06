using System;

namespace BookStore.Menus
{
    public static class Main
    {
        //todo: implement this class
        public static void Display()
        {
            //-> Program.cs
            Console.WriteLine("Выберите сервис:\n" +
                              "1 - Книжный сервис\n" +
                              "2 - Пользовательский сервис\n" +
                              "3 - Авторский сервис\n" +
                              "другое - выйти");

            int selector = int.Parse(Console.ReadLine());
            switch (selector)
            {
                case 1:
                //AuthorMenu.Display()
                //break

                case 2:
                //UserMenu.Display()
                //break
                case 3:
                //BookMenu.Display()
                //break
                default:
                    Console.WriteLine("Вы ввели неверное число, попробуйте снова");
                    break;
            }
        }
    }
}