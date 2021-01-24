﻿using System.Threading.Tasks;
using LogisticService.Application.Feature.User.Queries.GetAllUsers;
using LogisticService.Application.Feature.User.Queries.GetCurrentUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        [AllowAnonymous]
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return Ok(await Mediator.Send(new GetCurrentUserQuery()));

            return Ok();
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
    }
}