using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class CartItem
    {
        public int Id { get; set; } // Unique identifier for the cart item
        public string UserId { get; set; } // Identifier of the user who owns the cart item
        public int ProductId { get; set; } // Identifier of the product in the cart item
        public int Quantity { get; set; } // Quantity of the product in the cart

        // Navigation property to represent the associated product
        public Product? Product { get; set; }
    }
}
