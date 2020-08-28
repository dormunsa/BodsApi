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
    // this controller is responsible for get table report object 
    public class DetectionReportController : ControllerBase
    {
        // responsible for get table report object
        [HttpGet]
        public async Task<IActionResult> GetReport([FromQuery] DateTime fromDate, DateTime toDate)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            DetectionLogic detectionLogic = new DetectionLogic();
            List<DetectionResponse> detections = await detectionLogic.ReadDetection(fromDate , toDate , userGuid);
            if (detections == null)
                return Ok(new List<DetectionResponse>());
            return Ok(detections);
        }
    }
}