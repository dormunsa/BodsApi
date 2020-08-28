using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    // define object for base  response 
    public class BaseResponse
    {
          public bool IsSuccessful { get; set; }
          public string ErrorMessage { get; set; }
    }
}
