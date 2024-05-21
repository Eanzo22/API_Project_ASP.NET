using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.CartItems;
using ECommerce.BL.DTOS.OrderItems;
using ECommerce.BL.DTOS.Orders;
using ECommerce.BL.Managers.OrderItems;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Orders
{
    public class OrderManager : IOrderManager
    {
        private readonly IUnitOfWork UnitOfWork;
        private readonly IOrderItemManager orderItemManager;

        public OrderManager(IUnitOfWork unitOfWork,IOrderItemManager orderItemManager)
        {
            UnitOfWork=unitOfWork;
            this.orderItemManager = orderItemManager;
        }
        public void AddOrder(List<AddOrderItemsDto> orderItemsDtos,string UserId )
        {
            var order = new Order
            {
                UserId = UserId,
                CreationDateTime = DateTime.Now,
            };
            foreach (var orderItemDto in orderItemsDtos) {
                var product = UnitOfWork.ProductRepo.GetById(orderItemDto.ProductId);
                if (product is  null)
                    throw new KeyNotFoundException($"Product with ID {orderItemDto.ProductId} not found.");
                var orderItem = new OrderItem
                {
                    ProductId = orderItemDto.ProductId,
                    Quantity = orderItemDto.Quantity,
                    Product = product
                };


                order.OrderItems.Add(orderItem);
            }
            order.TotalPrice = orderItemManager.CalculateTotalPrice(order.OrderItems);
            UnitOfWork.OrderRepo.Add(order);
            UnitOfWork.SaveChanges();
        }

        public void DeleteById(int id)
        {
            var order = UnitOfWork.OrderRepo.GetById(id);
            if (order is null)
                return;
            UnitOfWork.OrderRepo.Delete(order);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditOrderDto editOrderDto)
        {
            var order = UnitOfWork.OrderRepo.GetById(editOrderDto.Id);
            if (order is null) return;
            order.UserId = editOrderDto.UserId;
            UnitOfWork.SaveChanges();
        }

        public IEnumerable<ReadOrderDto> GetAll()
        {
            var orders = UnitOfWork.OrderRepo.GetAll();
            return orders.Select(o => new ReadOrderDto
            {
                Id = o.Id,
                UserId = o.UserId,
                TotalPrice= o.TotalPrice,
                CreationDateTime= o.CreationDateTime,
            });
        }

        public ReadOrderDto? GetById(int id)
        {
            var order = UnitOfWork.OrderRepo.GetById(id);
            if (order is null)
                return null;
            return new ReadOrderDto
            {
                Id = order.Id,
                UserId = order.UserId,
                OrderItems = order.OrderItems.Select(oi => new ReadOrderItemsDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                })
            };
        }
    }
}
