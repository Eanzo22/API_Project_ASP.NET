using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.CartItems;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Carts
{
    public class CartManager : ICartManager
    {
        private readonly IUnitOfWork UnitOfWork;
        public CartManager(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;   
        }
        public void AddCart(AddCartDto _cart)
        {
            var cart = new Cart {
                UserId=_cart.UserId,
            };
            UnitOfWork.CartRepo.Add(cart);
            UnitOfWork.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var cart = UnitOfWork.CartRepo.GetById(id);
            if (cart is null)
                return;
            UnitOfWork.CartRepo.Delete(cart);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditCartDto _editCartDto)
        {
            var cart = UnitOfWork.CartRepo.GetById(_editCartDto.Id);
            if (cart is null) return;
            cart.UserId = _editCartDto.UserId;
            UnitOfWork.SaveChanges();
        }


        public async Task<IEnumerable<ReadCartDto>?> GetAll()
        {
               var carts=  UnitOfWork.CartRepo.GetAllWithCartItems();
            if (carts is null)
                return null;
            return carts.Select(c => new ReadCartDto
            {
                Id = c.Id,
                UserId = c.UserId,
                CartItems = c.CartItems.Select(ci => new ReadCartItemDto
                {
                    Id = ci.Id,
                    CartId = ci.CartId,
                    ProductId = ci.ProductId,
                    Quantity = ci.Quantity,
                }).ToList()
            }).ToList() ;
        }

        public ReadCartDto? GetById(int id)
        {
            var cart = UnitOfWork.CartRepo.GetById(id);
            if (cart is null) 
                return null;
            return new ReadCartDto {
            Id= cart.Id,
            UserId = cart.UserId,
            CartItems=cart.CartItems.Select(ci=> new ReadCartItemDto
            {
                Id=ci.Id,
                CartId=ci.CartId,
                ProductId=ci.ProductId,
                Quantity=ci.Quantity,
            })
            };
        }
    }
}
