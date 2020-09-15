using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestEmsWebApp.Data;
using TestEmsWebApp.Models;

namespace TestEmsWebApp.Repositories
{
    public class EmployeeRepository : IRepository<Employee>
    {
        private EmployeeContext context;

        public EmployeeRepository(EmployeeContext context)
        {
            this.context = context;
        }
        public bool Add(Employee entity)
        {
            try
            {
                context.Employees.Add(entity);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        public bool Delete(Employee entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees;
        }

        public Employee Get(object key)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            throw new NotImplementedException();
        }
    }
}
