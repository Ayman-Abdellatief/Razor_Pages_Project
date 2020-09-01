using Microsoft.EntityFrameworkCore;
using Razor_Pages_Project.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Razor_Pages_Project.Services
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {


        }

        public DbSet<Employee> Employees { get; set; }
    }
}
