using ECommerce.DAL.Data.Context;
using ECommerce.DAL.Data.Models;
using ECommerce.DAL.Data.Repositries.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.UserRepo
{
    public class UserRepo : GenericRepo<User>, IUserRepo
    {
        public UserRepo(EcommerceContext ecommerceContext) : base(ecommerceContext)
        {
        }


        public async Task<User?> GetUserWithOrdersAndCartAsync(string id)
        {
            return await ecommerceContext.users.Include(u => u.Cart).Include(u => u.orders).FirstOrDefaultAsync(u=>u.Id==id);

        }
    }
}
