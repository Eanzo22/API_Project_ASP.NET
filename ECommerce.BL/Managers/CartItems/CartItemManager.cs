using ECommerce.BL.DTOS.CartItems;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.CartItems
{
    public class CartItemManager : ICartItemManager
    {
        private readonly IUnitOfWork UnitOfWork;
        public CartItemManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }


        public void AddCartItem(AddCartItemDto cartItem)
        {
            var cartitem = new CartItem { 
                CartId = cartItem.CartId,
                Quantity=cartItem.Quantity,
                ProductId= cartItem.ProductId,
            };
            UnitOfWork.CartItemsRepo.Add(cartitem);
            UnitOfWork.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var cartitem=UnitOfWork.CartItemsRepo.GetById(id);
            if (cartitem is null)
                return;
            UnitOfWork.CartItemsRepo.Delete(cartitem);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditCartItemDto editCartItemDto)
        {
            var cartitem=UnitOfWork.CartItemsRepo.GetById(editCartItemDto.Id);
            if (cartitem is null)
                return;
            cartitem.Quantity = editCartItemDto.Quantity;
            cartitem.CartId = editCartItemDto.CartId;
            cartitem.ProductId= editCartItemDto.ProductId;
            UnitOfWork.SaveChanges();

        }

        public IEnumerable<ReadCartItemDto> GetAll()
        {
            var cartItems=UnitOfWork.CartItemsRepo.GetAll();
            return cartItems
                .Select(ci => new ReadCartItemDto {
                    Id=ci.Id,
                    CartId=ci.CartId,
                    ProductId=ci.ProductId,
                    Quantity=ci.Quantity,
                });
        }

        public ReadCartItemDto? GetById(int id)
        {
            var cartItem = UnitOfWork.CartItemsRepo.GetById(id);
            if (cartItem is null)
                return null;
            return new ReadCartItemDto {
                CartId = cartItem.CartId, 
                ProductId = cartItem.ProductId,
                Quantity = cartItem.Quantity,
                Id= cartItem.Id

            };
        }
    }
}
