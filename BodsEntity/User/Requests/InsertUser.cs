using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object insert user operation
    public class InsertUser
    {
        public string UserName { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AdminId { get; set; }
        public string Phone { get; set; }
        public string SlackWebHook { get; set; }

    }
}
