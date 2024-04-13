using ECommerce.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.DAL.Data.Context
{
    public class EcommerceContext:DbContext
    {
        public DbSet<Cart> carts => Set<Cart>();
        public DbSet<CartItem> cartItems => Set<CartItem>();
        public DbSet<Order> orders => Set<Order>();
        public DbSet<OrderItem> orderItems => Set<OrderItem>();
        public DbSet<User> users => Set<User>();
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
            
            modelBuilder.Entity<Cart>()
               .HasOne(c => c.User)
               .WithOne(u => u.Cart)
               .HasForeignKey<User>(u => u.CartId)
               .IsRequired(); // Ensure every Cart must have a User
            #endregion
            #region User
            modelBuilder.Entity<User>()
                .HasOne(u => u.Cart)
                .WithOne(c => c.User)
                .HasForeignKey<Cart>(c => c.UserId)
                .IsRequired(); // Ensure every User must have a Cart
            #endregion
            #endregion
        }
    }
}
