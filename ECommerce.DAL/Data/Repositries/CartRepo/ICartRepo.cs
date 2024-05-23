using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.CartRepo
{
    public interface ICartRepo :IGenericRepo<Cart>
    {
        IEnumerable<Cart> GetAllWithCartItems();
        Task<Cart?> GetByUserIdAsync(string userId);
        Cart? GetCartWithUser(int id);
        Cart? GetCartWithUserAndCartItems(int id);
    }
}
