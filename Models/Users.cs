using System;
using static System.Guid;

namespace TestAPI
{
    public class Users
    {
        
        public Guid UserId {get;set;}
        public string UserName {get;set;} = "";
        public string UserPassword {get;set;} = "";

    }
}