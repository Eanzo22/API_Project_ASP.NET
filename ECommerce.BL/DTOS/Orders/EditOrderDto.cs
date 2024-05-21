using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.Orders
{
    public class EditOrderDto
    {
        public string UserId { get; set; } = string.Empty;
        public DateTime CreationDateTime { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
