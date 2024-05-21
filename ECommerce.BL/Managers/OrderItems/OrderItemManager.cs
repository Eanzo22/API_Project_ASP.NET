using ECommerce.BL.DTOS.CartItems;
using ECommerce.BL.DTOS.OrderItems;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.OrderItems
{
    public class OrderItemManager : IOrderItemManager
    {
        private readonly IUnitOfWork UnitOfWork;
        public OrderItemManager(IUnitOfWork unitOfWork )
        {
            UnitOfWork = unitOfWork;   
        }
        public void AddOrderItem(AddOrderItemsDto orderItemsDto)
        {
            var orderItem = new OrderItem { 
            OrderId= orderItemsDto.OrderId,
            ProductId= orderItemsDto.ProductId,
            Quantity= orderItemsDto.Quantity,
            };
            UnitOfWork.OrderItemsRepo.Add(orderItem);
            UnitOfWork.SaveChanges();
        }


        public void DeleteById(int id)
        {
            var orderitem = UnitOfWork.OrderItemsRepo.GetById(id);
            if (orderitem is null)
                return;
            UnitOfWork.OrderItemsRepo.Delete(orderitem);
            UnitOfWork.SaveChanges();
        }

        public void Edit(EditOrderItemsDto editOrderItemsDto)
        {
            var orderitem = UnitOfWork.OrderItemsRepo.GetById(editOrderItemsDto.Id);
            if (orderitem is null)
                return;
            if (orderitem.Quantity != editOrderItemsDto.Quantity || orderitem.ProductId != editOrderItemsDto.ProductId)
                UpdateOrderTotalPrice(orderitem.OrderId);
            orderitem.Quantity = editOrderItemsDto.Quantity;
            orderitem.OrderId = editOrderItemsDto.OrderId;
            orderitem.ProductId = editOrderItemsDto.ProductId;

            UnitOfWork.SaveChanges();
        }

        public IEnumerable<ReadOrderItemsDto> GetAll()
        {
            var orderItems = UnitOfWork.OrderItemsRepo.GetAll();
            return orderItems
                .Select(oi => new ReadOrderItemsDto
                {
                    Id = oi.Id,
                    OrderId = oi.OrderId,
                    ProductId = oi.ProductId,
                    Quantity = oi.Quantity,
                });
        }

        public ReadOrderItemsDto? GetById(int id)
        {
            var orderItem = UnitOfWork.OrderItemsRepo.GetById(id);
            if (orderItem is null)
                return null;
            return new ReadOrderItemsDto
            {
                OrderId = orderItem.OrderId,
                ProductId = orderItem.ProductId,
                Quantity = orderItem.Quantity,
                Id = orderItem.Id

            };
        }

        public void UpdateOrderTotalPrice(int orderId)
        {
            var order = UnitOfWork.OrderRepo.GetById(orderId);
            if(order is null)
                return;
            var orderItems = UnitOfWork.OrderItemsRepo.Find(oi => oi.OrderId == orderId);
            order.TotalPrice = CalculateTotalPrice(orderItems);
            UnitOfWork.SaveChanges();
        }
        public decimal CalculateTotalPrice(IEnumerable<OrderItem> orderItems)
        {
           return orderItems.Sum(oi=>oi.Quantity*(oi.Product?.Price?? 0));
        }
    }
}
