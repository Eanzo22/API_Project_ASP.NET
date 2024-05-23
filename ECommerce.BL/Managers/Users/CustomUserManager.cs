using ECommerce.BL.DTOS.Orders;
using ECommerce.BL.DTOS.User;
using ECommerce.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Users
{
    public class CustomUserManager : ICustomUserManager
    {
        private readonly IUnitOfWork unitOfWork;

        public CustomUserManager(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<ReadUserDto>> GetAll()
        {
            var users =  await unitOfWork.UserRepo.GetAllUsersWithOrdersAndCartAsync();
            return users.Select(x => new ReadUserDto {
                Id = x?.Id ?? string.Empty,
                UserEmail = x?.Email ?? string.Empty,
                UserName = x?.UserName ?? string.Empty,
                CartId = x?.Cart?.Id ?? 0,
                Orders = x?.orders.Select(o => new ReadOrderDto {
                    Id = o.Id,
                    CreationDateTime = o.CreationDateTime,
                    TotalPrice = o.TotalPrice,
                }).ToList() ?? []
            });
        }

        public async Task<ReadUserDto?> GetByIdAsync(string id)
        {
            var User = await unitOfWork.UserRepo.GetUserWithOrdersAndCartAsync(id);
            if(User is null) 
                return null;
            return new ReadUserDto
            {
                Id = User.Id,
                UserEmail = User.Email ?? string.Empty,
                UserName = User.UserName ?? string.Empty,
                CartId = User.Cart?.Id ?? 0,
                Orders = User.orders.Select(o => new ReadOrderDto
                {
                    Id = o.Id,
                    CreationDateTime = o.CreationDateTime,
                    TotalPrice = o.TotalPrice,
                }).ToList()
            };
        }
        
    }
}
