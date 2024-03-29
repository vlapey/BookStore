﻿using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Context
{
    public class MySqlContext
    {
        private static MySqlConnection connection 
            = new("server=localhost;port=3306;username=root;password=root;database=bookstore;SSL Mode=None");

        private static void OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        private static void CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();   
            }
        }

        public static int Execute(string command)
        {
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
            var rowsAffected = mySqlCommand.ExecuteNonQuery();
            CloseConnection();
            return rowsAffected;
        }
        
        public static List<string[]> ToList(string command)
        {
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
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
    }
}