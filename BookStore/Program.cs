using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{

    class Program
    {
        static void Main(string[] args)
        {
            DataBase.OpenConnection();
            DataBase.CloseConnection();
        }
    }
}