using Microsoft.AspNetCore.Mvc;
using Yumyum.Core.DTOs;
using Yumyum.Infrastructure.Services.Orders;

namespace Yumyum.API.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController (IOrderService orderService)
        {
            _orderService = orderService;

        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderDto input)
        {
            var order = await _orderService.Create(input);
            return Ok(order);

        }
        [HttpPut]
        public async Task<IActionResult> Update (UpdateOrderDto input)
        {
            var order = await _orderService.Update(input);
            return Ok(order);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var order = await _orderService.GetAll();
            return Ok(order);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
           await _orderService.Delete(id);
            return Ok();
        }

    }
}
