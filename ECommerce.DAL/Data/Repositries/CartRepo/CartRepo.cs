using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.CartRepo
{
    public class CartRepo : GenericRepo<Cart>,ICartRepo
    {
        public CartRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }

        public Cart? GetCartWithUser(int id)
        {
            return ecommerceContext.carts.Include(c => c.User).FirstOrDefault(c => c.Id == id);
        }

        public Cart? GetCartWithUserAndCartItems(int id)
        {
            return ecommerceContext.carts.Include(c => c.User).Include(c => c.CartItems).FirstOrDefault(c => c.Id == id);
        }

    }
}
