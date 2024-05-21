using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.CartItems
{
    public class EditCartItemDto
    {
        public int Id { get; set; }
        public int Quantity { get; set; } // Quantity of the product in the cart
        public required int CartId { get; set; } // Identifier of the user who owns the cart item
        public int ProductId { get; set; } // Identifier of the product in the cart item

    }
}
