using ECommerce.BL.DTOS.OrderItems;
using ECommerce.BL.DTOS.Orders;
using ECommerce.BL.Managers.OrderItems;
using ECommerce.BL.Managers.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using System.Security.Claims;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderItemManager orderItemManager;
        private readonly IOrderManager orderManager;

        public OrderController(IOrderItemManager orderItemManager, IOrderManager orderManager)
        {
            this.orderItemManager = orderItemManager;
            this.orderManager = orderManager;
        }
        [HttpGet]
        [Authorize(Policy ="AdminOnly")]
        public ActionResult<IEnumerable <ReadOrderDto>> GetAllOrders() {
            var orders = orderManager.GetAll();
            if (orders is null)
                return BadRequest();
            return Ok(orders);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PlaceOrder([FromBody] List<AddOrderItemsDto> orderDtos)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await orderManager.AddOrder(orderDtos, userId );
            if (result == null)
            {
                return BadRequest("Unable to place order.");
            }
            return StatusCode(StatusCodes.Status201Created,result);
        }
        [HttpGet("history")]
        [Authorize]
        public async Task<ActionResult<IEnumerable<ReadOrderDto>>> GetOrdersHistory() {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var orders = await orderManager.GetAllOrdersByUserIdAsyn(userId);
            if (orders is null)
                return BadRequest();
            return Ok(orders);
            
        }
    }
}
