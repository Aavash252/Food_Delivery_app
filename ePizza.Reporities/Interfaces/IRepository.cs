using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePizza.Repositories.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity FindById(object Id);

        TEntity Find(object Id);

        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object Id);
        void Remove(TEntity entity);

        int SaveChanges();

    }
}
