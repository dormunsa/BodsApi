using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public byte[] SaltPassword { get; set; }
        public bool IsAdmin { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AdminId { get; set; }
        public DateTime CreationDate { get; set; }
        public string HashedPassword { get; set; }
        public bool IsSetPasswordAllowed { get; set; }
        public string UserGuid { get; set; }
        public string Phone { get; set; }
        public string SlackWebHook { get; set; }
    }
}
