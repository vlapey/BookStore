using System;
using BookStore.Menus;
using Services;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu mainMenu = new MainMenu();
            mainMenu.Display();
        }
    }
}