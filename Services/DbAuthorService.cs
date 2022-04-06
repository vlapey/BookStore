using System;
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

        public void EditAuthor(Author author)
        {
            //todo: return suc ass statement (as in delete func)
            ApplicationContext.Execute($"UPDATE authors SET authors.name = '{author.Name}' " +
                                       $"WHERE authors.id = {author.Id}");
        }

        public void CreateAuthor(Author author)
        {
            //todo: return suc ass statement (as in delete func)
            ApplicationContext.Execute($"INSERT INTO `authors` (`name`) VALUES ('{author.Name}')");
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

        public void AuthorManager()
        {
            //todo: remove in UI 
            int selector = int.Parse(Console.ReadLine());
            switch (selector)
            {
                case 1:
                {
                    DbAuthorService authorService = new DbAuthorService();
                    foreach (var author in authorService.GetAuthors())
                    {
                        Console.WriteLine(author);
                    }

                    break;
                }

                case 2:
                {
                    Console.WriteLine("Введите Id автора, которого хотите вывести");
                    uint authorId = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine(GetAuthorById(authorId));
                    break;
                }

                case 3:
                {
                    Console.WriteLine("Введите имя автора, чтобы получить его Id");
                    string name = Console.ReadLine();
                    Console.WriteLine(GetAuthorIdByName(name));
                    break;
                }

                case 4:
                {
                    Console.WriteLine("Введите Имя");
                    string authorName = Console.ReadLine();
                    Author author = new Author()
                    {
                        Name = authorName,
                    };
                    CreateAuthor(author);
                    break;
                }

                case 5:
                {
                    Console.WriteLine("Введите Id автора, которого хотите поменять");
                    uint userId = Convert.ToUInt32(Console.ReadLine());
                    Console.WriteLine("Введите Имя автора, на которое хотите поменять");
                    string authorName = Console.ReadLine();
                    Author author = new Author()
                    {
                        Id = userId,
                        Name = authorName,
                    };
                    EditAuthor(author);
                    break;
                }

                case 6:
                {
                    Console.WriteLine("Введите Id автора, которого хотите удалить");
                    uint id = Convert.ToUInt32(Console.ReadLine());
                    DeleteAuthorById(id);
                    break;
                }
                //todo: replace with Back to main menu option
                default: Console.WriteLine("Вы ввели неверное число, попробуйте снова");
                    break;
            }
        }
    }
}