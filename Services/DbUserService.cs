using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;

namespace Services
{
    public class DbUserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DbUserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<User> GetUsers()
        {
            return _unitOfWork.UserRepository.GetItems();
        }

        public User GetUserById(int id)
        {
            return _unitOfWork.UserRepository.GetItemById(id);
        }

        public bool DeleteUser(int id)
        {
            return _unitOfWork.UserRepository.DeleteItemById(id);
        }

        public bool EditUser(int userId, string login, string password)
        {
            User user = new User()
            {
                Id = userId,
                Login = login,
                Password = password,
            };
            return _unitOfWork.UserRepository.EditItem(user);
        }
        
        public bool CreateUser(string login, string password)
        {
            User user = new User()
            {
                Login = login,
                Password = password,
            }; 
           return _unitOfWork.UserRepository.CreateItem(user);
        }
    }
}