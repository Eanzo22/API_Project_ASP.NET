using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.OrderRepo
{
    public class OrderRepo : GenericRepo<Order>, IOrderRepo
    {
        public OrderRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }

        public async Task<IEnumerable<Order>> GetOrderByUserIdAsync(string id)
        {
            return await ecommerceContext.orders.Where(o=>o.UserId==id).Include(o=>o.OrderItems).ToListAsync();
        }

        public Order? GetOrderWithUserAndOrderItems(int id)
        {
            return ecommerceContext.orders.Include(o => o.User).Include(o => o.OrderItems).FirstOrDefault(o=>o.Id==id);
        }
    }
}
