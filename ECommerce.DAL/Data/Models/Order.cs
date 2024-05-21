using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class Order
    {
        public int Id { get; set; } 
        public required string UserId { get; set; } 
        public required User User { get; set; }
        public DateTime CreationDateTime { get; set; } 
        public decimal TotalPrice { get; set; } 


        public ICollection<OrderItem>? OrderItems { get; set; }
    }
}
