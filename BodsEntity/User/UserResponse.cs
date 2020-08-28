using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define user response object for user
    public class UserResponse
    {
        public UserResponse(int userId, string userName, bool isAdmin, string firstName, string lastName , string phone , string slackWebHook)
        {
            UserId = userId;
            UserName = userName;
            IsAdmin = isAdmin;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            SlackWebHook = slackWebHook;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string SlackWebHook { get; set; }

    }
}
