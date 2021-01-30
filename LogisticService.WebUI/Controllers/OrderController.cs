using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using LogisticService.Application.Feature.Order.Commands.ApproveOrder;
using LogisticService.Application.Feature.Order.Commands.CancelOrder;
using LogisticService.Application.Feature.Order.Commands.ClientIsRemoveOrder;
using LogisticService.Application.Feature.Order.Commands.Create;
using LogisticService.Application.Feature.Order.Commands.Delete;
using LogisticService.Application.Feature.Order.Commands.OrderCompleted;
using LogisticService.Application.Feature.Order.Commands.SendOnKitting;
using LogisticService.Application.Feature.Order.Commands.TakeOrder;
using LogisticService.Application.Feature.Order.Commands.Update;
using LogisticService.Application.Feature.Order.Queries.GetAllOrders;
using LogisticService.Application.Feature.Order.Queries.GetCurrentUserOrders;
using LogisticService.Application.Feature.Order.Queries.GetOrderDetail;
using LogisticService.Application.Feature.Order.Queries.GetOrdersForCourier;
using LogisticService.Application.Feature.Order.Queries.TrackOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.WebUI.Controllers
{
    public class OrderController : ApiController
    {
        [Authorize(Roles = "Manager,Courier")]
        [HttpGet("all")]
        public async Task<IActionResult> GetAllOrdersAsync(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = true;
            return Ok(DataSourceLoader.Load(await Mediator.Send(new GetAllOrdersQuery()), loadOptions));
        }

        [Authorize(Roles = "Manager,Courier,Client")]
        [HttpGet("current-user-orders")]
        public async Task<IActionResult> GetCurrentUserOrdersAsync(DataSourceLoadOptions loadOptions)
        {
            loadOptions.RequireTotalCount = true;

            return Ok(HttpContext.User.IsInRole("Manager")
                ? DataSourceLoader.Load(await Mediator.Send(new GetAllOrdersQuery()), loadOptions)
                : HttpContext.User.IsInRole("Courier")
                    ? DataSourceLoader.Load(await Mediator.Send(new GetOrdersForCourierQuery()), loadOptions)
                    : DataSourceLoader.Load(await Mediator.Send(new GetCurrentUserOrdersQuery()), loadOptions));
        }

        [Authorize]
        [HttpGet("details/{orderId}")]
        public async Task<IActionResult> GetDetailsOrderAsync(int orderId)
        {
            return Ok(await Mediator.Send(new GetOrderDetailQuery {OrderId = orderId}));
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddOrderAsync(CreateOrderCommand command)
            => Ok(await Mediator.Send(command));
        
        [Authorize]
        [HttpPost("take-order")]
        public async Task<IActionResult> TakeOrderAsync(TakeOrderCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPost("cancel-order")]
        public async Task<IActionResult> CancelOrderAsync(CancelOrderCommand command)
            => Ok(await Mediator.Send(command));

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrderAsync(int id, UpdateOrderCommand command)
        {
            if (id != command.Id) return BadRequest();
            await Mediator.Send(command);
            return NoContent();
        }

        [Authorize]
        [HttpDelete("remove/{id}")]
        public async Task<IActionResult> RemoveOrderAsync(int id)
        {
            if (HttpContext.User.IsInRole("Manager"))
                await Mediator.Send(new DeleteOrderCommand {Id = id});
            else
                await Mediator.Send(new ClientIsRemoveOrderCommand {Id = id});

            return NoContent();
        }

        [Authorize(Roles = "Manager")]
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteOrderAsync(int id)
        {
            await Mediator.Send(new DeleteOrderCommand {Id = id});
            return NoContent();
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{id}/approve")]
        public async Task<IActionResult> ApproveOrderAsync(int id)
        {
            await Mediator.Send(new ApproveOrderCommand {Id = id});
            return NoContent();
        }

        [Authorize(Roles = "Manager")]
        [HttpPut("{id}/send")]
        public async Task<IActionResult> SendOnKittingAsync(int id)
        {
            await Mediator.Send(new SendOnKittingCommand {Id = id});
            return NoContent();
        }

        [Authorize]
        [HttpPut("{id}/completed")]
        public async Task<IActionResult> SetOrderCompletedStatusAsync(int id)
        {
            await Mediator.Send(new OrderCompletedCommand {Id = id});
            return NoContent();
        }


        [HttpGet("track-order-{number}")]
        public async Task<IActionResult> TrackOrderAsync(int number)
        {
            return Ok(await Mediator.Send(new TrackOrderQuery {Number = number}));
        }
    }
}