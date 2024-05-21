using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.OrderItemsRepo
{
    public class OrderItemsRepo : GenericRepo<OrderItem>, IOrderItemsRepo
    {
        public OrderItemsRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }

        public OrderItem? GetOrderItemWithProductAndOrder(int id)
        {
            return ecommerceContext.orderItems.Include(oi => oi.Order).Include(oi => oi.Product).FirstOrDefault(oi=>oi.Id==id);
        }
    }
}
