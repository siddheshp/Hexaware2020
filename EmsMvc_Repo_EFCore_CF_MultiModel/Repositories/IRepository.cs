﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc_Repo_EFCore_CF_MultiModel.Repositories
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
