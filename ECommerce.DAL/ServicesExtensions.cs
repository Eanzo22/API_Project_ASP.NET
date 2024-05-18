using ECommerce.DAL.Data.Context;
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
        }
    }
}
