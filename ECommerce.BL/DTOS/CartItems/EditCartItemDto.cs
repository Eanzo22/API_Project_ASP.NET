using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.CartItems
{
    public class EditCartItemDto
    {

        public int Quantity { get; set; } // Quantity of the product in the cart
        public int ProductId { get; set; } // Identifier of the product in the cart item

    }
}
