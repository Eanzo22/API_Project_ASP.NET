using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.OrderItems;
using ECommerce.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.OrderItems
{
    public interface IOrderItemManager
    {
        public IEnumerable<ReadOrderItemsDto> GetAll();
        public ReadOrderItemsDto? GetById(int id);
        public void AddOrderItem(AddOrderItemsDto orderItemsDto);
        public void Edit(EditOrderItemsDto editOrderItemsDto);
        public void DeleteById(int id);
        public void UpdateOrderTotalPrice(int orderId);
        public decimal CalculateTotalPrice(IEnumerable<OrderItem> orderItems);
    }
}
