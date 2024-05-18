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
            modelBuilder.Entity<Cart>().HasMany<CartItem>(c=>c.CartItems).WithOne();//see what's the output of this in the migration
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
            #endregion
        }
    }
}
