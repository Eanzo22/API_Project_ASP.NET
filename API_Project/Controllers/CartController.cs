using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.CartItems;
using ECommerce.BL.DTOS.Products;
using ECommerce.BL.Managers.CartItems;
using ECommerce.BL.Managers.Carts;
using ECommerce.DAL.Data.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace API_Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController: ControllerBase
    {
        private readonly ICartManager cartManager;
        private readonly ICartItemManager cartItemManager;
        private readonly EcommerceContext ecommerceContext;

        public CartController(ICartManager cartManager,ICartItemManager cartItemManager  ,EcommerceContext ecommerceContext)
        {
            this.cartManager = cartManager;
            this.cartItemManager = cartItemManager;
            this.ecommerceContext = ecommerceContext;
        }
        [HttpGet]
        [Authorize(Policy = "AdminOnly")]
        public ActionResult<IEnumerable<ReadCartDto>> GetAll() {
        var carts = cartManager.GetAll();
            if(carts is null)
                return NotFound();
            return Ok(carts);
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<ReadCartItemDto>> AddToCart(AddCartItemDto addCartItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await cartItemManager.AddCartItem(userId, addCartItemDto);
            if (result is null)
                return BadRequest("Unable to add cartItem");
            return Ok(result);

        }
        [HttpDelete("{productId}")]
        [Authorize]
        public async Task<IActionResult> RemoveFromCart(int productId) {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            var result = await cartItemManager.DeleteById(userId, productId);
            if (!result)
            {
                return BadRequest($"Unable to remove item from cart.{result}");
            }
            return Ok();

        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> EditItemQuantity(EditCartItemDto editCartItemDto)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;

            var result = await cartItemManager.Edit(userId, editCartItemDto);
            if (result == null)
            {
                return BadRequest("Unable to edit item quantity.");
            }
            return Ok(result);
        }

    }
}
