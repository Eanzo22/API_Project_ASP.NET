using ECommerce.DAL.Data.Context;
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
    public class UnitOfWork : IUnitOfWork
    {
        public IOrderRepo OrderRepo { get; }

        public IOrderItemsRepo OrderItemsRepo { get; }

        public ICartItemsRepo CartItemsRepo { get; }

        public ICartRepo CartRepo { get; }

        public IProductRepo ProductRepo { get; }

        public IUserRepo UserRepo { get; }

        private EcommerceContext _context;

        public UnitOfWork(IOrderRepo orderRepo,
                          IOrderItemsRepo orderItemsRepo,
                          ICartItemsRepo cartItemsRepo,
                          ICartRepo cartRepo,
                          IProductRepo productRepo,
                          IUserRepo userRepo,
                          EcommerceContext ecommerceContext)
        {
            this.OrderRepo = orderRepo;
            this.OrderItemsRepo = orderItemsRepo;
            this.CartItemsRepo = cartItemsRepo;
            this.CartRepo = cartRepo;
            this.ProductRepo = productRepo;
            this.UserRepo = userRepo;
            _context=ecommerceContext;
            
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
