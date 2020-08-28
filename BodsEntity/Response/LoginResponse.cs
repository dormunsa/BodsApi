using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for login response 
    public class LoginResponse
    {
        public LoginResponse(int userId, string userName, bool isAdmin, int adminId, bool isSetPasswordAllowed, string userGuid)
        {
            UserId = userId;
            UserName = userName;
            IsAdmin = isAdmin;
            AdminId = adminId;
            IsSetPasswordAllowed = isSetPasswordAllowed;
            UserGuid = userGuid;
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }  
        public int AdminId { get; set; }
        public bool IsSetPasswordAllowed { get; set; }
        public string UserGuid { get; set; }
    }
}
