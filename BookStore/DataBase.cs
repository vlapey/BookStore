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
        
        public static List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var usersdata = ToList($"SELECT * FROM users");
            foreach (var user in usersdata)
            {
                users.Add(new User(){
                    id = uint.Parse(user[0]),
                    Login = user[1],
                    Password = user[2]
                });
            }
            return users;
        }

        public static User GetUserById(uint id)
        {
            var userdata = ToList($"SELECT * FROM users WHERE users.id = {id}");
            User user = new User()
            {
                id = id,
                Login = userdata[0][1],
                Password = userdata[0][2]
            };
            return user;
        }

        /// <summary>
        /// Функция которая возвращает из базы данных двумерный массив строк
        /// </summary>
        /// <param name="command"> строка sql запроса </param>
        /// <returns></returns>
        public static List<string[]> ToList(string command)
        {
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
            /*command.ExecuteNonQuery(); Вариант для insert и для delete*/
            List<string[]> data = new List<string[]>();
            MySqlDataReader dataReader = mySqlCommand.ExecuteReader();
            while (dataReader.Read())
            {
                data.Add(new string[dataReader.FieldCount]);
                for (int i = 0; i < dataReader.FieldCount; i++)
                {
                    data.Last()[i] = dataReader[i].ToString();
                }
            }
            dataReader.Close();
            CloseConnection();
            return data;
        }
        
        public static void DeleteUserById(uint id)
        {
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand($"DELETE FROM users WHERE users.id = {id}",connection);
            mySqlCommand.ExecuteNonQuery();
            CloseConnection();
        }
    }
}