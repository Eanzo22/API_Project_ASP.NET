using ECommerce.BL.DTOS.CartItems;
using ECommerce.DAL.Data.Models;
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
        public Task<ReadCartItemDto?> AddCartItem(string userId,AddCartItemDto cartItem);
        public Task<ReadCartItemDto?> Edit(string userId,EditCartItemDto editCartItemDto);
        public Task<bool> DeleteById(string userId , int  productId)
        ;
    }
}
