using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.OrderRepo
{
    public interface IOrderRepo:IGenericRepo<Order>
    {
        Order? GetOrderWithUserAndOrderItems(int id);
        Task<IEnumerable<Order>> GetOrderByUserIdAsync(string id);
    }
}
