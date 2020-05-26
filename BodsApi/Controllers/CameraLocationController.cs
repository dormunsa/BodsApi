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
    public class CameraLocationController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetWeather([FromQuery]double latitude, double longitude)
        {

            CameraLogic cameraLogic = new CameraLogic();
            int cameraId = await cameraLogic.GetCameraIdByLocation(latitude , longitude);
            if (cameraId == 0)
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok(cameraId);
        }
    }
}