﻿using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class MySqlContext
    {
        private static MySqlConnection connection 
            = new("server=localhost;port=3306;username=root;password=root;database=bookstore;SSL Mode=None");
        
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

        public static int Execute(string command)
        {
            OpenConnection();
            MySqlCommand mySqlCommand = new MySqlCommand(command, connection);
            var rowsAffected = mySqlCommand.ExecuteNonQuery();
            CloseConnection();
            return rowsAffected;
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
    }
}