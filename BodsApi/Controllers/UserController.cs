﻿using System;
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
    public class UserController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetUsers([FromQuery]int userId)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            List<UserResponse> userList =  await userLogic.GetAllChildUsers(userId, userGuid);

            if (userList == null)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok(userList);
        }
        [HttpPost]
        public async Task<IActionResult> InsertUser([FromBody]InsertUser request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            await userLogic.InsertUser(request, userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok("Success");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromBody]UpdateUserDetails request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            await userLogic.UpdateUserDetails(request, userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok("Success");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody]DeleteRequest request)
        {
            string userGuid = HttpContext.Request.Headers["UserGuid"];
            UserLogic userLogic = new UserLogic();
            await userLogic.DeleteUser(request, userGuid);

            if (userLogic.Response.IsSuccessful == false)
                return BadRequest(userLogic.Response.ErrorMessage);

            return Ok(JsonConvert.SerializeObject("success"));
        }
    }
}