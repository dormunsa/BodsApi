using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationActionFilter]
    // this controller is responsible for reset password operations
    public class ResetPasswordController : ControllerBase
    {
        //responsible for reset password by user name
        [HttpPost]
        public async Task<IActionResult> ResetPassword([FromBody]string userName)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            await userLogic.ResetPassword(userName , userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok("Success");
        }
    }
}