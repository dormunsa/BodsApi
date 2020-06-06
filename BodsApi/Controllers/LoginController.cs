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
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginRequest request)
        {
            UserLogic userLogic = new UserLogic();
            await userLogic.Login(null, request);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok(userLogic.loginResponse);
        }
        
        [HttpGet]
        public async Task<IActionResult> LoginByGuid()
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];

            UserLogic userLogic = new UserLogic();
            await userLogic.Login(userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok(userLogic.loginResponse);
        }
       
    }
}