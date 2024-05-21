using ECommerce.BL.DTOS.CartItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.CartItems
{
    public interface ICartItemManager
    {
        public IEnumerable<ReadCartItemDto> GetAll();
        public ReadCartItemDto? GetById(int id);
        public void AddCartItem(AddCartItemDto cartItem);
        public void Edit(EditCartItemDto editCartItemDto);
        public void DeleteById(int id);
    }
}
