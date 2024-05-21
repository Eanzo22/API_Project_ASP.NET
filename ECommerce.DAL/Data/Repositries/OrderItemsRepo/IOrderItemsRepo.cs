using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.OrderItemsRepo
{
    public interface IOrderItemsRepo:IGenericRepo<OrderItem>
    {
        OrderItem? GetOrderItemWithProductAndOrder(int id);
    }
}
