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
    // this controller is responsible for adjusment dates request
    public class TimeRangeController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string timeRange)
        {
            TimeRangeLogic timeZoneLogic = new TimeRangeLogic();

            return Ok(await timeZoneLogic.GetTimeRange(timeRange));
        }
    }
}