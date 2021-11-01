// Time-stamp: <2021-10-31 16:56:42 stefan>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using WebShop.Models.Entities;

namespace WebShop.Data
{
    public class DBWebShop : DbContext
    {
	public DbSet<Product> Product { get; set; }
	public DbSet<Order> Order { get; set; }
	public DbSet<OrderItem> OrderItem { get; set; }

	public DBWebShop(DbContextOptions<DBWebShop> options) : base(options)
	{
	}

	/// <summary>
	/// Använder PostgreSQL istället för MS SQL som database
	/// Istället för att via appsettings*.json sätta anslutningssträngarna kan man göra så här istället
	/// </summary>
	// protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//     => optionsBuilder.UseNpgsql("Host=localhost;Database=webshop;Username=stefan;Password=TestWebShop");

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
	    base.OnModelCreating(modelBuilder);
	    modelBuilder.Entity<OrderItem>()
		.HasKey(o => new
		{
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
		.Entity<Product>().HasData(
		new Product
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
	    modelBuilder
		.Entity<Order>().HasData(
		new Order
		{
		    OrderId=1,
		    OrderDate=DateTime.Now
		},
		new Order
		{
		    OrderId=2,
		    OrderDate=DateTime.Now
		}
		);
	    modelBuilder
		.Entity<OrderItem>().HasData(
		new OrderItem
		{
		    OrderId=1,
		    ProductId=1,
		    Quantity=20
		},
		new OrderItem
		{
		    OrderId=1,
		    ProductId=2,
		    Quantity=20
		}
		);
	    modelBuilder
		.Entity<OrderItem>().HasData(
		new OrderItem
		{
		    OrderId = 2,
		    ProductId = 5,
		    Quantity = 30
		},
		new OrderItem
		{
		    OrderId = 2,
		    ProductId = 6,
		    Quantity = 35
		}
		);
	}
    }
}
