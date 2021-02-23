﻿using System;
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
                new() {Id = 1, Username = "goku", Password = "goku", Role = "manager"},
                new() {Id = 2, Username = "vejeta", Password = "vejeta", Role = "employee"},
                new() {Id = 3, Username = "kuririn", Password = "kuririn", Role = "tester"}
            };

            return users.FirstOrDefault(x => string.Equals(x.Username, username, StringComparison.CurrentCultureIgnoreCase) 
                                             && x.Password == password);
        }
    }
}