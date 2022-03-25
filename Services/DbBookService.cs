using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbBookService:IBookService
    {
        public void CreateBook(Book book)
        {
            ApplicationContext.Execute($"INSERT INTO `books` (`id`, `name`, `price`, `authors_id`) VALUES (NULL,'{book.Name}', '{book.Price}', '4')");
        }
        
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            //todo: JOIN сделать таблицу где вместо айдишника будет сам автор
            
            foreach (var book in bookdata)
            {
                books.Add(new Book(){
                    Name = book[1],
                    Price = Convert.ToInt32(book[2]),
                    Author = authordata[0][1]
                });
            }
            return books;
        }

        public Book GetBookByName(string name)
        {
            //todo: JOIN сделать таблицу где вместо айдишника будет сам автор

            Book book = new Book()
            {
                Name = name,
                Price = Convert.ToInt32(bookdata[0][2]),
                Author = authordata[0][1]
            };
            return book;
        }

        public void DeleteBookById(uint id)
        {
            ApplicationContext.Execute($"DELETE FROM books WHERE books.id = {id}");
        }

        public void EditBook()
        {
            //todo: едит бук сделац
        }
    }
}