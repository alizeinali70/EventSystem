using EventSystem.OrderService.Application.Commands;
using EventSystem.OrderService.Application.Handler;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventSystem.OrderService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    internal sealed class OrdersController(CreateOrderHandler handler) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderCommand command)
        {
            var orderId = await handler.Handle(command);
           
            return Ok(orderId);
        }
    }
}
