using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace BookStore
{
    public class DataBase
    {
        private static MySqlConnection connection = new("server=localhost;port=3306;" +
                                                        "username=root;password=root;" + 
                                                        "database=bookstore;SSL Mode=None");

        public static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
                connection.Open();
        }

        public static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
                connection.Close();
        }
        
        public static List<string[]> GetUsers()
        {
            OpenConnection();
            MySqlCommand command = new MySqlCommand("SELECT * FROM `users`", connection);
            /*command.ExecuteNonQuery(); Вариант для insert и для delete*/
            List<string[]> users = new List<string[]>();
            MySqlDataReader dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                users.Add(new string[3]);
                for (int i = 0; i < 3; i++)
                {
                    users.Last()[i] = dataReader[i].ToString();
                }
            }
            dataReader.Close();
            CloseConnection();
            return users;
        }
    }
}