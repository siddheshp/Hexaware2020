using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using TestEmsWebApp.Models;

namespace TestEmsWebApp.Data
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext([NotNullAttribute] DbContextOptions options) : base(options)
        {
        }

        public EmployeeContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=testDB;Username=postgres;Password=abcd@1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    Id = 1,
                    Name = "Param",
                    DateOfJoining = new DateTime(2020, 9, 9),
                    Phone = 9988990098,
                    Email = "param@hexaware.com",
                    Gender = Gender.Male
                },
                new Employee
                {
                    Id = 2,
                    Name = "Shona",
                    DateOfJoining = new DateTime(2020, 9, 9),
                    Phone = 9988990098,
                    Email = "shona@hexaware.com",
                    Gender = Gender.Female
                });

            modelBuilder.UseIdentityColumns();
            base.OnModelCreating(modelBuilder);
        }

        public virtual DbSet<Employee> Employees { get; set; }
    }
}
