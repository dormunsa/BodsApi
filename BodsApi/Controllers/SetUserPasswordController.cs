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
    public class SetUserPasswordController : ControllerBase
    {
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