using System;
using System.Collections.Generic;
using System.Linq;
using AuthenticationAndAuthorization.Models;

namespace AuthenticationAndAuthorization.DataAccess.Repositories
{
    public class UserRepository
    {
        private static readonly List<User> _users = new List<User>
        {
            new() {Id = 1, Username = "ale", Password = "password", Role = "manager"},
            new() {Id = 2, Username = "juanPerez", Password = "password", Role = "employee"},
            new() {Id = 3, Username = "jose", Password = "password", Role = "tester"}
        };
        public static User Get(string username, string password)
        {
            return _users.FirstOrDefault(x => string.Equals(x.Username, username, 
                                                 StringComparison.CurrentCultureIgnoreCase) 
                                             && x.Password == password);
        }

        public static List<User> GetAll(){
            return _users.Select(u=>new User{
                Id = u.Id,
                Username = u.Username,
                Role = u.Role
            }).ToList();
        }
    }
}
