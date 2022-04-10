﻿using System;
using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbAuthorService : IAuthorService
    {
        public List<Author> GetAuthors()
        {
            List<Author> authors = new List<Author>();
            var authordata = ApplicationContext.ToList($"SELECT * FROM authors");
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
            var authordata = ApplicationContext.ToList
                ($"SELECT * FROM authors WHERE authors.id = {id}");
            Author author = new Author()
            {
                Id = id,
                Name = authordata[0][1],
            };
            return author;
        }

        public bool DeleteAuthorById(uint id)
        {
            var result = ApplicationContext.Execute($"DELETE FROM authors WHERE authors.id = {id}");
            return result > 0;
        }

        public bool EditAuthor(Author author)
        {
            //todo: return suc ass statement (as in delete func)
            var result = ApplicationContext.Execute($"UPDATE authors SET authors.name = '{author.Name}' " +
                                       $"WHERE authors.id = {author.Id}");
            return result > 0;
        }

        public bool CreateAuthor(Author author)
        {
            //todo: return suc ass statement (as in delete func)
            var result = ApplicationContext.Execute($"INSERT INTO `authors` (`name`) VALUES ('{author.Name}')");
            return result > 0;
        }

        public uint GetAuthorIdByName(string name)
        {
            var authordata = ApplicationContext.ToList
                ($"SELECT authors.id FROM authors WHERE authors.name = '{name}'");
            if (authordata.Count == 0)
            {
                Author author = new Author()
                {
                    Name = name
                };
                CreateAuthor(author);
                return GetAuthorIdByName(name);
            }

            return Convert.ToUInt32(authordata[0][0]);
        }
    }
}