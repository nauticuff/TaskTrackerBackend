using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskTrackerBackend.Models.DTO;
using TaskTrackerBackend.Services.Context;

namespace TaskTrackerBackend.Services
{
    public class UserService
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public bool DoesUserExist(string Username)
        {
            //check the table to see if the username exists
            //if 1 item matches the condition we will return the item
            //if no item matches the ocnditiion it will return null
            //if multiple items match then error will occur
            return _context.UserInfo.SingleOrDefault(user => user.UserName == Username)

        }
        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            //if user already exists
            //if they do not exist then create acc
            //else throw a false
        }
    }
}