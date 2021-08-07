using Microsoft.EntityFrameworkCore;
using ShopBridge.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopBridge.Context
{
    public class ShopBridgeDB : DbContext
    {
        public ShopBridgeDB()
        {
        }

        public ShopBridgeDB(DbContextOptions options) : base(options)
        {
        }

        public DbSet<tblProductDetails> tblProductDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tblProductDetails>()
                .HasIndex(a => new { a.ProductName, a.Brand })
                .IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }
}
