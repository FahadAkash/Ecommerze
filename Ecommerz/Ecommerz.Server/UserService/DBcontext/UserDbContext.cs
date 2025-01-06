using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ecommerz.Server.UserService.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerz.Server.UserService.DBcontext
{
    public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<ShippingInfo> ShippingInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             base.OnModelCreating(modelBuilder);

             modelBuilder.Entity<User>()
             .HasIndex(u => u.Email)
             .IsUnique();
             modelBuilder.Entity<Cart>()
             .HasOne(c => c.User)
             .WithMany( u => u.Carts)
             .HasForeignKey( c => c.UserId);
             modelBuilder.Entity<CartItem>()
             .HasOne(ci => ci.Cart)
             .WithMany(c => c.CartItems)
             .HasForeignKey(ci => ci.CartID);
             modelBuilder.Entity<ShippingInfo>()
             .HasOne(si => si.User)
             .WithOne(c => c.shippingInfo)
             .HasForeignKey<ShippingInfo>(si => si.userId);



        }

    }
}