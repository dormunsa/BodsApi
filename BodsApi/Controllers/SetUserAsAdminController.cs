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
    // this controller is responsible for set user as admin
    public class SetUserAsAdminController : ControllerBase
    {
        //responsible for set user as admin by user id 
        [HttpPost]
        public async Task<IActionResult> SetAsAdmin([FromBody]int userId)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            await userLogic.SetUserAsAdmin(userId, userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok("Success");
        }
    }
}