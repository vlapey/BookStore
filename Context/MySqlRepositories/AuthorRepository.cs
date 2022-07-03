using System;
using System.Collections.Generic;
using Models;

namespace Context
{
    public class AuthorRepository : IAuthorRepository
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
                    Id = int.Parse(author[0]),
                    Name = author[1],
                });
            }
            return authors;
        }

        public Author GetAuthorById(int id)
        {
            var authordata = MySqlContext.ToList(
                $"SELECT * FROM authors WHERE authors.id = {id}");
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

        public bool DeleteAuthorById(int id)
        {
            var result = MySqlContext.Execute($"DELETE FROM authors WHERE authors.id = {id}");
            return result > 0;
        }

        public bool EditAuthor(Author author)
        {
            List<string[]> authorId = MySqlContext.ToList(
                $"SELECT authors.id FROM authors WHERE authors.id = '{author.Id}'");
            if (authorId.Count == 0)
            {
                return false;
            }
            var result = MySqlContext.Execute(
                $"UPDATE authors SET authors.name = '{author.Name}' WHERE authors.id = {author.Id}");
            return result > 0;
        }

        public bool CreateAuthor(Author author)
        {
            var result = MySqlContext.Execute($"INSERT INTO `authors` (`name`) VALUES ('{author.Name}')");
            return result > 0;
        }

        public int GetAuthorIdByName(string name)
        {
            var authordata = MySqlContext.ToList(
                $"SELECT authors.id FROM authors WHERE authors.name = '{name}'");
            if (authordata.Count == 0)
            {
                return 0;
            }
            return Convert.ToInt32(authordata[0][0]);
        }
    }
}