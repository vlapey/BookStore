using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbAuthorService:IAuthorService
    {
        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            var authordata = ApplicationContext.ToList($"SELECT * FROM authors");
            foreach (var author in authordata)
            {
                authors.Add(new Author(){
                    id = uint.Parse(author[0]),
                    Name = author[1],
                });
            }
            return authors;
        }

        public Author GetAuthorById(uint id)
        {
            var authordata = ApplicationContext.ToList
                ($"SELECT * FROM authors WHERE authors.id = {id}");
            Author author = new Author()
            {
                id = id,
                Name = authordata[0][1],
            };
            return author;
        }

        public void DeleteAuthorById(uint id)
        {
            ApplicationContext.Execute($"DELETE FROM authors WHERE authors.id = {id}");
        }

        public void EditAuthor()
        {
            
        }

        public void CreateAuthor(Author author)
        {
            
        }
    }
}