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
    // this controller is responsible for get chart object by dates
    public class ChartReportController : ControllerBase
    {
        //get chart object by dates
        [HttpGet]
        public async Task<IActionResult> GetChatrtReport([FromQuery] DateTime fromDate, DateTime toDate)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            DetectionLogic detectionLogic = new DetectionLogic();
            ReportResponse detections = await detectionLogic.ReadDetectionChart(fromDate, toDate, userGuid);
            if (detections == null)
                return Ok(new List<DetectionResponse>());
            return Ok(detections);
        }
    }
}