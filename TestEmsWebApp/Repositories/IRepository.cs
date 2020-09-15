using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestEmsWebApp.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> Get();
        T Get(object key);
        bool Add(T entity);
        bool Update(T entity);
        bool Delete(T entity);
    }
}
