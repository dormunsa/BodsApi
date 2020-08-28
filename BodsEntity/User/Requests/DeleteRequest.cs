using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object delete user operation
    public class DeleteRequest
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
