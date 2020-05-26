using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsEntity;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetPhoneController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetPhoneNumber([FromQuery] int cameraId)
        {
            UserLogic userLogic = new UserLogic();
            string phone = await userLogic.GetPhoneByCameraId(cameraId);
            if (phone == null)
                return BadRequest(userLogic.Response.ErrorMessage);
            return Ok(phone);
        }
    }
}