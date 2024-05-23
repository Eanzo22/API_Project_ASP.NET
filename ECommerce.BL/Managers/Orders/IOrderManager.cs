using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.OrderItems;
using ECommerce.BL.DTOS.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Orders
{
    public interface IOrderManager
    {
        public IEnumerable<ReadOrderDto> GetAll();
        public ReadOrderDto? GetById(int id);
        public  Task<ReadOrderDto?> AddOrder(List<AddOrderItemsDto> orderItemsDtos, string UserId);
        public Task<IEnumerable<ReadOrderDto>> GetAllOrdersByUserIdAsyn(string userId);

        public void Edit(EditOrderDto editOrderDto);
        public void DeleteById(int id);
    }
}
