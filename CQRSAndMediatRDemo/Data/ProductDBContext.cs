﻿using CQRSAndMediatRDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRSAndMediatRDemo.Data
{
    public class ProductDBContext :DbContext
    {
        public DbSet<Product> products { get; set; }
       
        public DbSet<Role> roles { get; set; }  
        public DbSet<User> users { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                    .Build();
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("DatabaseConnection"));
        }
    }
}
