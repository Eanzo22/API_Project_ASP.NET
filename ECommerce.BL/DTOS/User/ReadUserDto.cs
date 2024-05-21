using ECommerce.BL.DTOS.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.User
{
    public class ReadUserDto
    {
        public string Id { get; set; } = string.Empty;
        public string UserName { get; set; }= string.Empty;
        public string UserEmail { get; set; } = string.Empty;
        public IEnumerable<ReadOrderDto> Orders { get; set; } = [];
    }
}
