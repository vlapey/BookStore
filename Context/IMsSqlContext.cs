using System.Collections.Generic;
using Models;

namespace Context
{
    public interface IMsSqlContext
    {
        public List<Author> GetAuthors();
        public Author GetAuthorById(uint id);
        public bool DeleteAuthorById(uint id);
        public bool EditAuthor(Author author);
        public bool CreateAuthor(Author author);
        public uint GetAuthorIdByName(string name);
        public bool CreateBook(Book book);
        public List<Book> GetBooks();
        public Book GetBookByName(string name);
        public bool DeleteBookById(uint id);
        public bool EditBook(Book book);
        public List<User> GetUsers();
        public User GetUserById(uint id);
        public bool DeleteUserById(uint id);
        public bool EditUser(User user);
        public bool CreateUser(User user);
        public List<Book> GetUsersBooks(uint id);
        
    }
}