using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    public class UpdateUserDetails
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string SlackWebHook { get; set; }
    }
}
