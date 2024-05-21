using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.Cart
{
    public class EditCartDto
    {
        public int Id { get; set; }
        public string UserId { get; set; } = string.Empty;

    }
}
