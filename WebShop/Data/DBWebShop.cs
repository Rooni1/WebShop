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

            modelBuilder
                .Entity<Product>().HasData(new Product
                {
                    ProductId = 1,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 20,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                },
                new Product
                {
                    ProductId = 2,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 45,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                },
                new Product
                {
                    ProductId = 3,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 60,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                },
                new Product
                {
                    ProductId = 4,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 75,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                },
                new Product
                {
                    ProductId = 5,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 90,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                },
                new Product
                {
                    ProductId = 6,
                    ProductDescription = "Maskinskruv M8",
                    ProductDimension = 8,
                    ProductLength = 120,
                    ProductName = "spårskruv M8",
                    ProductPrice = 1.0F
                });
                }

        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }

    }
}
