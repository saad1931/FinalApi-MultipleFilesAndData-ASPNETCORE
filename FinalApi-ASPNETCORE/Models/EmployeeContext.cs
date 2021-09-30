using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinalApi_ASPNETCORE.Models;
namespace FinalApi_ASPNETCORE.Models
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-CT235QF;Initial Catalog=Employees-Api;Integrated Security=True");
        }
        public DbSet<Employee>Employees{ get; set; }
        //public DbSet<EmployeeViewModel> EmployeeViewModels { get; set; }

    }
}
