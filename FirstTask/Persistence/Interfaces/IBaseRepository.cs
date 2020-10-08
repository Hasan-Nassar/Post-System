using FirstTask.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstTask.Persistence.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        void Add(TEntity entity);
        void Remove(TEntity entity);
        void Update(TEntity entity);

    }
}


