using System;
using System.Collections.Generic;
using System.Text;

namespace BodsEntity
{
    public class BaseResponse
    {
          public bool IsSuccessful { get; set; }
          public string ErrorMessage { get; set; }
    }
}
