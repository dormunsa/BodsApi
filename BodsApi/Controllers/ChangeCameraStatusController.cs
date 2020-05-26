﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BodsApi.ActionFilters;
using BodsLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BodsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthorizationActionFilter]

    public class ChangeCameraStatusController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> ChangeWorkingStatus([FromBody]int cameraId)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            CameraLogic cameraLogic = new CameraLogic();

            if (! await cameraLogic.ChangeWorkingStatus(cameraId, userGuid))
                return BadRequest(cameraLogic.Response.ErrorMessage);
            return Ok("Success");
        }
    }
}