using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class Cart
    {
        public int Id { get; set; } // Unique identifier for the cart
        public int UserId { get; set; } // Identifier of the user who owns the cart
                                      
        // Navigation property to represent the associated user
        public User? User { get; set; }
        // Navigation property to represent the cart items associated with the cart
        public ICollection<CartItem>? CartItems { get; set; }
    }
}
