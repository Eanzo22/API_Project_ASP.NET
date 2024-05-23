using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.DTOS.User
{
    public class TokenDto
    {
        public string JwtToken { get; set; } = string.Empty;
        public string ExpairyDate { get; set; } = string.Empty;
    }
}
