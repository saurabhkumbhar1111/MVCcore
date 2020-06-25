using Microsoft.EntityFrameworkCore;
using MvcCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcCore.dal
{
    public class CustomerDal : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-0RST2G8\SQL;Initial Catalog=CustomerDB;Integrated Security=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerModel>().ToTable("tblCustomer");  //Mapping code

            modelBuilder.Entity<CustomerModel>().HasKey(p => p.name);  //primary key
        }

        public DbSet<CustomerModel> CustomerModels { get; set; }
    }
}
