using Microsoft.EntityFrameworkCore;
using SampleProductService.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SampleProductService.Data.DBContexts
{
   public class ApplicationDBContext :DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category { Id = 1, Name = "Electronics", Description = "Electronic Items" }, new Category { Id = 2, Name = "Books", Description = "Books" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "HP LapTop", Description = "HP Laptop",Price=750.00M,CategoryId =1 }, new Product { Id = 2, Name = "Fiction", Description = "English Fiction",Price =20.00M,CategoryId =2 });
        }
    }
}
