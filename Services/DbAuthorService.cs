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
        
        public int GetAuthorIdByName(string name)
        {
            return _unitOfWork.AuthorRepository.GetAuthorIdByName(name);
        }
        
        public bool CreateAuthor(Author author)
        {
            return _unitOfWork.AuthorRepository.CreateItem(author);
        }
        
        public bool EditAuthor(Author author)
        {
            return _unitOfWork.AuthorRepository.EditItem(author);
        }

        public bool DeleteAuthor(int authorId)
        {
            return _unitOfWork.AuthorRepository.DeleteItem(authorId);
        }
    }
}