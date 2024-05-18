
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Models
{
    public class User: IdentityUser
    {
      
        public Cart? Cart { get; set; }
        public ICollection<Order>? orders { get; set; }
    }
}
