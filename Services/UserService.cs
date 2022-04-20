using System;
using TestAPI.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Guid;
using System.Linq;

namespace TestAPI.Services{

    public class UserService{

        List<Users> users = new List<Users>(10); 

        UsersContext _usersContext;

        public UserService(UsersContext context){

            _usersContext = context;

        }

        public void newUser(string _userName, string _userPassword){

            var _item = new Users(){
                UserId = Guid.NewGuid(), 
                UserName = _userName,
                UserPassword = _userPassword
            };

            _usersContext.Users.Add(_item);
            _usersContext.SaveChanges();

        }

        public bool loginUser(string _userName, string _userPassword){

            return _usersContext.Users.Any(n => n.UserName == _userName && n.UserPassword == _userPassword);
        }

        public List<Users> getUsers(){

            return _usersContext.Users.ToList();
        }

        public Users getUserById(Guid userId){
            
            return _usersContext.Users.Where(n => n.UserId == userId).FirstOrDefault();
        }

    }
}