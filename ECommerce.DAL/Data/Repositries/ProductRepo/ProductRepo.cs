using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.ProductRepo
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        public ProductRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }
    }
}
