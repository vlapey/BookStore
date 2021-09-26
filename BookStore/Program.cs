
/*
 Чтобы функционал был следующий: 
 case 1: просмотр списка книг, 
 case 2: добавление определённых в корзину, 
 case 3:просмотр корзины, 
 case 4 and 5: сортировка по цене вверх и вниз, 
 case 6: поиск по названию
 создать отдельную функцию на вывод
 
 */

using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Threading.Channels;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nChoose action:\n" +
                                  "1 - Look at the list of books\n" +
                                  "2 - Add a book to cart\n" +
                                  "3 - Look at the list of books in cart\n" +
                                  "4 - Sorting up by price\n" +
                                  "5 - Sorting down by price\n" +
                                  "6 - Find book by name");
                var selector = int.Parse(Console.ReadLine());
                switch (selector)
                {
                    case 1:
                       BookManager.PrintBookList();
                        break;
                    
                    case 2:
                        BookManager.PrintBookList();
                        BookManager.AddBook();
                        break;
                    
                    case 3: 
                        BookManager.PrintCartList();
                        break;
                    
                    case 4: BookManager.AscendingSort();
                        break;
                    
                    case 5: BookManager.DescendingSort();
                        break;
                    
                    case 6:  BookManager.FindBook();
                        break;
                    
                    default: Console.WriteLine("You've chosen wrong action");
                        break;
                }
            }
        }

       
    }
}
    
