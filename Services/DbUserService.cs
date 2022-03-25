using System.Collections.Generic;
using Context;
using Models;
using Services.Interfaces;


namespace Services
{
    public class DbUserService:IUserService
    {
        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            var usersdata = ApplicationContext.ToList($"SELECT * FROM users");
            foreach (var user in usersdata)
            {
                users.Add(new User(){
                    id = uint.Parse(user[0]),
                    Login = user[1],
                    Password = user[2]
                });
            }
            return users;
        }

        public User GetUserById(uint id)
        {
            var userdata = ApplicationContext.ToList($"SELECT * FROM users WHERE users.id = {id}");
            User user = new User()
            {
                id = id,
                Login = userdata[0][1],
                Password = userdata[0][2]
            };
            return user;
        }

        public void DeleteUserById(uint id)
        {
            ApplicationContext.Execute($"DELETE FROM users WHERE users.id = {id}");
        }

        public void EditUser(User user)
        {
            //todo: написать реализацию editUser
            //"UPDATE FROM users WHERE users.id = {id}"
        }

        public void CreateUser(User user)
        {
            //todo: Сделать метод createuser
        }
    }
}