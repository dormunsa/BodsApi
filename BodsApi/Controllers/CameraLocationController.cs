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
    // this controller is responsible for camera location opertions
    public class CameraLocationController : ControllerBase
    {
        // return camera id by location  latitude and longitude values
        [HttpGet]
        public async Task<IActionResult> GetCameraIdByLocation([FromQuery]double latitude, double longitude)
        {
            CameraLogic cameraLogic = new CameraLogic();
            int cameraId = await cameraLogic.GetCameraIdByLocation(latitude , longitude);
            if (cameraId == 0)
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok(cameraId);
        }
    }
}