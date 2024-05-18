using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class OrderItem
    {
        public int Id { get; set; } // Unique identifier for the order item
        public int OrderId { get; set; } // Identifier of the order to which the item belongs
        public Order? Order { get; set; }
        public int ProductId { get; set; } // Identifier of the product in the order item
        public Product? Product { get; set; }
        public int Quantity { get; set; } // Quantity of the product in the order item

    }
}
