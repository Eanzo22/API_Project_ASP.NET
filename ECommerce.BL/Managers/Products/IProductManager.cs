using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Products
{
    public interface IProductManager
    {
        public IEnumerable<ReadProductDto> GetAll();
        public ReadProductDto? GetById(int id);
        public void AddProduct(AddProductDto product);
        public void Edit(EditProductDto editProductDto);
        public void DeleteById(int id);
    }
}
