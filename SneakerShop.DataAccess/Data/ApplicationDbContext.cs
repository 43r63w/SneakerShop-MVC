using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SneakerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SneakerShop.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<OrderHeader> OrderHeaders { get; set; }    

        public DbSet<OrderDetail> OrderDetails { get; set; }    
        


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "Бігові",               
                }
                );

            builder.Entity<Product>().HasData(
                new Product
                {
                    Id=1,
                    Name = "NEW BALANCE",
                    Model = "530",
                    CodeName = "4535654",
                    Description = "432",
                    Price = 5300,
                    PriceForDiscount = 2300,
                    CategoryId = 1,
                    
                }
                );

        
        }
    }
}
