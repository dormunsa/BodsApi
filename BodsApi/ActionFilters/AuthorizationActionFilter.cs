using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BodsApi.ActionFilters
{
    public class AuthorizationActionFilter : ActionFilterAttribute
    {
        public static string ClientId { get; set; }
        public static string ClientSecret { get; set; }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            string RequestClientId = context.HttpContext.Request.Headers["ClientId"];
            string RequestClientSecret = context.HttpContext.Request.Headers["ClientSecret"];

            if (ClientId != RequestClientId || ClientSecret != RequestClientSecret)
                context.Result = new UnauthorizedResult();
        }
    }
}
