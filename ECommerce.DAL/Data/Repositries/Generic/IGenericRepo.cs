using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Repositries.Generic
{
    public interface IGenericRepo<TEntity>
    where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
        TEntity? GetById(int id);
        void Add(TEntity entity);
        //void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
