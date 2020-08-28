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

    // this controller is responsible for camera opertions
    public class CameraController : ControllerBase
    {
        // insert new camera to db
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
        // update camera details in db
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
        // delete camera from db
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

        // get all cameras that asign to this user - identify user by UserGuid Header value
        [HttpGet]
        public async Task<IActionResult> GetCameras()
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();
            List<Camera> cameras =  await cameraLogic.GetAllUserCameras(userGuid);
            if (cameras == null)
                return Ok(new List<Camera>());
            return Ok(cameras);
        }
    }
}