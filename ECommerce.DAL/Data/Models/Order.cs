using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; } // Unique identifier for the order
        public int UserId { get; set; } // Identifier of the user who placed the order
        public DateTime CreationDateTime { get; set; } // Date and time when the order was created
        public decimal TotalPrice { get; set; } // Total price of the order

        // Navigation property to represent the order items associated with the order
        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
