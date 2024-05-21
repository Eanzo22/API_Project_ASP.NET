using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Carts
{
    public interface ICartManager
    {
        public IEnumerable<ReadCartDto> GetAll();
        public ReadCartDto? GetById(int id);
        public void AddCart(AddCartDto cart);
        public void Edit(EditCartDto editCartDto);
        public void DeleteById(int id);
    }
}
