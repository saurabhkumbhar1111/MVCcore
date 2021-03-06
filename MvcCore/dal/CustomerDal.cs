﻿using Microsoft.EntityFrameworkCore;
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
            //primary key
            modelBuilder.Entity<CustomerModel>().HasKey(p => p.id);

            modelBuilder.Entity<Address>().HasKey(p => p.id);

            //identity specification -->
            //modelBuilder.Entity<CustomerModel>().Property(t => t.id).ValueGeneratedNever();

            //Mapping code
            modelBuilder.Entity<CustomerModel>().ToTable("tblCustomer");

            modelBuilder.Entity<Address>().ToTable("tblAddress");

            //one to many relationship
            modelBuilder.Entity<CustomerModel>()
            .HasMany(a => a.addresses)
            .WithOne(c => c.customer);
        }

        public DbSet<CustomerModel> CustomerModels { get; set; }
        

    }
}
