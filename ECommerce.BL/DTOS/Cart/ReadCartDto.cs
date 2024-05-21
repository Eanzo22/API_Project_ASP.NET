using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommerce.BL.DTOS.CartItems;

namespace ECommerce.BL.DTOS.Cart
{
    public class ReadCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

        public IEnumerable<ReadCartItemDto> CartItems { get; set; } = [];
    }
}
