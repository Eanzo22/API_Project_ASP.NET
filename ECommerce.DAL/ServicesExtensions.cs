using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Repositries.CartItemsRepo;
using ECommerce.DAL.Data.Repositries.CartRepo;
using ECommerce.DAL.Data.Repositries.OrderItemsRepo;
using ECommerce.DAL.Data.Repositries.OrderRepo;
using ECommerce.DAL.Data.Repositries.ProductRepo;
using ECommerce.DAL.Data.Repositries.UserRepo;
using ECommerce.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL
{
    public static class ServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionstring = configuration.GetConnectionString("EcommerceDB");
            services.AddDbContext<EcommerceContext>(options=>options.UseSqlServer(connectionstring));
            services.AddScoped<IOrderItemsRepo, OrderItemsRepo>();
            services.AddScoped<IOrderRepo, OrderRepo>();
            services.AddScoped<ICartRepo, CartRepo>();
            services.AddScoped<ICartItemsRepo, CartItemsRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork.UnitOfWork>();
        }
    }
}
