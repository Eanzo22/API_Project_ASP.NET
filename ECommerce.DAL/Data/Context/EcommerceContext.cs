using ECommerce.DAL.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Context
{
    public class EcommerceContext:IdentityDbContext<User>
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> dbContextOptions ):base(dbContextOptions)
        {
            
        }
        public DbSet<Cart> carts => Set<Cart>();
        public DbSet<CartItem> cartItems => Set<CartItem>();
        public DbSet<Order> orders => Set<Order>();
        public DbSet<OrderItem> orderItems => Set<OrderItem>();
        public DbSet<User> users => Set<User>();
        public DbSet<Product> products => Set<Product>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            #region RelationShips
            #region Cart
            modelBuilder.Entity<Cart>().HasMany<CartItem>(c=>c.CartItems).WithOne(ci=>ci.Cart).HasForeignKey(ci=>ci.CartId);//see what's the output of this in the migration
            #endregion
            #region User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId);
            #endregion
            #region Order
            modelBuilder.Entity<Order>()
                .HasMany(o => o.OrderItems)
                .WithOne(oi=>oi.Order)
                .HasForeignKey(oi => oi.OrderId);
            modelBuilder.Entity<Order>()
                .HasOne(o => o.User)
                .WithMany(u => u.orders)
                .HasForeignKey(o=>o.UserId);
            #endregion
            #region OrderItem
            modelBuilder.Entity<OrderItem>()
                .HasOne(oi => oi.Product)
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);
            #endregion
            #region CartItem

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductId);
            #endregion
            #endregion
            #region Seeding Data 
            #region Product 
            modelBuilder.Entity<Product>()
                .HasData(new Product
                {
                    Id = 1,
                    Name = "Product 1",
                    Description = "Description for Product 1",
                    Category = "Category 1",
                    Price = 9.99m,
                    ImageURL = "https://example.com/product1.jpg"
                },
                new Product
                {
                    Id = 2,
                    Name = "Product 2",
                    Description = "Description for Product 2",
                    Category = "Category 2",
                    Price = 19.99m,
                    ImageURL = "https://example.com/product2.jpg"
                },
                new Product
                {
                    Id = 3,
                    Name = "Product 3",
                    Description = "Description for Product 3",
                    Category = "Category 3",
                    Price = 29.99m,
                    ImageURL = "https://example.com/product3.jpg"
                },
                new Product
                {
                    Id = 4,
                    Name = "Product 4",
                    Description = "Description for Product 4",
                    Category = "Category 1",
                    Price = 14.99m,
                    ImageURL = "https://example.com/product4.jpg"
                },
                new Product
                {
                    Id = 5,
                    Name = "Product 5",
                    Description = "Description for Product 5",
                    Category = "Category 2",
                    Price = 24.99m,
                    ImageURL = "https://example.com/product5.jpg"
                },
                new Product
                {
                    Id = 6,
                    Name = "Product 6",
                    Description = "Description for Product 6",
                    Category = "Category 3",
                    Price = 34.99m,
                    ImageURL = "https://example.com/product6.jpg"
                },
                new Product
                {
                    Id = 7,
                    Name = "Product 7",
                    Description = "Description for Product 7",
                    Category = "Category 1",
                    Price = 11.99m,
                    ImageURL = "https://example.com/product7.jpg"
                },
                new Product
                {
                    Id = 8,
                    Name = "Product 8",
                    Description = "Description for Product 8",
                    Category = "Category 2",
                    Price = 21.99m,
                    ImageURL = "https://example.com/product8.jpg"
                },
                new Product
                {
                    Id = 9,
                    Name = "Product 9",
                    Description = "Description for Product 9",
                    Category = "Category 3",
                    Price = 31.99m,
                    ImageURL = "https://example.com/product9.jpg"
                },
                new Product
                {
                    Id = 10,
                    Name = "Product 10",
                    Description = "Description for Product 10",
                    Category = "Category 1",
                    Price = 15.99m,
                    ImageURL = "https://example.com/product10.jpg"
                }
            );
            #endregion
            #endregion
        }
    }
}
