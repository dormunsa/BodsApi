using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsEntity;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationActionFilter]
    // this controller is responsible for set user password
    public class SetUserPasswordController : ControllerBase
    {
        //responsible for set user password identify user by UserGuid Header Value and set newPassword value as the new password
        [HttpPost]
        public async Task<IActionResult> SetPassword([FromBody] string newPassword)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            if (!await userLogic.UpdatePortalUserPassword(newPassword, userGuid))
                return BadRequest(userLogic.Response.ErrorMessage);
            return Ok("Success");
        }
    }
}