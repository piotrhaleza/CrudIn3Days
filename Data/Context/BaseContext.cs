using Microsoft.EntityFrameworkCore;
using Models;
using Models.Models;
using Models.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Data
{
    public class BaseContext : DbContext
    {
        public const string connectionString = @"Data Source=DESKTOP-3M0G1UP\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True";

        public DbSet<Client> Clients { set; get; }
        public DbSet<Article> Articles { set; get; }
        public DbSet<OrderArticle> OrderArticles { set; get; }
        public DbSet<Order> Orders { set; get; }
        public DbSet<Order_OrderArticle> Order_OrderArticles { set; get; }

        public DbSet<V_Client> V_Clients { set; get; }
        public DbSet<V_Article> V_Articles { set; get; }
        public DbSet<V_OrderArticle> V_OrderArticles { set; get; }
        public DbSet<V_Order> V_Orders { set; get; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
                optionsBuilder.UseSqlServer(sqlConnectionStringBuilder.ToString());
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("CLIENTS", "dbo");
            });
            modelBuilder.Entity<Article>(entity =>
            {
                entity.ToTable("ARTICLES", "dbo");
            });
            modelBuilder.Entity<OrderArticle>(entity =>
            {
                entity.ToTable("ORDERARTICLES", "dbo");
            });
            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("ORDERS", "dbo");
            });
            modelBuilder.Entity<Order_OrderArticle>(entity =>
            {
                entity.ToTable("ORDER_ORDERARTICLES", "dbo");
            });

            modelBuilder.Entity<V_Client>(entity =>
            {
                entity.ToView("V_CLIENTS", "dbo");
            });
            modelBuilder.Entity<V_Article>(entity =>
            {
                entity.ToView("V_ARTICLES", "dbo");
            });
            modelBuilder.Entity<V_Order>(entity =>
            {
                entity.ToView("V_ORDERS", "dbo");
            });
            modelBuilder.Entity<V_OrderArticle>(entity =>
            {
                entity.ToView("V_ORDERARTICLES", "dbo");
            });
        }
    }
}

