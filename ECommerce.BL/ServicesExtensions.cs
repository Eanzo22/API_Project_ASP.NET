using ECommerce.BL.Managers.CartItems;
using ECommerce.BL.Managers.Carts;
using ECommerce.BL.Managers.OrderItems;
using ECommerce.BL.Managers.Orders;
using ECommerce.BL.Managers.Products;
using ECommerce.BL.Managers.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL
{
    public static class ServicesExtensions
    {
        public static void AddBLServices(this IServiceCollection services) {
            services.AddScoped<ICartItemManager,CartItemManager>();
            services.AddScoped<ICartManager,CartManager>();
            services.AddScoped<IOrderItemManager,OrderItemManager>();
            services.AddScoped<IOrderManager,OrderManager>();
            services.AddScoped<IProductManager,ProductManager>();
            services.AddScoped<ICustomUserManager,CustomUserManager>();
        }
    }
}
