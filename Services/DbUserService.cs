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
        
        public bool CreateUser(User user)
        {
            return _unitOfWork.UserRepository.CreateItem(user);
        }

        public bool EditUser(User user)
        {
            return _unitOfWork.UserRepository.EditItem(user);
        }
        
        public bool DeleteUser(int id)
        {
            return _unitOfWork.UserRepository.DeleteItem(id);
        }
    }
}