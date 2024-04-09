using _004_Example4_Refactorizacion.DTOs.Orders;
using _004_Example4_Refactorizacion.Services.Orders;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _004_Example4_Refactorizacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IOrdersService _ordersService;

        public OrdersController([FromKeyedServices("OrdersService")]IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<OrdersGetDTO>>> GetOrders()
        {
            var ordersDTO = await _ordersService.GetOrders();
            return Ok(ordersDTO);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<OrdersGetDTO>> GetOrder(Guid id)
        {
            var orderDTO = await _ordersService.GetOrderById(id);
            return orderDTO == null ? NotFound() : Ok(orderDTO);
        }

        [HttpPost]
        public async Task<ActionResult<OrdersGetDTO>> AddOrder(OrdersPostDTO ordersPostDTO)
        {
            var orderDTO = await _ordersService.AddOrder(ordersPostDTO);
            if (orderDTO == null) return NotFound();

            return CreatedAtAction(nameof(GetOrder), new { Id = orderDTO.Id }, orderDTO);

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<OrdersGetDTO>> DeleteOrder(Guid id)
        {
            var orderDTO = await _ordersService.DeleteOrder(id);
            return orderDTO == null ? NotFound() : Ok(orderDTO);
        }
    }
}
