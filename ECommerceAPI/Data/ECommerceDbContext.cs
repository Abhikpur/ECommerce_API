//using System.Data.Entity;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata;
using ECommerceAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ECommerceAPI.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {

        }
        public DbSet<UserDetails> UserDetails { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<AddressTbl> AddressTbl { get; set; }
    }
}
