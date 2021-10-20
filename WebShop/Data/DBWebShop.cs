using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models.Entities;

namespace WebShop.Data
{
    public class DBWebShop : DbContext
    {
        public DBWebShop(DbContextOptions<DBWebShop> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<OrderItem>()
                .HasKey(o => new {
                            o.OrderId,
                            o.ProductId
                        });

            modelBuilder
                .Entity<OrderItem>()
                .HasOne<Order>(o => o.Order)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(oi => oi.OrderId);

            modelBuilder
                .Entity<OrderItem>()
                .HasOne<Product>(o => o.Product)
                .WithMany(oi => oi.OrderItems)
                .HasForeignKey(oi => oi.ProductId);
        }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
