using ECommerce.BL.DTOS.Cart;
using ECommerce.BL.DTOS.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.BL.Managers.Users
{
    public interface ICustomUserManager
    {
        public Task<IEnumerable<ReadUserDto>> GetAll();
        public Task<ReadUserDto?> GetByIdAsync(string id);
    }
}
