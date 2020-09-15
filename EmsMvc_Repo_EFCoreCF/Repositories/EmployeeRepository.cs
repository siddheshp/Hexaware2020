using EmsMvc.Models;
using EmsMvc_Repo_EFCoreCF.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc.Repositories
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
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log
                throw ex; //throwing wrapper, no stack trace
                //throw;      //rethrow
            }
        }

        public bool Delete(object key)
        {
            //employeeList.Remove()
            return true;
        }

        public Employee Get(object key)
        {
            context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            return context.Employees.Find(key);
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees;
        }

        public bool Update(Employee entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                //context.Employees.Update(entity);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                //log
                throw ex;
            }
        }
    }
}
