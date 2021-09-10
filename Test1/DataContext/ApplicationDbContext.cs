using Test1.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test1.DataContext
{
    class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=localhost; Initial Catalog=BrandNew;Integrated Security=True");
        }
        public DbSet<Accounts> tbAccounts { get; set; }
    }
}
