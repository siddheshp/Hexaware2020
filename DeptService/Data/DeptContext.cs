using EMS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace DeptService.Data
{
    public class DeptContext : DbContext
    {
        public DeptContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected DeptContext()
        {
        }

        public virtual DbSet<Department> Departments { get; set; }
    }
}
