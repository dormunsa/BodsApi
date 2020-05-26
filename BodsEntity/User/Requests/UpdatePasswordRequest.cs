using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    public class UpdatePasswordRequest
    {
        public string UserName { get; set; }
        public string NewPassword { get; set; }
    }
}
