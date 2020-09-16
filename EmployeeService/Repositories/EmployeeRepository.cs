﻿using EmployeeService.Data;
using EmployeeService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeService.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
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
                //check if emp exists
                //yes, update
                //no, insert
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
            // update flag
            var emp = Get(key);
            if (emp == null)
            {
                return false;
            }
            try
            {
                context.Employees.Remove(emp);
                int result = context.SaveChanges();
                if (result > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
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

        public IEnumerable<Employee> GetByGender(Gender gender)
        {
            try
            {
                return context.Employees.Where(e => e.Gender == gender);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
