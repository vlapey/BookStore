using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace Context
{
    public class MsSqlContext:IMsSqlContext
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

        public int Execute(string command)
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
        public List<string[]> ToList(string command)
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
        
        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            var authordata = ToList($"SELECT * FROM authors");
            if (authordata.Count == 0)
            {
                return null;
            }
            foreach (var author in authordata)
            {
                authors.Add(new Author()
                {
                    Id = uint.Parse(author[0]),
                    Name = author[1],
                });
            }
            return authors;
        }
        
        public Author GetAuthorById(uint id)
        {
            var authordata = 
                ToList($"SELECT * FROM authors WHERE authors.id = {id}");
            if (authordata.Count == 0)
            {
                return null;
            }
            Author author = new Author()
            {
                Id = id,
                Name = authordata[0][1],
            };
            return author;
        }
        
        public bool DeleteAuthorById(uint id)
        {
            var result = Execute($"DELETE FROM authors WHERE authors.id = {id}");
            return result > 0;
        }
        
        public bool EditAuthor(Author author)
        {
            int authorId = 
                Execute($"SELECT authors.id FROM authors WHERE authors.id = '{author.Id}'");
            if (authorId == -1)
            {
                return false;
            }
            var result = 
                Execute($"UPDATE authors SET authors.name = '{author.Name}' " +
                         $"WHERE authors.id = {author.Id}");
            return result > 0;
        }
        
        public bool CreateAuthor(Author author)
        {
            var result = Execute($"INSERT INTO `authors` (`name`) VALUES ('{author.Name}')");
            return result > 0;
        }
        
        public uint GetAuthorIdByName(string name)
        {
            var authordata = ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{name}'");
            if (authordata.Count == 0)
            {
                return 0;
            }
            return Convert.ToUInt32(authordata[0][0]);
        }
        
        public bool CreateBook(Book book)
        {
            var authordata = ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            if (authordata.Count == 0 || book == null)
            {
                return false;
            }
            var result = Execute($"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                                           $"VALUES ('{book.Name}', '{book.Price}', '{authordata[0][0]}')");
            return result > 0;
        }
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            var bookdata = ToList
            ("SELECT books.id, books.name, books.price, authors.name" +
             " FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            if (bookdata.Count == 0)
            {
                return null;
            }

            foreach (var book in bookdata)
            {
                books.Add(new Book()
                {
                    Id = Convert.ToUInt32(book[0]),
                    Name = book[1],
                    Price = Convert.ToInt32(book[2]),
                    Author = book[3]
                });
            }
            return books;
        }
        
        public Book GetBookByName(string name)
        {
            var bookdata = ToList
            ($"SELECT books.id, books.name, books.price, authors.name" +
             $" FROM books LEFT JOIN authors ON books.authors_id = authors.id");
            if (bookdata[0][1] != name)
            {
                return null;
            }

            Book book = new Book()
            {
                Id = Convert.ToUInt32(bookdata[0][0]),
                Name = name,
                Price = Convert.ToInt32(bookdata[0][2]),
                Author = bookdata[0][3]
            };
            return book;
        }
        
        public bool DeleteBookById(uint id)
        {
            var result = Execute($"DELETE FROM books WHERE books.id = {id}");
            return result > 0;
        }
        
        public bool EditBook(Book book)
        {
            int bookId = Execute($"SELECT books.id FROM books WHERE books.id = '{book.Id}'");
            if (bookId == -1)
            {
                return false;
            }
            var authordata = ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");

            var result = Execute($"UPDATE books SET books.name = '{book.Name}', " +
                                           $"books.price = {book.Price}, "
                                           + $"books.authors_id = {authordata[0][0]} WHERE books.id = {book.Id}");
            return result > 0;
        }
        
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var userdata = ToList($"SELECT * FROM users");
            if (userdata.Count == 0)
            {
                return null;
            }

            foreach (var user in userdata)
            {
                users.Add(new User()
                {
                    Id = uint.Parse(user[0]),
                    Login = user[1],
                    Password = user[2]
                });
            }

            return users;
        }
        
        public User GetUserById(uint id)
        {
            var userdata = ToList($"SELECT * FROM users WHERE users.id = {id}");
            if (userdata.Count == 0)
            {
                return null;
            }
            User user = new User()
            {
                Id = id,
                Login = userdata[0][1],
                Password = userdata[0][2]
            };
            return user;
        }
        
        public bool DeleteUserById(uint id)
        {
            var result = Execute($"DELETE FROM users WHERE users.id = {id}");
            return result > 0;
        }
        
        public bool EditUser(User user)
        {
            int userId = Execute($"SELECT users.id FROM users WHERE users.id = '{user.Id}'");
            if (userId == -1)
            {
                return false;
            }
            var result = Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                           $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
            return result > 0;
        }
        
        public bool CreateUser(User user)
        {
            var result = Execute($"INSERT INTO `users` (`login`, `password`) " +
                                           $"VALUES ('{user.Login}', '{user.Password}')");
            return result > 0;
        }
        
        public List<Book> GetUsersBooks(uint id)
        {
            int userId = Execute($"SELECT users.id FROM users WHERE users.id = '{id}'");
            if (userId == -1)
                return null;
            var usersbooks = new List<Book>();
            
            var booksDataFromDatabase = 
                ToList($"SELECT books.id, books.name," +
                        $" books.price, authors.name FROM users_to_books" +
                        $" LEFT JOIN books ON users_to_books.books_id = books.id" +
                        $" LEFT JOIN authors ON books.authors_id = authors.id WHERE users_id = {id}");

            foreach (var bookAsStringsArray in booksDataFromDatabase)
            {
                usersbooks.Add(new Book()
                {
                    Id = Convert.ToUInt32(bookAsStringsArray[0]),
                    Name = bookAsStringsArray[1],
                    Price = Convert.ToInt32(bookAsStringsArray[2]),
                    Author = bookAsStringsArray[3]
                });
            }
            return usersbooks;
        }
    }
}