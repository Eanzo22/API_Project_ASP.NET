using ECommerce.BL.DTOS.OrderItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.Orders
{
    public class ReadOrderDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }
        public decimal TotalPrice { get; set; }
        public IEnumerable<ReadOrderItemsDto> OrderItems { get; set; } = [];
    }
}
