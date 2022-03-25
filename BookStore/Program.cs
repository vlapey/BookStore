using System;
using Services;
using Services.Interfaces;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            IUserService userService = new DbUserService();
            Console.WriteLine(userService.GetUserById(2));
            //todo: Меню в котором можно: просмотреть список книг, найти книгу по названию, найти книгу по автору, вывести имя юзера по айдишнику
            // для этого придется сделать еще один BookService
        
        }
    }
}