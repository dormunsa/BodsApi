using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsEntity;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationActionFilter]
    public class CameraController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> InsertCamera([FromBody]UpdateCameraRequest request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();
            await cameraLogic.InsertCamera(request, userGuid);
            if(! cameraLogic.Response.IsSuccessful) 
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok("Success");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCamera([FromBody]UpdateCameraRequest request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();
            await cameraLogic.UpdateCamera(request, userGuid);
            if (!cameraLogic.Response.IsSuccessful)
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok("Success");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCamera([FromBody]Camera request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();
            await cameraLogic.DeleteCamera(request, userGuid);
            if (!cameraLogic.Response.IsSuccessful)
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok(JsonConvert.SerializeObject("success"));
        }

        [HttpGet]
        public async Task<IActionResult> GetCameras()
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();
            List<Camera> cameras =  await cameraLogic.GetAllUserCameras(userGuid);
            if (cameras == null)
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok(cameras);
        }
    }
}