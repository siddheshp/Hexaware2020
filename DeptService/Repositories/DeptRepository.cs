using DeptService.Data;
using EMS.Models;
using EMS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeptService.Repositories
{
    public class DeptRepository : IRepository<Department>
    {
        private DeptContext context;

        public DeptRepository(DeptContext context)
        {
            this.context = context;
        }
        public bool Add(Department entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(object key)
        {
            throw new NotImplementedException();
        }

        public Department Get(object key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> Get()
        {
            return context.Departments;
        }

        public bool Update(Department entity)
        {
            throw new NotImplementedException();
        }
    }
}
