using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace DataLayer
{
    public class NorthwindContext : DbContext
    {
        const string ConnectionString = "host=localhost;db=Northwind;uid=postgres;pwd=23278320";

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }        
        //public DbSet<OrderDetails> OrderDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.LogTo(Console.WriteLine, LogLevel.Information);
            optionsBuilder.UseNpgsql(ConnectionString);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<OrderDetails>().HasKey(am => new
            //{
            //    am.OrderId,
            //    am.ProductId,
            //});

            //modelBuilder.Entity<OrderDetails>().HasOne(m => m.Product)
            //.WithMany(am => am.).HasForeignKey(m => m.ProductId);

            //modelBuilder.Entity<OrderDetails>().HasOne(a => a.Order)
            //.WithMany(at => at.Product_Orders).HasForeignKey(a => a.OrderId);

            base.OnModelCreating(modelBuilder);



            modelBuilder.Entity<Category>().ToTable("categories");
            modelBuilder.Entity<Category>().Property(x => x.CategoryId).HasColumnName("categoryid");
            modelBuilder.Entity<Category>().Property(x => x.Name).HasColumnName("categoryname");
            modelBuilder.Entity<Category>().Property(x => x.Description).HasColumnName("description");

            modelBuilder.Entity<Product>().ToTable("products");
            modelBuilder.Entity<Product>().Property(x => x.Id).HasColumnName("productid");
            modelBuilder.Entity<Product>().Property(x => x.Name).HasColumnName("productname");
            modelBuilder.Entity<Product>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            modelBuilder.Entity<Product>().Property(x => x.QuantityPerUnit).HasColumnName("quantityperunit");
            modelBuilder.Entity<Product>().Property(x => x.UnitsInStock).HasColumnName("unitsinstock");
            modelBuilder.Entity<Product>().Property(x => x.CategoryId).HasColumnName("categoryid");

            modelBuilder.Entity<Order>().ToTable("orders");
            modelBuilder.Entity<Order>().Property(x => x.Id).HasColumnName("orderid");
            modelBuilder.Entity<Order>().Property(x => x.Date).HasColumnName("orderdate");
            modelBuilder.Entity<Order>().Property(x => x.Require).HasColumnName("requireddate");
            modelBuilder.Entity<Order>().Property(x => x.Shipped).HasColumnName("shippeddate");
            modelBuilder.Entity<Order>().Property(x => x.Freight).HasColumnName("freight");
            modelBuilder.Entity<Order>().Property(x => x.ShipName).HasColumnName("shipname");
            modelBuilder.Entity<Order>().Property(x => x.ShipCity).HasColumnName("shipcity");

            //modelBuilder.Entity<OrderDetails>().ToTable("orderdetails");
            //modelBuilder.Entity<OrderDetails>().Property(x => x.OrderId).HasColumnName("orderid");
            //modelBuilder.Entity<OrderDetails>().Property(x => x.ProductId).HasColumnName("productid");
            //modelBuilder.Entity<OrderDetails>().Property(x => x.UnitPrice).HasColumnName("unitprice");
            //modelBuilder.Entity<OrderDetails>().Property(x => x.Quantity).HasColumnName("quantity");
            //modelBuilder.Entity<OrderDetails>().Property(x => x.Discount).HasColumnName("discount");
        }
    }
}
