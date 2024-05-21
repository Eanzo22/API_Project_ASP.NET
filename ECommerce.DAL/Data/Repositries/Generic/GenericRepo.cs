using ECommerce.DAL.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.Generic
{
    public class GenericRepo<TEntity> : IGenericRepo<TEntity> where TEntity : class
    {
        protected readonly EcommerceContext ecommerceContext;

        public GenericRepo(EcommerceContext ecommerceContext)
        {
            this.ecommerceContext = ecommerceContext;
        }
        public void Add(TEntity entity)
        {
            ecommerceContext.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            ecommerceContext.Set<TEntity>().Remove(entity);
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return ecommerceContext.Set<TEntity>().Where(predicate).AsEnumerable();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return ecommerceContext.Set<TEntity>().AsNoTracking();
        }

        public TEntity? GetById(int id)
        {
            return ecommerceContext.Set<TEntity>().Find(id);
        }

/*        public void Update(TEntity entity)
        {
            
        }*/ // since we have GetByID which uses tracking , we can edit the recored by getting it and savechanges directly  
    }
}
