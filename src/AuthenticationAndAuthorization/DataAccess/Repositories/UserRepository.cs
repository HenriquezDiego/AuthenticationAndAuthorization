using System;
using System.Collections.Generic;
using System.Linq;
using AuthenticationAndAuthorization.Models;

namespace AuthenticationAndAuthorization.DataAccess.Repositories
{
    public class UserRepository
    {
        public static User Get(string username, string password)
        {
            var users = new List<User>
            {
                new() {Id = 1, Username = "ale", Password = "catolica10", Role = "manager"},
                new() {Id = 2, Username = "juanPerez", Password = "juan", Role = "employee"},
                new() {Id = 3, Username = "jose", Password = "jose", Role = "tester"}
            };

            return users.FirstOrDefault(x => string.Equals(x.Username, username, 
                                                 StringComparison.CurrentCultureIgnoreCase) 
                                             && x.Password == password);
        }
    }
}
