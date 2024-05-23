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


        public async Task<ReadCartItemDto?> AddCartItem(string UserId,AddCartItemDto cartItemDto)
        {
            var cart = await UnitOfWork.CartRepo.GetByUserIdAsync(UserId);
            if (cart is null) {
                cart = new Cart { UserId = UserId };
                UnitOfWork.CartRepo.Add(cart);
            }

            var cartitem = new CartItem { 
                CartId = cart.Id,
                Quantity= cartItemDto.Quantity,
                ProductId= cartItemDto.ProductId,
            };
            UnitOfWork.CartItemsRepo.Add(cartitem);
            UnitOfWork.SaveChanges();
            return new ReadCartItemDto 
            { 
                Id = cartitem.Id,
                CartId= cartitem.CartId, 
                Quantity= cartitem.Quantity,
                ProductId= cartitem.ProductId,
            };
        }

        public async Task<bool> DeleteById(string userId , int  productId)
        {
            var cart= await UnitOfWork.CartRepo.GetByUserIdAsync(userId);
            if (cart is null)
                return false;
            var cartItem = await UnitOfWork.CartItemsRepo.GetByCartIdAndProductIdAsync(cart.Id, productId);
            if (cartItem is null) 
                return false;
            UnitOfWork.CartItemsRepo.Delete(cartItem);
            await UnitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<ReadCartItemDto?> Edit(string userId, EditCartItemDto editCartItemDto)
        {
            var cart = await UnitOfWork.CartRepo.GetByUserIdAsync(userId);
            if (cart == null) return null;

            var cartItem = await UnitOfWork.CartItemsRepo.GetByCartIdAndProductIdAsync(cart.Id, editCartItemDto.ProductId);
            if (cartItem == null) return null;

            cartItem.Quantity = editCartItemDto.Quantity;
            await UnitOfWork.SaveChangesAsync();
            return new ReadCartItemDto { 
                Id= cart.Id,
                CartId=cartItem.CartId, 
                Quantity = cartItem.Quantity,
                ProductId=cartItem.ProductId,

            };

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
