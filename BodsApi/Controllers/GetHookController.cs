using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // this controller is responsible for get slack web hook of User by Camera id 
    public class GetHookController : ControllerBase
    {
        //responsible for get slack web hook of User by Camera id 
        [HttpGet]
        public async Task<IActionResult> GetHook([FromQuery] int cameraId)
        {
            UserLogic userLogic = new UserLogic();
            string hook = await userLogic.GetHookByCameraId(cameraId);
            if (hook == null)
                return BadRequest(userLogic.Response.ErrorMessage);
            return Ok(hook);
        }
    }
}