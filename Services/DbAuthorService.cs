using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbAuthorService : IAuthorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbAuthorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Author> GetAuthors()
        {
            return _unitOfWork.AuthorRepository.GetItems();
        }
        
        public Author GetAuthorById(int id)
        {
           return _unitOfWork.AuthorRepository.GetItemById(id);
        }
        
        public bool DeleteAuthor(int authorId)
        {
            return _unitOfWork.AuthorRepository.DeleteItemById(authorId);
        }
        
        public bool EditAuthor(int authorId, string authorName)
        {
            Author author = new Author()
            {
                Id = authorId,
                Name = authorName,
            };
            return _unitOfWork.AuthorRepository.EditItem(author);
        }
        
        public bool CreateAuthor(string authorName)
        {
            Author author = new Author()
            {
                Name = authorName
            };
           return _unitOfWork.AuthorRepository.CreateItem(author);
        }
        
        public int GetAuthorIdByName(string name)
        {
            return _unitOfWork.AuthorRepository.GetAuthorIdByName(name);
        }
    }
}