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
        // every request to api this action filter is execute and check ClientId and ClientSecret for secure that only permited users are sending request.
        // initialize ClientId and ClientSecret in startup with value att app.json
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
