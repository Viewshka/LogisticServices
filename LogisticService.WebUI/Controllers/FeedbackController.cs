using System.Threading.Tasks;
using LogisticService.Application.Feature.Feedback.Commands.Create;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    public class FeedbackController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> AddFeedbackAsync(CreateFeedbackCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}