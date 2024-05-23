using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.CartItemsRepo
{
    public class CartItemsRepo : GenericRepo<CartItem>, ICartItemsRepo
    {
        public CartItemsRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }

        public async Task<CartItem?> GetByCartIdAndProductIdAsync(int id, int productId)
        {
            return  await ecommerceContext.cartItems.FirstOrDefaultAsync(ci=> ci.CartId==id && ci.ProductId==productId);
        }

        public CartItem? GetCartItemWithCartAndProduct(int id)
        {
            return ecommerceContext.cartItems.Include(ci=>ci.Cart).Include(ci=>ci.Product).FirstOrDefault(ci=>ci.Id==id);
        }
    }
}
