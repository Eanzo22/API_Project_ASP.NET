using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.CartItemsRepo
{
    public interface ICartItemsRepo:IGenericRepo<CartItem>
    {
        Task<CartItem?> GetByCartIdAndProductIdAsync(int id, int productId);
        CartItem? GetCartItemWithCartAndProduct(int id);
    }
}
