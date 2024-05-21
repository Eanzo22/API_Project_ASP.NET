using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.Orders
{
    public class AddOrderDto
    {
        public int Id { get; set; } 
        public string UserId { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }
        public decimal TotalPrice { get; set; } 
    }
}
