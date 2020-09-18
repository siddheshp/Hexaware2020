using System;
using System.Collections.Generic;

namespace EMS.Repositories
{
    public interface IRepository<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(object key);
        T Get(object key);
        IEnumerable<T> Get();
    }
}
