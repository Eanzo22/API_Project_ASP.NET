using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.CartItems
{
    public class AddCartItemDto
    {
        public int Id { get; set; } 
        public int Quantity { get; set; } 
        public required int CartId { get; set; }
        public int ProductId { get; set; } 

    }
}
