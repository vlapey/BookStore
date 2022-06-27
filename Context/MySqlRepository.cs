using System;
using System.Collections.Generic;
using Models;

namespace Context
{
    public class MySqlRepository : IRepository
    {
        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            var authordata = MySqlContext.ToList($"SELECT * FROM authors");
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
                MySqlContext.ToList($"SELECT * FROM authors WHERE authors.id = {id}");
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
            var result = MySqlContext.Execute($"DELETE FROM authors WHERE authors.id = {id}");
            return result > 0;
        }
        
        public bool EditAuthor(Author author)
        {
            int authorId = 
                MySqlContext.Execute($"SELECT authors.id FROM authors WHERE authors.id = '{author.Id}'");
            if (authorId == -1)
            {
                return false;
            }
            var result = 
                MySqlContext.Execute($"UPDATE authors SET authors.name = '{author.Name}' " +
                                     $"WHERE authors.id = {author.Id}");
            return result > 0;
        }
        
        public bool CreateAuthor(Author author)
        {
            var result = MySqlContext.Execute($"INSERT INTO `authors` (`name`) VALUES ('{author.Name}')");
            return result > 0;
        }
        
        public uint GetAuthorIdByName(string name)
        {
            var authordata = MySqlContext.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{name}'");
            if (authordata.Count == 0)
            {
                return 0;
            }
            return Convert.ToUInt32(authordata[0][0]);
        }
        
        public bool CreateBook(Book book)
        {
            var authordata = MySqlContext.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");
            if (authordata.Count == 0 || book == null)
            {
                return false;
            }
            var result = MySqlContext.Execute($"INSERT INTO `books` (`name`, `price`, `authors_id`)" +
                                              $"VALUES ('{book.Name}', '{book.Price}', '{authordata[0][0]}')");
            return result > 0;
        }
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            var bookdata = MySqlContext.ToList
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
            var bookdata = MySqlContext.ToList
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
            var result = MySqlContext.Execute($"DELETE FROM books WHERE books.id = {id}");
            return result > 0;
        }
        
        public bool EditBook(Book book)
        {
            int bookId = MySqlContext.Execute($"SELECT books.id FROM books WHERE books.id = '{book.Id}'");
            if (bookId == -1)
            {
                return false;
            }
            var authordata = MySqlContext.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{book.Author}'");

            var result = MySqlContext.Execute($"UPDATE books SET books.name = '{book.Name}', " +
                                              $"books.price = {book.Price}, "
                                              + $"books.authors_id = {authordata[0][0]} WHERE books.id = {book.Id}");
            return result > 0;
        }
        
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var userdata = MySqlContext.ToList($"SELECT * FROM users");
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
            var userdata = MySqlContext.ToList($"SELECT * FROM users WHERE users.id = {id}");
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
            var result = MySqlContext.Execute($"DELETE FROM users WHERE users.id = {id}");
            return result > 0;
        }
        
        public bool EditUser(User user)
        {
            int userId = MySqlContext.Execute($"SELECT users.id FROM users WHERE users.id = '{user.Id}'");
            if (userId == -1)
            {
                return false;
            }
            var result = MySqlContext.Execute($"UPDATE users SET users.login = '{user.Login}'," +
                                              $" users.password = '{user.Password}' WHERE users.id = {user.Id}");
            return result > 0;
        }
        
        public bool CreateUser(User user)
        {
            var result = MySqlContext.Execute($"INSERT INTO `users` (`login`, `password`) " +
                                              $"VALUES ('{user.Login}', '{user.Password}')");
            return result > 0;
        }
        
        public List<Book> GetUsersBooks(uint id)
        {
            int userId = MySqlContext.Execute($"SELECT users.id FROM users WHERE users.id = '{id}'");
            if (userId == -1)
                return null;
            var usersbooks = new List<Book>();
            
            var booksDataFromDatabase = 
                MySqlContext.ToList($"SELECT books.id, books.name," +
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