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
    // this controller is responsible for detection insert and get detections
    public class DetectionController : ControllerBase
    {
        //responsible for  insert  detection
        [HttpPost]
        public async Task<IActionResult> InsertDetection([FromBody]InsertDetection request)
        {

            DetectionLogic detectionLogic = new DetectionLogic();
            await detectionLogic.InsertDetection(request);
            if (!detectionLogic.Response.IsSuccessful)
                return BadRequest(detectionLogic.Response.ErrorMessage);
            return Ok("Success");
        }

        //responsible for  get  detections that come from camera that asigned to user- identify user by UserGuid Header value
        [HttpGet]
        public async Task<IActionResult> GetDetection()
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            DetectionLogic detectionLogic = new DetectionLogic();
            List<Detection> detections = await detectionLogic.GetByUserGuid(userGuid);
            if (detections == null)
                return Ok(new List<Detection>());
            return Ok(detections);
        }
    }
}