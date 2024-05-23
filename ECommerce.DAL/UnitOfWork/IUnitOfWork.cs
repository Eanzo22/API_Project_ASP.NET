using ECommerce.DAL.Data.Repositries.CartItemsRepo;
using ECommerce.DAL.Data.Repositries.CartRepo;
using ECommerce.DAL.Data.Repositries.OrderItemsRepo;
using ECommerce.DAL.Data.Repositries.OrderRepo;
using ECommerce.DAL.Data.Repositries.ProductRepo;
using ECommerce.DAL.Data.Repositries.UserRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.UnitOfWork
{
    public interface IUnitOfWork
    {
        public IOrderRepo OrderRepo{ get;  }
        public IOrderItemsRepo  OrderItemsRepo  { get; }
        public ICartItemsRepo CartItemsRepo{ get; }
        public ICartRepo CartRepo{ get; }
        public IProductRepo ProductRepo{ get; }
        public IUserRepo UserRepo { get;}
        void SaveChanges();
        Task SaveChangesAsync();

    }
}
