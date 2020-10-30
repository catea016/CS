using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasswordApplication
{
    class UserDB
    {
        List<User> users = new List<User>();

        // Function to add the user to im memory DB
        public void AddUser(User user)
        {
            users.Add(user);
            
        }

        // Function to retrieve the user based on user id
        public User GetUser(string userid)
        {
            return users.Single(u => u.UserId == userid);
        }
    }
}
