using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public  string UserId { get; set; } =string.Empty;
        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = [];
    }
}
