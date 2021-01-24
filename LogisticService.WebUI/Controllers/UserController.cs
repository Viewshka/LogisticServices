using System.Threading.Tasks;
using LogisticService.Application.Feature.User.Queries.GetAllUsers;
using LogisticService.Application.Feature.User.Queries.GetCurrentUser;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    public class UserController : ApiController
    {
        [HttpGet("current-user")]
        public async Task<IActionResult> GetCurrentUser()
        {
            return Ok(await Mediator.Send(new GetCurrentUserQuery()));
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAllUser()
        {
            return Ok(await Mediator.Send(new GetAllUsersQuery()));
        }
    }
}