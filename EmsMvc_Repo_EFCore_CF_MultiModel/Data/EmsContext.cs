using EmsMvc_Repo_EFCore_CF_MultiModel.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace EmsMvc_Repo_EFCore_CF_MultiModel.Data
{
    public class EmsContext : DbContext
    {
        public EmsContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        protected EmsContext()
        {
        }

        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Project> Projects { get; set; } 
    }
}
